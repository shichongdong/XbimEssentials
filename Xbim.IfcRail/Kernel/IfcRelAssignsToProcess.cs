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
using Xbim.IfcRail.Kernel;
//## Custom using statements
//##


namespace Xbim.IfcRail.Kernel
{
	[ExpressType("IfcRelAssignsToProcess", 969)]
	// ReSharper disable once PartialTypeWithSinglePart
	public  partial class @IfcRelAssignsToProcess : IfcRelAssigns, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<@IfcRelAssignsToProcess>
	{

		//internal constructor makes sure that objects are not created outside of the model/ assembly controlled area
		internal IfcRelAssignsToProcess(IModel model, int label, bool activated) : base(model, label, activated)  
		{
		}

		#region Explicit attribute fields
		private IfcProcessSelect _relatingProcess;
		private IfcMeasureWithUnit _quantityInProcess;
		#endregion
	
		#region Explicit attribute properties
		[IndexedProperty]
		[EntityAttribute(7, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 7)]
		public IfcProcessSelect @RelatingProcess 
		{ 
			get 
			{
				if(_activated) return _relatingProcess;
				Activate();
				return _relatingProcess;
			} 
			set
			{
				if (value != null && !(ReferenceEquals(Model, value.Model)))
					throw new XbimException("Cross model entity assignment.");
				SetValue( v =>  _relatingProcess = v, _relatingProcess, value,  "RelatingProcess", 7);
			} 
		}	
		[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 8)]
		public IfcMeasureWithUnit @QuantityInProcess 
		{ 
			get 
			{
				if(_activated) return _quantityInProcess;
				Activate();
				return _quantityInProcess;
			} 
			set
			{
				if (value != null && !(ReferenceEquals(Model, value.Model)))
					throw new XbimException("Cross model entity assignment.");
				SetValue( v =>  _quantityInProcess = v, _quantityInProcess, value,  "QuantityInProcess", 8);
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
					_relatingProcess = (IfcProcessSelect)(value.EntityVal);
					return;
				case 7: 
					_quantityInProcess = (IfcMeasureWithUnit)(value.EntityVal);
					return;
				default:
					throw new XbimParserException(string.Format("Attribute index {0} is out of range for {1}", propIndex + 1, GetType().Name.ToUpper()));
			}
		}
		#endregion

		#region Equality comparers and operators
        public bool Equals(@IfcRelAssignsToProcess other)
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
				foreach(var entity in @RelatedObjects)
					yield return entity;
				if (@RelatingProcess != null)
					yield return @RelatingProcess;
				if (@QuantityInProcess != null)
					yield return @QuantityInProcess;
			}
		}
		#endregion


		#region IContainsIndexedReferences
        IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences 
		{ 
			get
			{
				foreach(var entity in @RelatedObjects)
					yield return entity;
				if (@RelatingProcess != null)
					yield return @RelatingProcess;
				
			} 
		}
		#endregion

		#region Custom code (will survive code regeneration)
		//## Custom code
		//##
		#endregion
	}
}