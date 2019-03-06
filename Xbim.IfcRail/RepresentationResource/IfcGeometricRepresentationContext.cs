// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool Xbim.CodeGeneration 
//  
//     Changes to this file may cause incorrect behaviour and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------

using Xbim.IfcRail.GeometryResource;
using Xbim.IfcRail.MeasureResource;
using System;
using System.Collections.Generic;
using System.Linq;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.IfcRail.RepresentationResource;
//## Custom using statements
//##


namespace Xbim.IfcRail.RepresentationResource
{
	[ExpressType("IfcGeometricRepresentationContext", 739)]
	// ReSharper disable once PartialTypeWithSinglePart
	public  partial class @IfcGeometricRepresentationContext : IfcRepresentationContext, IInstantiableEntity, IfcCoordinateReferenceSystemSelect, IContainsEntityReferences, IEquatable<@IfcGeometricRepresentationContext>
	{

		//internal constructor makes sure that objects are not created outside of the model/ assembly controlled area
		internal IfcGeometricRepresentationContext(IModel model, int label, bool activated) : base(model, label, activated)  
		{
		}

		#region Explicit attribute fields
		private IfcDimensionCount _coordinateSpaceDimension;
		private IfcReal? _precision;
		private IfcAxis2Placement _worldCoordinateSystem;
		private IfcDirection _trueNorth;
		#endregion
	
		#region Explicit attribute properties
		[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
		public virtual IfcDimensionCount @CoordinateSpaceDimension 
		{ 
			get 
			{
				if(_activated) return _coordinateSpaceDimension;
				Activate();
				return _coordinateSpaceDimension;
			} 
			set
			{
				SetValue( v =>  _coordinateSpaceDimension = v, _coordinateSpaceDimension, value,  "CoordinateSpaceDimension", 3);
			} 
		}	
		[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
		public virtual IfcReal? @Precision 
		{ 
			get 
			{
				if(_activated) return _precision;
				Activate();
				return _precision;
			} 
			set
			{
				SetValue( v =>  _precision = v, _precision, value,  "Precision", 4);
			} 
		}	
		[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 6)]
		public virtual IfcAxis2Placement @WorldCoordinateSystem 
		{ 
			get 
			{
				if(_activated) return _worldCoordinateSystem;
				Activate();
				return _worldCoordinateSystem;
			} 
			set
			{
				if (value != null && !(ReferenceEquals(Model, value.Model)))
					throw new XbimException("Cross model entity assignment.");
				SetValue( v =>  _worldCoordinateSystem = v, _worldCoordinateSystem, value,  "WorldCoordinateSystem", 5);
			} 
		}	
		[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 7)]
		public virtual IfcDirection @TrueNorth 
		{ 
			get 
			{
				if(_activated) return _trueNorth;
				Activate();
				return _trueNorth;
			} 
			set
			{
				if (value != null && !(ReferenceEquals(Model, value.Model)))
					throw new XbimException("Cross model entity assignment.");
				SetValue( v =>  _trueNorth = v, _trueNorth, value,  "TrueNorth", 6);
			} 
		}	
		#endregion



		#region Inverse attributes
		[InverseProperty("ParentContext")]
		[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int [] { 0 }, new int [] { -1 }, 8)]
		public IEnumerable<IfcGeometricRepresentationSubContext> @HasSubContexts 
		{ 
			get 
			{
				return Model.Instances.Where<IfcGeometricRepresentationSubContext>(e => Equals(e.ParentContext), "ParentContext", this);
			} 
		}
		[InverseProperty("SourceCRS")]
		[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int [] { 0 }, new int [] { 1 }, 9)]
		public IEnumerable<IfcCoordinateOperation> @HasCoordinateOperation 
		{ 
			get 
			{
				return Model.Instances.Where<IfcCoordinateOperation>(e => Equals(e.SourceCRS), "SourceCRS", this);
			} 
		}
		#endregion

		#region IPersist implementation
		public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
		{
			switch (propIndex)
			{
				case 0: 
				case 1: 
					base.Parse(propIndex, value, nestedIndex); 
					return;
				case 2: 
					_coordinateSpaceDimension = value.IntegerVal;
					return;
				case 3: 
					_precision = value.RealVal;
					return;
				case 4: 
					_worldCoordinateSystem = (IfcAxis2Placement)(value.EntityVal);
					return;
				case 5: 
					_trueNorth = (IfcDirection)(value.EntityVal);
					return;
				default:
					throw new XbimParserException(string.Format("Attribute index {0} is out of range for {1}", propIndex + 1, GetType().Name.ToUpper()));
			}
		}
		#endregion

		#region Equality comparers and operators
        public bool Equals(@IfcGeometricRepresentationContext other)
	    {
	        return this == other;
	    }
        #endregion

		#region IContainsEntityReferences
		IEnumerable<IPersistEntity> IContainsEntityReferences.References 
		{
			get 
			{
				if (@WorldCoordinateSystem != null)
					yield return @WorldCoordinateSystem;
				if (@TrueNorth != null)
					yield return @TrueNorth;
			}
		}
		#endregion

		#region Custom code (will survive code regeneration)
		//## Custom code
		//##
		#endregion
	}
}