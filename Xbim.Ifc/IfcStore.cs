﻿using System;
using System.CodeDom;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml;
using ICSharpCode.SharpZipLib.Zip;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Common.Geometry;
using Xbim.Common.Metadata;
using Xbim.Common.Step21;
using Xbim.Common.XbimExtensions;
using Xbim.Ifc4.Interfaces;
using Xbim.IO;
using Xbim.IO.Esent;
using Xbim.IO.Memory;
using Xbim.IO.Step21;
using Xbim.IO.Step21.Parser;
using Xbim.IO.Xml;
using Xbim.IO.Xml.BsConf;

namespace Xbim.Ifc
{
    public class IfcStore : IModel, IDisposable
    {
        private readonly IModel _model;
        private readonly IfcSchemaVersion _schema;
         
        private readonly bool _deleteModelOnClose;
        private readonly string _xbimFileName;
        public event NewEntityHandler EntityNew;
        public event ModifiedEntityHandler EntityModified;
        public event DeletedEntityHandler EntityDeleted;
        private bool _disposed;
        /// <summary>
        /// The default largest size in MB for an ifc file to be loaded into memory, above this size the store will choose to use the database storage media to mimise the memory footprint. This size can be set in the config file or in the open statement of this store 
        /// </summary>
        public static double DefaultIfcDatabaseSizeThreshHold = 30; //default size set to 30MB
        private IIfcOwnerHistory _ownerHistoryAddObject;
        private IIfcOwnerHistory _ownerHistoryModifyObject;

        private IIfcPersonAndOrganization _defaultOwningUser;
        private IIfcApplication _defaultOwningApplication;
        private readonly XbimEditorCredentials _editorDetails;


        protected IfcStore(IModel iModel, IfcSchemaVersion schema, XbimEditorCredentials editorDetails, string fileName = null, string xbimFileName = null,
            bool deleteOnClose = false)
        {
            _model = iModel;
            _model.EntityNew += _model_EntityNew;
            _model.EntityDeleted += _model_EntityDeleted;
            _model.EntityModified += _model_EntityModified;
            _deleteModelOnClose = deleteOnClose;
            FileName = fileName;
            _xbimFileName = xbimFileName;
            _schema = schema;
            if (editorDetails == null)
                _editorDetails = new XbimEditorCredentials()
                {
                    ApplicationDevelopersName = "Unspecified",
                    ApplicationVersion = "Unspecified",
                    ApplicationFullName = "Unspecified",
                    EditorsFamilyName = Environment.UserName,
                    EditorsOrganisationName = "Unspecified",
                    EditorsGivenName = ""
                };
            else _editorDetails = editorDetails;


            if (schema == IfcSchemaVersion.Ifc4)
            {
                _model.EntityNew += IfcRootInitIfc4;
                _model.EntityModified += IfcRootModifiedIfc4;
            }
            else //its 2x3
            {
                _model.EntityNew += IfcRootInitIfc2X3;
                _model.EntityModified += IfcRootModifiedIfc2X3;
            }
            CalculateModelFactors();
        }

        private void _model_EntityDeleted(IPersistEntity entity)
        {
            if (EntityDeleted == null) return;
            EntityDeleted(entity);
        }

        private void _model_EntityNew(IPersistEntity entity)
        {
            if (EntityNew == null) return;
            EntityNew(entity);
        }

        private void _model_EntityModified(IPersistEntity entity)
        {
            if (EntityModified == null) return;
            EntityModified(entity);
        }
        //public static IfcStore LoadStep21( Stream inputStream, XbimStorageType storageType, string xbimDbName, XbimDBAccess accessMode = XbimDBAccess.Read, double? ifcDatabaseSizeThreshHold = null, ReportProgressDelegate progDelegate = null)
        //{
        //    var ifcVersion = GetIfcSchemaVersion(inputStream);
        //    if (ifcVersion == IfcSchemaVersion.Unsupported)
        //        throw new FileLoadException(filePath + " is not a valid Ifc file format, ifc, ifcxml, ifczip and xBIM are supported");
        //    if (storageType == XbimStorageType.Xbim) //open the XbimFile
        //    {
        //        if (ifcVersion == IfcSchemaVersion.Ifc4)
        //        {
        //            var model = new EsentModel(new Ifc4.EntityFactory());
        //            model.LoadStep21(inputStream, accessMode, progDelegate);
        //            return new IfcStore(model);
        //        }
        //        else //it will be Ifc2x3
        //        {
        //            var model = new EsentModel(new Ifc2x3.EntityFactory());
        //            model.LoadStep21(inputStream, accessMode, progDelegate);
        //            return new IfcStore(model);
        //        }
        //    }
        //    else //it will be an Ifc file if we are at this point
        //    {
        //        var fInfo = new FileInfo(path);
        //        double ifcMaxLength = (ifcDatabaseSizeThreshHold ?? DefaultIfcDatabaseSizeThreshHold) * 1024 * 1024;
        //        if (fInfo.Length > ifcMaxLength) //we need to make an esent database
        //        {
        //            var tmpFileName = Path.GetTempFileName();
        //            if (ifcVersion == IfcSchemaVersion.Ifc4)
        //            {
        //                var model = new EsentModel(new Ifc4.EntityFactory());
        //                model.CreateFrom(path, tmpFileName, progDelegate, true);
        //                return new IfcStore(model);
        //            }
        //            else //it will be Ifc2x3
        //            {
        //                var model = new EsentModel(new Ifc2x3.EntityFactory());
        //                model.CreateFrom(path, tmpFileName, progDelegate, true);
        //                return new IfcStore(model);
        //            }
        //        }
        //        else //we can use a memory model
        //        {
        //            if (ifcVersion == IfcSchemaVersion.Ifc4)
        //            {
        //                var model = new MemoryModel<Ifc4.EntityFactory>();
        //                model.LoadStep21(path, progDelegate);
        //                return new IfcStore(model);
        //            }
        //            else //it will be Ifc2x3
        //            {
        //                var model = new MemoryModel<Ifc2x3.EntityFactory>();
        //                model.LoadStep21(path, progDelegate);
        //                return new IfcStore(model);
        //            }
        //        }
        //    }
        //}


