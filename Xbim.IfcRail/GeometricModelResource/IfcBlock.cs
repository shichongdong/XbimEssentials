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
	[ExpressType("IfcBlock", 465)]
	// ReSharper disable once PartialTypeWithSinglePart
	public  partial class @IfcBlock : IfcCsgPrimitive3D, IInstantiableEntity, IContainsEntityReferences, IEquatable<@IfcBlock>
	{

		//internal constructor makes sure that objects are not created outside of the model/ assembly controlled area
		internal IfcBlock(IModel model, int label, bool activated) : base(model, label, activated)  
		{
		}

		#region Explicit attribute fields
		private IfcPositiveLengthMeasure _xLength;
		private IfcPositiveLengthMeasure _yLength;
		private IfcPositiveLengthMeasure _zLength;
		#endregion
	
		#region Explicit attribute properties
		[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
		public IfcPositiveLengthMeasure @XLength 
		{ 
			get 
			{
				if(_activated) return _xLength;
				Activate();
				return _xLength;
			} 
			set
			{
				SetValue( v =>  _xLength = v, _xLength, value,  "XLength", 2);
			} 
		}	
		[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
		public IfcPositiveLengthMeasure @YLength 
		{ 
			get 
			{
				if(_activated) return _yLength;
				Activate();
				return _yLength;
			} 
			set
			{
				SetValue( v =>  _yLength = v, _yLength, value,  "YLength", 3);
			} 
		}	
		[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
		public IfcPositiveLengthMeasure @ZLength 
		{ 
			get 
			{
				if(_activated) return _zLength;
				Activate();
				return _zLength;
			} 
			set
			{
				SetValue( v =>  _zLength = v, _zLength, value,  "ZLength", 4);
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
					_xLength = value.RealVal;
					return;
				case 2: 
					_yLength = value.RealVal;
					return;
				case 3: 
					_zLength = value.RealVal;
					return;
				default:
					throw new XbimParserException(string.Format("Attribute index {0} is out of range for {1}", propIndex + 1, GetType().Name.ToUpper()));
			}
		}
		#endregion

		#region Equality comparers and operators
        public bool Equals(@IfcBlock other)
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