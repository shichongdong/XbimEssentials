// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool Xbim.CodeGeneration 
//  
//     Changes to this file may cause incorrect behaviour and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------

using Xbim.IfcRail.MeasureResource;
using System;
using System.Collections.Generic;
using System.Linq;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.IfcRail.GeometricModelResource;
//## Custom using statements
//##


namespace Xbim.IfcRail.GeometricModelResource
{
	[ExpressType("IfcRightCircularCone", 1024)]
	// ReSharper disable once PartialTypeWithSinglePart
	public  partial class @IfcRightCircularCone : IfcCsgPrimitive3D, IInstantiableEntity, IContainsEntityReferences, IEquatable<@IfcRightCircularCone>
	{

		//internal constructor makes sure that objects are not created outside of the model/ assembly controlled area
		internal IfcRightCircularCone(IModel model, int label, bool activated) : base(model, label, activated)  
		{
		}

		#region Explicit attribute fields
		private IfcPositiveLengthMeasure _height;
		private IfcPositiveLengthMeasure _bottomRadius;
		#endregion
	
		#region Explicit attribute properties
		[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
		public IfcPositiveLengthMeasure @Height 
		{ 
			get 
			{
				if(_activated) return _height;
				Activate();
				return _height;
			} 
			set
			{
				SetValue( v =>  _height = v, _height, value,  "Height", 2);
			} 
		}	
		[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
		public IfcPositiveLengthMeasure @BottomRadius 
		{ 
			get 
			{
				if(_activated) return _bottomRadius;
				Activate();
				return _bottomRadius;
			} 
			set
			{
				SetValue( v =>  _bottomRadius = v, _bottomRadius, value,  "BottomRadius", 3);
			} 
		}	
		#endregion




		#region IPersist implementation
		public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
		{
			switch (propIndex)
			{
				case 0: 
					base.Parse(propIndex, value, nestedIndex); 
					return;
				case 1: 
					_height = value.RealVal;
					return;
				case 2: 
					_bottomRadius = value.RealVal;
					return;
				default:
					throw new XbimParserException(string.Format("Attribute index {0} is out of range for {1}", propIndex + 1, GetType().Name.ToUpper()));
			}
		}
		#endregion

		#region Equality comparers and operators
        public bool Equals(@IfcRightCircularCone other)
	    {
	        return this == other;
	    }
        #endregion

		#region IContainsEntityReferences
		IEnumerable<IPersistEntity> IContainsEntityReferences.References 
		{
			get 
			{
				if (@Position != null)
					yield return @Position;
			}
		}
		#endregion

		#region Custom code (will survive code regeneration)
		//## Custom code
		//##
		#endregion
	}
}