        /// <summary>
        /// Opens an Ifc file, Ifcxml, IfcZip, xbim
        /// </summary>
        /// <param name="path">the file name of the ifc, ifczip, ifcxml or xbim file to be opened</param>
        /// <param name="editorDetails">This is only required if the store is opened for editing</param>
        /// <param name="ifcDatabaseSizeThreshHold">if not defined the DefaultIfcDatabaseSizeThreshHold is used, Ifc files below this size will be opened in memory, above this size a database will be created. If -1 is specified an in memory model will be created for all Ifc files that are opened. Xbim files are always opened as databases</param>
        /// <param name="progDelegate"></param>
        public static IfcStore Open(string path, XbimEditorCredentials editorDetails = null, double? ifcDatabaseSizeThreshHold = null, ReportProgressDelegate progDelegate = null)
        {
            var filePath = Path.GetFullPath(path);
            if (!Directory.Exists(Path.GetDirectoryName(filePath) ?? ""))
                throw new DirectoryNotFoundException(Path.GetDirectoryName(filePath) + " directory was not found");
            if (!File.Exists(filePath))
                throw new FileNotFoundException(filePath + " file was not found");
            var storageType = path.StorageType();
            string schemaIdentifier;
            var ifcVersion = GetIfcSchemaVersion(path, out schemaIdentifier);
            if (ifcVersion == IfcSchemaVersion.Unsupported)
            {
                if(string.IsNullOrWhiteSpace(schemaIdentifier))
                    throw new FileLoadException(filePath + " is not a valid IFC file format, ifc, ifcxml, ifczip and xBIM are supported.");
                throw new FileLoadException(filePath + ", is IFC file version " + schemaIdentifier + ". IFC2x3 and IFC4 are supported. Check your exporter settings please.");
            }

            if (storageType == IfcStorageType.Xbim) //open the XbimFile
            {

                if (ifcVersion == IfcSchemaVersion.Ifc4)
                {
                    var model = new EsentModel(new Ifc4.EntityFactory());
                    model.Open(path, XbimDBAccess.Read, progDelegate);
                    return new IfcStore(model, ifcVersion, editorDetails, path);
                }
                else //it will be Ifc2x3
                {
                    var model = new EsentModel(new Ifc2x3.EntityFactory());
                    model.Open(path, XbimDBAccess.Read, progDelegate);
                    return new IfcStore(model, ifcVersion, editorDetails, path);
                }
            }
            else //it will be an Ifc file if we are at this point
            {
                var fInfo = new FileInfo(path);
                double ifcMaxLength = (ifcDatabaseSizeThreshHold ?? DefaultIfcDatabaseSizeThreshHold) * 1024 * 1024;
                if (ifcMaxLength >= 0 && fInfo.Length > ifcMaxLength) //we need to make an esent database, if ifcMaxLength<0 we use in memory
                {
                    var tmpFileName = Path.GetTempFileName();
                    if (ifcVersion == IfcSchemaVersion.Ifc4)
                    {
                        var model = new EsentModel(new Ifc4.EntityFactory());
                        model.CreateFrom(path, tmpFileName, progDelegate, true);
                        return new IfcStore(model, ifcVersion, editorDetails, path, tmpFileName, true);
                    }
                    else //it will be Ifc2x3
                    {
                        var model = new EsentModel(new Ifc2x3.EntityFactory());
                        model.CreateFrom(path, tmpFileName, progDelegate, true);
                        return new IfcStore(model, ifcVersion, editorDetails, path, tmpFileName, true);
                    }
                }
                else //we can use a memory model
                {
                    var model = ifcVersion == IfcSchemaVersion.Ifc4 ? new MemoryModel(new Ifc4.EntityFactory()) : new MemoryModel(new Ifc2x3.EntityFactory());
                    if (storageType.HasFlag(IfcStorageType.IfcZip) )
                    {
                        using (var zipFile = new ZipFile(path))
                        {
                            foreach (ZipEntry zipEntry in zipFile)
                            {
                                if (!zipEntry.IsFile) continue; // 
                                using (var reader = zipFile.GetInputStream(zipEntry))
                                {
                                    var zipStorageType = zipEntry.Name.StorageType();
                                    if (zipStorageType == IfcStorageType.Ifc)
                                    {
                                        model.LoadStep21(reader, progDelegate);
                                    }
                                    else if (zipStorageType == IfcStorageType.IfcXml)
                                    {
                                        model.LoadXml(reader, progDelegate);
                                    }
                                }
                                break; //now we have one
                            }
                        }
                    }
                    else if (storageType.HasFlag(IfcStorageType.Ifc))
                        model.LoadStep21(path, progDelegate);
                    else if (storageType.HasFlag(IfcStorageType.IfcXml))
                        model.LoadXml(path, progDelegate);
                    return new IfcStore(model, ifcVersion, editorDetails, path);
                }
            }
        }

