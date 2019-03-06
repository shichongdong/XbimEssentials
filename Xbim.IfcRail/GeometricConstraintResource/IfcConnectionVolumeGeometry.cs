// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool Xbim.CodeGeneration 
//  
//     Changes to this file may cause incorrect behaviour and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.IfcRail.GeometricConstraintResource;
//## Custom using statements
//##


namespace Xbim.IfcRail.GeometricConstraintResource
{
	[ExpressType("IfcConnectionVolumeGeometry", 556)]
	// ReSharper disable once PartialTypeWithSinglePart
	public  partial class @IfcConnectionVolumeGeometry : IfcConnectionGeometry, IInstantiableEntity, IContainsEntityReferences, IEquatable<@IfcConnectionVolumeGeometry>
	{

		//internal constructor makes sure that objects are not created outside of the model/ assembly controlled area
		internal IfcConnectionVolumeGeometry(IModel model, int label, bool activated) : base(model, label, activated)  
		{
		}

		#region Explicit attribute fields
		private IfcSolidOrShell _volumeOnRelatingElement;
		private IfcSolidOrShell _volumeOnRelatedElement;
		#endregion
	
		#region Explicit attribute properties
		[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 1)]
		public IfcSolidOrShell @VolumeOnRelatingElement 
		{ 
			get 
			{
				if(_activated) return _volumeOnRelatingElement;
				Activate();
				return _volumeOnRelatingElement;
			} 
			set
			{
				if (value != null && !(ReferenceEquals(Model, value.Model)))
					throw new XbimException("Cross model entity assignment.");
				SetValue( v =>  _volumeOnRelatingElement = v, _volumeOnRelatingElement, value,  "VolumeOnRelatingElement", 1);
			} 
		}	
		[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 2)]
		public IfcSolidOrShell @VolumeOnRelatedElement 
		{ 
			get 
			{
				if(_activated) return _volumeOnRelatedElement;
				Activate();
				return _volumeOnRelatedElement;
			} 
			set
			{
				if (value != null && !(ReferenceEquals(Model, value.Model)))
					throw new XbimException("Cross model entity assignment.");
				SetValue( v =>  _volumeOnRelatedElement = v, _volumeOnRelatedElement, value,  "VolumeOnRelatedElement", 2);
			} 
		}	
		#endregion




		#region IPersist implementation
		public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
		{
			switch (propIndex)
			{
				case 0: 
					_volumeOnRelatingElement = (IfcSolidOrShell)(value.EntityVal);
					return;
				case 1: 
					_volumeOnRelatedElement = (IfcSolidOrShell)(value.EntityVal);
					return;
				default:
					throw new XbimParserException(string.Format("Attribute index {0} is out of range for {1}", propIndex + 1, GetType().Name.ToUpper()));
			}
		}
		#endregion

		#region Equality comparers and operators
        public bool Equals(@IfcConnectionVolumeGeometry other)
	    {
	        return this == other;
	    }
        #endregion

		#region IContainsEntityReferences
		IEnumerable<IPersistEntity> IContainsEntityReferences.References 
		{
			get 
			{
				if (@VolumeOnRelatingElement != null)
					yield return @VolumeOnRelatingElement;
				if (@VolumeOnRelatedElement != null)
					yield return @VolumeOnRelatedElement;
			}
		}
		#endregion

		#region Custom code (will survive code regeneration)
		//## Custom code
		//##
		#endregion
	}
}