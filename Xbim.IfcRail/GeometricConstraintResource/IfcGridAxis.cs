// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool Xbim.CodeGeneration 
//  
//     Changes to this file may cause incorrect behaviour and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------

using Xbim.IfcRail.MeasureResource;
using Xbim.IfcRail.GeometryResource;
using Xbim.IfcRail.ProductExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using Xbim.Common.Metadata;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.IfcRail.GeometricConstraintResource;
//## Custom using statements
//##


namespace Xbim.IfcRail.GeometricConstraintResource
{
	[ExpressType("IfcGridAxis", 744)]
	// ReSharper disable once PartialTypeWithSinglePart
	public  partial class @IfcGridAxis : PersistEntity, IInstantiableEntity, IContainsEntityReferences, IEquatable<@IfcGridAxis>
	{

		//internal constructor makes sure that objects are not created outside of the model/ assembly controlled area
		internal IfcGridAxis(IModel model, int label, bool activated) : base(model, label, activated)  
		{
		}

		#region Explicit attribute fields
		private IfcLabel? _axisTag;
		private IfcCurve _axisCurve;
		private IfcBoolean _sameSense;
		#endregion
	
		#region Explicit attribute properties
		[EntityAttribute(1, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 1)]
		public IfcLabel? @AxisTag 
		{ 
			get 
			{
				if(_activated) return _axisTag;
				Activate();
				return _axisTag;
			} 
			set
			{
				SetValue( v =>  _axisTag = v, _axisTag, value,  "AxisTag", 1);
			} 
		}	
		[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 2)]
		public IfcCurve @AxisCurve 
		{ 
			get 
			{
				if(_activated) return _axisCurve;
				Activate();
				return _axisCurve;
			} 
			set
			{
				if (value != null && !(ReferenceEquals(Model, value.Model)))
					throw new XbimException("Cross model entity assignment.");
				SetValue( v =>  _axisCurve = v, _axisCurve, value,  "AxisCurve", 2);
			} 
		}	
		[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
		public IfcBoolean @SameSense 
		{ 
			get 
			{
				if(_activated) return _sameSense;
				Activate();
				return _sameSense;
			} 
			set
			{
				SetValue( v =>  _sameSense = v, _sameSense, value,  "SameSense", 3);
			} 
		}	
		#endregion



		#region Inverse attributes
		[InverseProperty("WAxes")]
		[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int [] { 0 }, new int [] { 1 }, 4)]
		public IEnumerable<IfcGrid> @PartOfW 
		{ 
			get 
			{
				return Model.Instances.Where<IfcGrid>(e => e.WAxes != null &&  e.WAxes.Contains(this), "WAxes", this);
			} 
		}
		[InverseProperty("VAxes")]
		[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int [] { 0 }, new int [] { 1 }, 5)]
		public IEnumerable<IfcGrid> @PartOfV 
		{ 
			get 
			{
				return Model.Instances.Where<IfcGrid>(e => e.VAxes != null &&  e.VAxes.Contains(this), "VAxes", this);
			} 
		}
		[InverseProperty("UAxes")]
		[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int [] { 0 }, new int [] { 1 }, 6)]
		public IEnumerable<IfcGrid> @PartOfU 
		{ 
			get 
			{
				return Model.Instances.Where<IfcGrid>(e => e.UAxes != null &&  e.UAxes.Contains(this), "UAxes", this);
			} 
		}
		[InverseProperty("IntersectingAxes")]
		[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int [] { 0 }, new int [] { -1 }, 7)]
		public IEnumerable<IfcVirtualGridIntersection> @HasIntersections 
		{ 
			get 
			{
				return Model.Instances.Where<IfcVirtualGridIntersection>(e => e.IntersectingAxes != null &&  e.IntersectingAxes.Contains(this), "IntersectingAxes", this);
			} 
		}
		#endregion

		#region IPersist implementation
		public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
		{
			switch (propIndex)
			{
				case 0: 
					_axisTag = value.StringVal;
					return;
				case 1: 
					_axisCurve = (IfcCurve)(value.EntityVal);
					return;
				case 2: 
					_sameSense = value.BooleanVal;
					return;
				default:
					throw new XbimParserException(string.Format("Attribute index {0} is out of range for {1}", propIndex + 1, GetType().Name.ToUpper()));
			}
		}
		#endregion

		#region Equality comparers and operators
        public bool Equals(@IfcGridAxis other)
	    {
	        return this == other;
	    }
        #endregion

		#region IContainsEntityReferences
		IEnumerable<IPersistEntity> IContainsEntityReferences.References 
		{
			get 
			{
				if (@AxisCurve != null)
					yield return @AxisCurve;
			}
		}
		#endregion

		#region Custom code (will survive code regeneration)
		//## Custom code
		//##
		#endregion
	}
}