        public static IfcSchemaVersion GetIfcSchemaVersion(string path, out string schemaIdentifier)
        {
            var storageType = path.StorageType();
            if (storageType == IfcStorageType.Invalid)
            {
                schemaIdentifier = "";
                return IfcSchemaVersion.Unsupported;
            }
            var stepHeader = storageType == IfcStorageType.Xbim ? EsentModel.GetStepFileHeader(path) : MemoryModel.GetFileHeader(path);
            var stepSchema = stepHeader.FileSchema;
            schemaIdentifier = string.Join(", ", stepSchema.Schemas);
            foreach (var schema in stepSchema.Schemas)
            {
                if (string.Compare(schema, "Ifc4", StringComparison.OrdinalIgnoreCase) == 0)
                    return IfcSchemaVersion.Ifc4;
                if (string.Compare(schema, "Ifc2x3", StringComparison.OrdinalIgnoreCase) == 0)
                    return IfcSchemaVersion.Ifc2X3;
            }

            return IfcSchemaVersion.Unsupported;
        }

        


        public int UserDefinedId
        {
            get { return _model.UserDefinedId; }
            set { _model.UserDefinedId = value; }
        }

        public IGeometryStore GeometryStore
        {
            get { return _model.GeometryStore; }
        }

        public IStepFileHeader Header
        {
            get { return _model.Header; }
        }

        public bool IsTransactional
        {
            get { return _model.IsTransactional; }
        }

        public IEntityCollection Instances
        {
            get { return _model.Instances; }
        }


        public bool Activate(IPersistEntity owningEntity, bool write)
        {
            return _model.Activate(owningEntity, write);
        }

        public void Delete(IPersistEntity entity)
        {
            _model.Delete(entity);
        }

        public ITransaction BeginTransaction(string name = null)
        {
            var esentModel = _model as EsentModel;
            if (esentModel != null) //we need to do transaction handling on esent model, make sure we can write to it
            { 
                esentModel.Header.StampXbimApplication(_schema);
                return esentModel.BeginTransaction(name);
            }

            var memoryModel = _model as MemoryModel;
                if (memoryModel != null)
                {
                    memoryModel.Header.StampXbimApplication(_schema);
                    return memoryModel.BeginTransaction(name);                   
                }
            
            throw new XbimException("Native store does not support transactions");
        }

        public ITransaction CurrentTransaction
        {
            get { return _model.CurrentTransaction; }
        }

        public ExpressMetaData Metadata
        {
            get { return _model.Metadata; }
        }

        public IModelFactors ModelFactors
        {
            get { return _model.ModelFactors; }
        }

        public string FileName { get; set; }


        public void ForEach<TSource>(IEnumerable<TSource> source, Action<TSource> body) where TSource : IPersistEntity
        {
            _model.ForEach(source, body);
        }



        public void Dispose()
        {
            Dispose(true);
            // Take yourself off the Finalization queue 
            // to prevent finalization code for this object
            // from executing a second time.
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                try
                {
                    // If disposing equals true, dispose all managed 
                    // and unmanaged resources.
                    if (disposing)
                    {
                        //managed resources
                        var disposeInterface = _model as IDisposable;
                        if (disposeInterface != null) disposeInterface.Dispose();
                    }
                    //unmanaged, mostly esent related                  
                }
                catch
                {
                    // ignored
                }
            }
            _disposed = true;
        }
        /// <summary>
        /// Closes the store and disposes of all resources, the store is invalid after this call
        /// </summary>
        public void Close()
        {
            var esent = _model as EsentModel;
            if (esent != null) esent.Close();
            Dispose();
            try //try and tidy up if required
            {
                if (_deleteModelOnClose && !string.IsNullOrWhiteSpace(_xbimFileName) && File.Exists(_xbimFileName))
                    File.Delete(_xbimFileName);
            }
            catch (Exception)
            {
                // ignored
            }

        }

        public static IfcStore Create(XbimEditorCredentials editorDetails, IfcSchemaVersion ifcVersion, XbimStoreType storageType)
        {
            if (storageType == XbimStoreType.EsentDatabase)
            {
                if (ifcVersion == IfcSchemaVersion.Ifc4)
                {
                    var temporaryModel = EsentModel.CreateTemporaryModel(new Ifc4.EntityFactory());
                    return new IfcStore(temporaryModel, ifcVersion, editorDetails, temporaryModel.DatabaseName); //it will delete itself anyway
                }
                else //it will be Ifc2x3
                {
                    var temporaryModel = EsentModel.CreateTemporaryModel(new Ifc2x3.EntityFactory());
                    return new IfcStore(temporaryModel, ifcVersion, editorDetails, temporaryModel.DatabaseName); //it will delete itself anyway
                }
            }
            else //it will be memory model
            {

                if (ifcVersion == IfcSchemaVersion.Ifc4)
                {
                    var memoryModel = new MemoryModel(new Ifc4.EntityFactory());
                    return new IfcStore(memoryModel, ifcVersion, editorDetails);
                }
                else //it will be Ifc2x3
                {
                    var memoryModel = new MemoryModel(new Ifc2x3.EntityFactory());
                    return new IfcStore(memoryModel, ifcVersion, editorDetails);
                }
            }
        }

