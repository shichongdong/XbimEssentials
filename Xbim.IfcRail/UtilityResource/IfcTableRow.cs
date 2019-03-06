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
using System.ComponentModel;
using Xbim.Common.Metadata;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.IfcRail.UtilityResource;
//## Custom using statements
//##


namespace Xbim.IfcRail.UtilityResource
{
	[ExpressType("IfcTableRow", 1146)]
	// ReSharper disable once PartialTypeWithSinglePart
	public  partial class @IfcTableRow : PersistEntity, IInstantiableEntity, IEquatable<@IfcTableRow>
	{

		//internal constructor makes sure that objects are not created outside of the model/ assembly controlled area
		internal IfcTableRow(IModel model, int label, bool activated) : base(model, label, activated)  
		{
			_rowCells = new OptionalItemSet<IfcValue>( this, 0,  1);
		}

		#region Explicit attribute fields
		private readonly OptionalItemSet<IfcValue> _rowCells;
		private IfcBoolean? _isHeading;
		#endregion
	
		#region Explicit attribute properties
		[EntityAttribute(1, EntityAttributeState.Optional, EntityAttributeType.List, EntityAttributeType.Class, new int [] { 1 }, new int [] { -1 }, 1)]
		public IOptionalItemSet<IfcValue> @RowCells 
		{ 
			get 
			{
				if(_activated) return _rowCells;
				Activate();
				return _rowCells;
			} 
		}	
		[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
		public IfcBoolean? @IsHeading 
		{ 
			get 
			{
				if(_activated) return _isHeading;
				Activate();
				return _isHeading;
			} 
			set
			{
				SetValue( v =>  _isHeading = v, _isHeading, value,  "IsHeading", 2);
			} 
		}	
		#endregion




		#region IPersist implementation
		public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
		{
			switch (propIndex)
			{
				case 0: 
					_rowCells.InternalAdd((IfcValue)value.EntityVal);
					return;
				case 1: 
					_isHeading = value.BooleanVal;
					return;
				default:
					throw new XbimParserException(string.Format("Attribute index {0} is out of range for {1}", propIndex + 1, GetType().Name.ToUpper()));
			}
		}
		#endregion

		#region Equality comparers and operators
        public bool Equals(@IfcTableRow other)
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