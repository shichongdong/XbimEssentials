// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool Xbim.CodeGeneration 
//  
//     Changes to this file may cause incorrect behaviour and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------

using Xbim.IfcRail.Kernel;
using Xbim.IfcRail.MeasureResource;
using System;
using System.Collections.Generic;
using System.Linq;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.IfcRail.SharedMgmtElements;
//## Custom using statements
//##


namespace Xbim.IfcRail.SharedMgmtElements
{
	[ExpressType("IfcPermit", 853)]
	// ReSharper disable once PartialTypeWithSinglePart
	public  partial class @IfcPermit : IfcControl, IInstantiableEntity, IContainsEntityReferences, IEquatable<@IfcPermit>
	{

		//internal constructor makes sure that objects are not created outside of the model/ assembly controlled area
		internal IfcPermit(IModel model, int label, bool activated) : base(model, label, activated)  
		{
		}

		#region Explicit attribute fields
		private IfcPermitTypeEnum? _predefinedType;
		private IfcLabel? _status;
		private IfcText? _longDescription;
		#endregion
	
		#region Explicit attribute properties
		[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 19)]
		public IfcPermitTypeEnum? @PredefinedType 
		{ 
			get 
			{
				if(_activated) return _predefinedType;
				Activate();
				return _predefinedType;
			} 
			set
			{
				SetValue( v =>  _predefinedType = v, _predefinedType, value,  "PredefinedType", 7);
			} 
		}	
		[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 20)]
		public IfcLabel? @Status 
		{ 
			get 
			{
				if(_activated) return _status;
				Activate();
				return _status;
			} 
			set
			{
				SetValue( v =>  _status = v, _status, value,  "Status", 8);
			} 
		}	
		[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 21)]
		public IfcText? @LongDescription 
		{ 
			get 
			{
				if(_activated) return _longDescription;
				Activate();
				return _longDescription;
			} 
			set
			{
				SetValue( v =>  _longDescription = v, _longDescription, value,  "LongDescription", 9);
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
				case 2: 
				case 3: 
				case 4: 
				case 5: 
					base.Parse(propIndex, value, nestedIndex); 
					return;
				case 6: 
                    _predefinedType = (IfcPermitTypeEnum) System.Enum.Parse(typeof (IfcPermitTypeEnum), value.EnumVal, true);
					return;
				case 7: 
					_status = value.StringVal;
					return;
				case 8: 
					_longDescription = value.StringVal;
					return;
				default:
					throw new XbimParserException(string.Format("Attribute index {0} is out of range for {1}", propIndex + 1, GetType().Name.ToUpper()));
			}
		}
		#endregion

		#region Equality comparers and operators
        public bool Equals(@IfcPermit other)
	    {
	        return this == other;
	    }
        #endregion

		#region IContainsEntityReferences
		IEnumerable<IPersistEntity> IContainsEntityReferences.References 
		{
			get 
			{
				if (@OwnerHistory != null)
					yield return @OwnerHistory;
			}
		}
		#endregion

		#region Custom code (will survive code regeneration)
		//## Custom code
		//##
		#endregion
	}
}