        #region OwnerHistory Management


        private void IfcRootModifiedIfc2X3(IPersistEntity entity)
        {

            var root = entity as Ifc2x3.Kernel.IfcRoot;

            if (root == null || root.OwnerHistory == (Ifc2x3.UtilityResource.IfcOwnerHistory)_ownerHistoryAddObject)
                return;

            if (root.OwnerHistory != (Ifc2x3.UtilityResource.IfcOwnerHistory)_ownerHistoryModifyObject)
                root.OwnerHistory = (Ifc2x3.UtilityResource.IfcOwnerHistory)OwnerHistoryModifyObject;
        }

        private void IfcRootInitIfc2X3(IPersistEntity entity)
        {
            var root = entity as Ifc2x3.Kernel.IfcRoot;
            if (root != null)
            {
                root.OwnerHistory = (Ifc2x3.UtilityResource.IfcOwnerHistory)OwnerHistoryAddObject;
            }
        }


        private void IfcRootModifiedIfc4(IPersistEntity entity)
        {
            var root = entity as Ifc4.Kernel.IfcRoot;
            if (root == null || root.OwnerHistory == (Ifc4.UtilityResource.IfcOwnerHistory)_ownerHistoryAddObject)
                return;

            if (root.OwnerHistory != (Ifc4.UtilityResource.IfcOwnerHistory)_ownerHistoryModifyObject)
                root.OwnerHistory = (Ifc4.UtilityResource.IfcOwnerHistory)OwnerHistoryModifyObject;
        }

        private void IfcRootInitIfc4(IPersistEntity entity)
        {
            var root = entity as Ifc4.Kernel.IfcRoot;
            if (root != null)
            {
                root.OwnerHistory = (Ifc4.UtilityResource.IfcOwnerHistory)OwnerHistoryAddObject;
            }
        }


        public IIfcPersonAndOrganization DefaultOwningUser
        {
            get
            {
                if (_defaultOwningUser != null) return _defaultOwningUser;
                if (_schema == IfcSchemaVersion.Ifc4)
                {
                    var person = Instances.New<Ifc4.ActorResource.IfcPerson>(p =>
                    {
                        p.GivenName = _editorDetails.EditorsGivenName;
                        p.FamilyName = _editorDetails.EditorsFamilyName;
                    });
                    var organization = Instances.New<Ifc4.ActorResource.IfcOrganization>(o => o.Name = _editorDetails.EditorsOrganisationName);
                    _defaultOwningUser = Instances.New<Ifc4.ActorResource.IfcPersonAndOrganization>(po =>
                    {
                        po.TheOrganization = organization;
                        po.ThePerson = person;
                    });
                }
                else
                {
                    var person = Instances.New<Ifc2x3.ActorResource.IfcPerson>(p =>
                    {
                        p.GivenName = _editorDetails.EditorsGivenName;
                        p.FamilyName = _editorDetails.EditorsFamilyName;
                    });
                    var organization = Instances.New<Ifc2x3.ActorResource.IfcOrganization>(o => o.Name = _editorDetails.EditorsOrganisationName);
                    _defaultOwningUser = Instances.New<Ifc2x3.ActorResource.IfcPersonAndOrganization>(po =>
                    {
                        po.TheOrganization = organization;
                        po.ThePerson = person;
                    });
                }
                return _defaultOwningUser;
            }
        }

        public IIfcApplication DefaultOwningApplication
        {
            get
            {
                if (_defaultOwningApplication != null) return _defaultOwningApplication;
                if (_schema == IfcSchemaVersion.Ifc4)
                    return _defaultOwningApplication ??
                         (_defaultOwningApplication =
                             Instances.New<Ifc4.UtilityResource.IfcApplication>(a =>
                             {
                                 a.ApplicationDeveloper = Instances.New<Ifc4.ActorResource.IfcOrganization>(o => o.Name = _editorDetails.ApplicationDevelopersName);
                                 a.ApplicationFullName = _editorDetails.ApplicationFullName;
                                 a.ApplicationIdentifier = _editorDetails.ApplicationIdentifier;
                             }
                ));
                return _defaultOwningApplication ??
                        (_defaultOwningApplication =
                            Instances.New<Ifc2x3.UtilityResource.IfcApplication>(a =>
                            {
                                a.ApplicationDeveloper = Instances.New<Ifc2x3.ActorResource.IfcOrganization>(o => o.Name = _editorDetails.ApplicationDevelopersName);
                                a.ApplicationFullName = _editorDetails.ApplicationFullName;
                                a.ApplicationIdentifier = _editorDetails.ApplicationIdentifier;
                            }
                ));
            }
        }

