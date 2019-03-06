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
using Xbim.IfcRail.GeometricConstraintResource;
//## Custom using statements
//##


namespace Xbim.IfcRail.GeometricConstraintResource
{
	[ExpressType("IfcAlignment2DSegment", 432)]
	// ReSharper disable once PartialTypeWithSinglePart
	public abstract partial class @IfcAlignment2DSegment : IfcGeometricRepresentationItem, IEquatable<@IfcAlignment2DSegment>
	{

		//internal constructor makes sure that objects are not created outside of the model/ assembly controlled area
		internal IfcAlignment2DSegment(IModel model, int label, bool activated) : base(model, label, activated)  
		{
		}

		#region Explicit attribute fields
		private IfcBoolean? _tangentialContinuity;
		private IfcLabel? _startTag;
		private IfcLabel? _endTag;
		#endregion
	
		#region Explicit attribute properties
		[EntityAttribute(1, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
		public IfcBoolean? @TangentialContinuity 
		{ 
			get 
			{
				if(_activated) return _tangentialContinuity;
				Activate();
				return _tangentialContinuity;
			} 
			set
			{
				SetValue( v =>  _tangentialContinuity = v, _tangentialContinuity, value,  "TangentialContinuity", 1);
			} 
		}	
		[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
		public IfcLabel? @StartTag 
		{ 
			get 
			{
				if(_activated) return _startTag;
				Activate();
				return _startTag;
			} 
			set
			{
				SetValue( v =>  _startTag = v, _startTag, value,  "StartTag", 2);
			} 
		}	
		[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
		public IfcLabel? @EndTag 
		{ 
			get 
			{
				if(_activated) return _endTag;
				Activate();
				return _endTag;
			} 
			set
			{
				SetValue( v =>  _endTag = v, _endTag, value,  "EndTag", 3);
			} 
		}	
		#endregion




		#region IPersist implementation
		public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
		{
			switch (propIndex)
			{
				case 0: 
					_tangentialContinuity = value.BooleanVal;
					return;
				case 1: 
					_startTag = value.StringVal;
					return;
				case 2: 
					_endTag = value.StringVal;
					return;
				default:
					throw new XbimParserException(string.Format("Attribute index {0} is out of range for {1}", propIndex + 1, GetType().Name.ToUpper()));
			}
		}
		#endregion

		#region Equality comparers and operators
        public bool Equals(@IfcAlignment2DSegment other)
	    {
	        return this == other;
	    }
        #endregion

		#region Custom code (will survive code regeneration)
		//## Custom code
		//##
		#endregion
	}
}