        public IIfcOwnerHistory OwnerHistoryAddObject
        {
            get
            {
                if (_ownerHistoryAddObject == null)
                {
                    if (_schema == IfcSchemaVersion.Ifc4)
                    {
                        var histAdd = Instances.New<Ifc4.UtilityResource.IfcOwnerHistory>();
                        histAdd.OwningUser = (Ifc4.ActorResource.IfcPersonAndOrganization)DefaultOwningUser;
                        histAdd.OwningApplication = (Ifc4.UtilityResource.IfcApplication)DefaultOwningApplication;
                        histAdd.ChangeAction = IfcChangeActionEnum.ADDED;
                        _ownerHistoryAddObject = histAdd;
                    }
                    else
                    {
                        var histAdd = Instances.New<Ifc2x3.UtilityResource.IfcOwnerHistory>();
                        histAdd.OwningUser = (Ifc2x3.ActorResource.IfcPersonAndOrganization)DefaultOwningUser;
                        histAdd.OwningApplication = (Ifc2x3.UtilityResource.IfcApplication)DefaultOwningApplication;
                        histAdd.ChangeAction = Ifc2x3.UtilityResource.IfcChangeActionEnum.ADDED;
                        _ownerHistoryAddObject = histAdd;
                    }
                }
                return _ownerHistoryAddObject;
            }
        }

        public IfcSchemaVersion IfcSchemaVesion
        {
            get
            {
                return _schema;
            }
        }

        internal IIfcOwnerHistory OwnerHistoryModifyObject
        {
            get
            {
                if (_ownerHistoryModifyObject == null)
                {
                    if (_schema == IfcSchemaVersion.Ifc4)
                    {
                        var histmod = Instances.New<Ifc4.UtilityResource.IfcOwnerHistory>();
                        histmod.OwningUser = (Ifc4.ActorResource.IfcPersonAndOrganization)DefaultOwningUser;
                        histmod.OwningApplication = (Ifc4.UtilityResource.IfcApplication)DefaultOwningApplication;
                        histmod.ChangeAction = IfcChangeActionEnum.MODIFIED;
                        _ownerHistoryModifyObject = histmod;
                    }
                    else
                    {
                        var histmod = Instances.New<Ifc2x3.UtilityResource.IfcOwnerHistory>();
                        histmod.OwningUser = (Ifc2x3.ActorResource.IfcPersonAndOrganization)DefaultOwningUser;
                        histmod.OwningApplication = (Ifc2x3.UtilityResource.IfcApplication)DefaultOwningApplication;
                        histmod.ChangeAction = Ifc2x3.UtilityResource.IfcChangeActionEnum.MODIFIED;
                        _ownerHistoryModifyObject = histmod;
                    }

                }
                return _ownerHistoryModifyObject;
            }
        }

        protected XbimEditorCredentials EditorDetails
        {
            get { return _editorDetails; }
        }
        #endregion

        #region Transaction support
       

        #endregion

        /// <summary>
        /// Saves the model to the specified file
        /// </summary>
        /// <param name="fileName">Name of the file to save to, if no format is specified the extension is used to determine the format</param>
        /// <param name="format">if specified saves in the required format and changes the extension to the correct one</param>
        /// <param name="progDelegate">reports on progress</param>
        public void SaveAs(string fileName, IfcStorageType? format=null, ReportProgressDelegate progDelegate = null)
        {
            if (string.IsNullOrWhiteSpace(fileName)) return;
            var extension = Path.GetExtension(fileName).ToLowerInvariant();
            IfcStorageType actualFormat = IfcStorageType.Invalid;
            if (format.HasValue)
            {
                if (format.Value.HasFlag(IfcStorageType.IfcZip))
                {
                    extension = ".ifczip";
                    actualFormat = IfcStorageType.IfcZip;
                    if (format.Value.HasFlag(IfcStorageType.IfcXml)) //set it to default to Ifc
                        actualFormat |= IfcStorageType.IfcXml;
                    else
                        actualFormat |= IfcStorageType.Ifc;
                }
                else if (format.Value.HasFlag(IfcStorageType.Ifc))
                {
                    extension = ".ifc";
                    actualFormat = IfcStorageType.Ifc;
                }
                else if (format.Value.HasFlag(IfcStorageType.IfcXml))
                {
                    extension = ".ifcxml";
                    actualFormat = IfcStorageType.IfcXml;
                }
                else if (format.Value.HasFlag(IfcStorageType.Xbim))
                {
                    extension = ".xbim";
                    actualFormat = IfcStorageType.Xbim;
                }  
            }
            else
            {
                if (extension == ".ifczip")
                {
                    actualFormat = IfcStorageType.IfcZip;
                    actualFormat |= IfcStorageType.Ifc; //the default
                }
                else if (extension == ".ifcxml")
                    actualFormat = IfcStorageType.IfcXml;
                else if (extension == ".xbim")
                    actualFormat = IfcStorageType.Xbim;
                else
                {
                    extension = ".ifc";
                    actualFormat = IfcStorageType.Ifc; //the default
                }
            }
            var actualFileName = Path.ChangeExtension(fileName,extension);
            var esentModel = _model as EsentModel;
            if (esentModel != null)
            {
                var xbimTarget = !string.IsNullOrEmpty(extension) &&
                                 string.Compare(extension, ".xbim", StringComparison.OrdinalIgnoreCase) == 0;
                if ((format.HasValue && format.Value == IfcStorageType.Xbim) || (!format.HasValue && xbimTarget))
                {
                    var fullSourcePath = Path.GetFullPath(esentModel.DatabaseName);
                    var fullTargetPath = Path.GetFullPath(fileName);
                    if (string.Compare(fullSourcePath, fullTargetPath, StringComparison.OrdinalIgnoreCase) == 0)
                        return; //do nothing it is already saved
                }
            }
            SaveAs(actualFileName, actualFormat, progDelegate);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="actualFileName"></param>
        /// <param name="actualFormat">this will be correctly set</param>
        /// <param name="schema"></param>
        /// <param name="progDelegate"></param>
        private void SaveAs(string actualFileName, IfcStorageType actualFormat, ReportProgressDelegate progDelegate)
        {
            if (actualFormat.HasFlag(IfcStorageType.Xbim)) //special case for xbim
            {
                var esentDb = _schema==IfcSchemaVersion.Ifc4 ? new EsentModel(new Ifc4.EntityFactory()) : new EsentModel(new Ifc2x3.EntityFactory());
                esentDb.CreateFrom(_model, actualFileName, progDelegate);
            }
            else
            {
                using (var fileStream = new FileStream(actualFileName, FileMode.Create, FileAccess.Write))
                {
                    if (actualFormat.HasFlag(IfcStorageType.IfcZip))
                        //do zip first so that xml and ifc are not confused by the combination of flags
                        SaveAsIfcZip(fileStream, Path.GetFileName(actualFileName), actualFormat, progDelegate);
                    else if (actualFormat.HasFlag(IfcStorageType.Ifc))
                        SaveAsIfc(fileStream, progDelegate);
                    else if (actualFormat.HasFlag(IfcStorageType.IfcXml))
                        SaveAsIfcXml(fileStream, progDelegate);

                }
            }
        }

        public void SaveAsIfcXml(Stream stream, ReportProgressDelegate progDelegate=null)
        {
            var settings = new XmlWriterSettings { Indent = true };
            using (var xmlWriter = XmlWriter.Create(stream, settings))
            {
                if (_schema == IfcSchemaVersion.Ifc2X3)
                {
                    var writer = new IfcXmlWriter3();
                    writer.Write(_model, xmlWriter, _model.Instances);

                }
                else if (_schema == IfcSchemaVersion.Ifc4)
                {
                    var writer = new XbimXmlWriter4(configuration.IFC4Add1);
                    var project = _model.Instances.OfType<Xbim.Ifc4.Kernel.IfcProject>();
                    var products = _model.Instances.OfType<Xbim.Ifc4.Kernel.IfcObject>();
                    var relations = _model.Instances.OfType<Xbim.Ifc4.Kernel.IfcRelationship>();

                    var all =
                        new IPersistEntity[] { }
                        //start from root
                            .Concat(project)
                        //add all products not referenced in the project tree
                            .Concat(products)
                        //add all relations which are not inversed
                            .Concat(relations)
                        //make sure all other objects will get written
                            .Concat(_model.Instances);

                    writer.Write(_model, xmlWriter, all);
                }
                xmlWriter.Close();
            }
        }

        public void SaveAsIfc(Stream stream, ReportProgressDelegate progDelegate = null)
        {
                
            using (TextWriter tw = new StreamWriter(stream))
            {
                var p21 = new Part21FileWriter();
                p21.Write(_model, tw, _model.Metadata);
                tw.Flush();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stream">The stream will be closed and flushed on return</param>
        /// <param name="zipEntryName">The name of the file zipped inside the file</param>
        /// <param name="storageType">Specify IfcZip and then either IfcXml or Ifc</param>
        /// <param name="progDelegate"></param>
        public void SaveAsIfcZip(Stream stream, string zipEntryName, IfcStorageType storageType, ReportProgressDelegate progDelegate = null)
        {
            Debug.Assert(storageType.HasFlag(IfcStorageType.IfcZip));
            string fileBody;
            if (storageType.HasFlag(IfcStorageType.IfcXml)) //set the correct internal format
                fileBody = Path.ChangeExtension(zipEntryName, "ifcXml");
            else //it will be ifc
                fileBody = Path.ChangeExtension(zipEntryName, "ifc");
            var zipStream = new ZipOutputStream(stream);
            try
            {
                zipStream.SetLevel(3); //0-9, 9 being the highest level of compression
                var newEntry = new ZipEntry(fileBody) { DateTime = DateTime.Now };
                zipStream.PutNextEntry(newEntry);

                if (storageType.HasFlag(IfcStorageType.IfcXml))
                    SaveAsIfcXml(zipStream, progDelegate);
                else //assume it is Ifc
                    SaveAsIfc(zipStream, progDelegate);
            }
            finally
            {
                zipStream.IsStreamOwner = false;
                zipStream.Finish();
                zipStream.Close();               
            }
        }

        /// <summary>
        /// This function is used to generate the .wexbim model files.
        /// </summary>
        /// <param name="binaryStream">An open writable streamer.</param>
        public void SaveAsWexBim(BinaryWriter binaryStream)
        {
            // ReSharper disable RedundantCast
            if(GeometryStore==null) throw new XbimException("Geometry store has not been initialised");
            // ReSharper disable once CollectionNeverUpdated.Local
            var colourMap = new XbimColourMap();
            using (var geomRead = GeometryStore.BeginRead())
            {

                var lookup = geomRead.ShapeGeometries;
                var styles = geomRead.StyleIds;
                var regions = geomRead.Regions.SelectMany(r=>r).ToList();

                int numberOfGeometries = 0;
                int numberOfVertices = 0;
                int numberOfTriangles = 0;
                int numberOfMatrices = 0;
                int numberOfProducts = 0;
                int numberOfStyles = styles.Count;
                //start writing out

                binaryStream.Write((Int32) WexBimId); //magic number

                binaryStream.Write((byte) 2); //version of stream, arrays now packed as doubles
                var start = (int) binaryStream.Seek(0, SeekOrigin.Current);
                binaryStream.Write((Int32) 0); //number of shapes
                binaryStream.Write((Int32) 0); //number of vertices
                binaryStream.Write((Int32) 0); //number of triangles
                binaryStream.Write((Int32) 0); //number of matrices
                binaryStream.Write((Int32) 0); //number of products
                binaryStream.Write((Int32) numberOfStyles); //number of styles
                binaryStream.Write(Convert.ToSingle(_model.ModelFactors.OneMetre));
                    //write out conversion to meter factor

                binaryStream.Write(Convert.ToInt16(regions.Count)); //write out the population data
                foreach (var r in regions)
                {
                    binaryStream.Write((Int32) (r.Population));
                    var bounds = r.ToXbimRect3D();
                    var centre = r.Centre;
                    //write out the centre of the region
                    binaryStream.Write((Single) centre.X);
                    binaryStream.Write((Single) centre.Y);
                    binaryStream.Write((Single) centre.Z);
                    //bounding box of largest region
                    binaryStream.Write(bounds.ToFloatArray());
                }
                //textures
                foreach (var styleId in styles)
                {
                    XbimColour colour;
                    if (styleId > 0)
                    {
                        var ss = (IIfcSurfaceStyle)Instances[styleId];
                        var texture = XbimTexture.Create(ss);
                        colour = texture.ColourMap.FirstOrDefault();
                    }
                    else //use the default in the colour map for th enetity type
                    {
                        var theType = _model.Metadata.GetType((short)Math.Abs(styleId));
                        colour = colourMap[theType.Name];
                    }
                    if (colour == null) colour = XbimColour.DefaultColour;
                    binaryStream.Write((Int32)styleId); //style ID                       
                    binaryStream.Write((Single)colour.Red);
                    binaryStream.Write((Single)colour.Green);
                    binaryStream.Write((Single)colour.Blue);
                    binaryStream.Write((Single)colour.Alpha);

                }

                //write out all the product bounding boxes
                foreach (var product in Instances.OfType<IIfcProduct>())
                {
                    if (!(product is IIfcFeatureElement))
                    {
                        var bb = XbimRect3D.Empty;
                        foreach (var si in geomRead.ShapeInstancesOfEntity(product))
                        {
                            var bbPart = XbimRect3D.TransformBy(si.BoundingBox, si.Transformation);
                                //make sure we put the box in the right place and then convert to axis aligned
                            if (bb.IsEmpty) bb = bbPart;
                            else
                                bb.Union(bbPart);
                        }
                        if (!bb.IsEmpty) //do not write out anything with no geometry
                        {
                            binaryStream.Write((Int32) product.EntityLabel);
                            binaryStream.Write((UInt16) _model.Metadata.ExpressTypeId(product));
                            binaryStream.Write(bb.ToFloatArray());
                            numberOfProducts++;
                        }
                    }
                }

                //write out the multiple instances
                var openingElementId = _model.Metadata.ExpressTypeId("IFCOPENINGELEMENT");
                foreach (var geometry in lookup)
                {
                    if (geometry.ReferenceCount > 1)
                    {
                        var instances = geomRead.ShapeInstancesOfGeometry(geometry.ShapeLabel);
                        var xbimShapeInstances = instances as IList<XbimShapeInstance> ?? instances.ToList();
                        if (!xbimShapeInstances.Any()) continue;
                        numberOfGeometries++;
                        binaryStream.Write(geometry.ReferenceCount); //the number of repetitions of the geometry
                        foreach (IXbimShapeInstanceData xbimShapeInstance in xbimShapeInstances)
                            //write out each of the ids style and transforms
                        {
                            binaryStream.Write(xbimShapeInstance.IfcProductLabel);
                            binaryStream.Write((UInt16) xbimShapeInstance.IfcTypeId);
                            binaryStream.Write((UInt32) xbimShapeInstance.InstanceLabel);
                            binaryStream.Write((Int32) xbimShapeInstance.StyleLabel > 0
                                ? xbimShapeInstance.StyleLabel
                                : xbimShapeInstance.IfcTypeId*-1);
                            binaryStream.Write(xbimShapeInstance.Transformation);
                            numberOfTriangles +=
                                XbimShapeTriangulation.TriangleCount(((IXbimShapeGeometryData) geometry).ShapeData);
                            numberOfMatrices++;
                        }
                        numberOfVertices +=
                            XbimShapeTriangulation.VerticesCount(((IXbimShapeGeometryData) geometry).ShapeData);
                        // binaryStream.Write(geometry.ShapeData);
                        var ms = new MemoryStream(((IXbimShapeGeometryData) geometry).ShapeData);
                        var br = new BinaryReader(ms);
                        var tr = br.ReadShapeTriangulation();

                        tr.Write(binaryStream);
                    }
                    else if (geometry.ReferenceCount == 1)//now do the single instances
                    {
                        var xbimShapeInstance = geomRead.ShapeInstancesOfGeometry(geometry.ShapeLabel).FirstOrDefault();

                        if (xbimShapeInstance == null || xbimShapeInstance.IfcTypeId == openingElementId ||
                            xbimShapeInstance.RepresentationType != XbimGeometryRepresentationType.OpeningsAndAdditionsIncluded)                           
                            continue;
                        numberOfGeometries++;

                        // IXbimShapeGeometryData geometry = ShapeGeometry(kv.Key);
                        binaryStream.Write((Int32)1); //the number of repetitions of the geometry (1)


                        binaryStream.Write((Int32)xbimShapeInstance.IfcProductLabel);
                        binaryStream.Write((UInt16)xbimShapeInstance.IfcTypeId);
                        binaryStream.Write((Int32)xbimShapeInstance.InstanceLabel);
                        binaryStream.Write((Int32)xbimShapeInstance.StyleLabel > 0
                            ? xbimShapeInstance.StyleLabel
                            : xbimShapeInstance.IfcTypeId * -1);

                        //Read all vertices and normals in the geometry stream and transform
                        if (geometry.ShapeData.Length <= 0)
                            continue;
                        var ms = new MemoryStream(((IXbimShapeGeometryData)geometry).ShapeData);
                        var br = new BinaryReader(ms);
                        var tr = br.ReadShapeTriangulation();
                        var trTransformed = tr.Transform(((XbimShapeInstance)xbimShapeInstance).Transformation);
                        trTransformed.Write(binaryStream);
                        numberOfTriangles += XbimShapeTriangulation.TriangleCount(((IXbimShapeGeometryData)geometry).ShapeData);
                        numberOfVertices += XbimShapeTriangulation.VerticesCount(((IXbimShapeGeometryData)geometry).ShapeData);
                    }
                }
                
                
                binaryStream.Seek(start, SeekOrigin.Begin);
                binaryStream.Write((Int32) numberOfGeometries);
                binaryStream.Write((Int32) numberOfVertices);
                binaryStream.Write((Int32) numberOfTriangles);
                binaryStream.Write((Int32) numberOfMatrices);
                binaryStream.Write((Int32) numberOfProducts);
                binaryStream.Seek(0, SeekOrigin.End); //go back to end
                // ReSharper restore RedundantCast
            }
        }

        public const int WexBimId = 94132117;

        /// <summary>
        /// Calculates and sets the model factors, call everytime a unit of measurement is changed
        /// </summary>
        public void CalculateModelFactors()
        {
            double angleToRadiansConversionFactor = 1; //assume radians
            double lengthToMetresConversionFactor = 1; //assume metres
            var instOfType = Instances.OfType<IIfcUnitAssignment>();
            var ua = instOfType.FirstOrDefault();
            if (ua != null)
            {
                foreach (var unit in ua.Units)
                {
                    var value = 1.0;
                    var cbUnit = unit as IIfcConversionBasedUnit;
                    var siUnit = unit as IIfcSIUnit;
                    if (cbUnit != null)
                    {
                        var mu = cbUnit.ConversionFactor;
                        var component = mu.UnitComponent as IIfcSIUnit;
                        if (component != null)
                            siUnit = component;
                        var et = ((IExpressValueType)mu.ValueComponent);

                        if (et.UnderlyingSystemType == typeof(double))
                            value *= (double)et.Value;
                        else if (et.UnderlyingSystemType == typeof(int))
                            value *= (int)et.Value;
                        else if (et.UnderlyingSystemType == typeof(long))
                            value *= (long)et.Value;
                    }
                    if (siUnit == null) continue;
                    value *= siUnit.Power;
                    switch (siUnit.UnitType)
                    {
                        case IfcUnitEnum.LENGTHUNIT:
                            lengthToMetresConversionFactor = value;
                            break;
                        case IfcUnitEnum.PLANEANGLEUNIT:
                            angleToRadiansConversionFactor = value;
                            //need to guarantee precision to avoid errors in boolean operations
                            if (Math.Abs(angleToRadiansConversionFactor - (Math.PI / 180)) < 1e-9)
                                angleToRadiansConversionFactor = Math.PI / 180;
                            break;
                    }
                }
            }

            var gcs =
                Instances.OfType<IIfcGeometricRepresentationContext>();
            double defaultPrecision = 1e-5;
            //get the Model precision if it is correctly defined
            foreach (var gc in gcs.Where(g => !(g is IIfcGeometricRepresentationSubContext)))
            {
                if (!gc.ContextType.HasValue || string.Compare(gc.ContextType.Value, "model", true) != 0) continue;
                if (!gc.Precision.HasValue) continue;
                defaultPrecision = gc.Precision.Value;
                break;
            }
         
            //check if angle units are incorrectly defined, this happens in some old models
            if (Math.Abs(angleToRadiansConversionFactor - 1) < 1e-10)
            {
                var trimmed = Instances.Where<IIfcTrimmedCurve>(trimmedCurve =>trimmedCurve.BasisCurve is IIfcConic);
                foreach (var trimmedCurve in trimmed)
                {
                    if (trimmedCurve.MasterRepresentation != IfcTrimmingPreference.PARAMETER)
                        continue;
                    if (
                        !trimmedCurve.Trim1.Concat(trimmedCurve.Trim2)
                            .OfType<Ifc4.MeasureResource.IfcParameterValue>()
                            .Select(trim => (double)trim.Value)
                            .Any(val => val > Math.PI * 2)) continue;
                    angleToRadiansConversionFactor = Math.PI / 180;
                    break;
                }
            }
            ModelFactors.Initialise(angleToRadiansConversionFactor, lengthToMetresConversionFactor,
                defaultPrecision);
        }

       
        
    }

}