// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool Xbim.CodeGeneration 
//  
//     Changes to this file may cause incorrect behaviour and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------

using Xbim.IfcRail.Kernel;
using Xbim.IfcRail.DateTimeResource;
using Xbim.IfcRail.MeasureResource;
using System;
using System.Collections.Generic;
using System.Linq;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.IfcRail.ProcessExtension;
//## Custom using statements
//##


namespace Xbim.IfcRail.ProcessExtension
{
	[ExpressType("IfcRelSequence", 1005)]
	// ReSharper disable once PartialTypeWithSinglePart
	public  partial class @IfcRelSequence : IfcRelConnects, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<@IfcRelSequence>
	{

		//internal constructor makes sure that objects are not created outside of the model/ assembly controlled area
		internal IfcRelSequence(IModel model, int label, bool activated) : base(model, label, activated)  
		{
		}

		#region Explicit attribute fields
		private IfcProcess _relatingProcess;
		private IfcProcess _relatedProcess;
		private IfcLagTime _timeLag;
		private IfcSequenceEnum? _sequenceType;
		private IfcLabel? _userDefinedSequenceType;
		#endregion
	
		#region Explicit attribute properties
		[IndexedProperty]
		[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 5)]
		public IfcProcess @RelatingProcess 
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
				SetValue( v =>  _relatingProcess = v, _relatingProcess, value,  "RelatingProcess", 5);
			} 
		}	
		[IndexedProperty]
		[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 6)]
		public IfcProcess @RelatedProcess 
		{ 
			get 
			{
				if(_activated) return _relatedProcess;
				Activate();
				return _relatedProcess;
			} 
			set
			{
				if (value != null && !(ReferenceEquals(Model, value.Model)))
					throw new XbimException("Cross model entity assignment.");
				SetValue( v =>  _relatedProcess = v, _relatedProcess, value,  "RelatedProcess", 6);
			} 
		}	
		[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 7)]
		public IfcLagTime @TimeLag 
		{ 
			get 
			{
				if(_activated) return _timeLag;
				Activate();
				return _timeLag;
			} 
			set
			{
				if (value != null && !(ReferenceEquals(Model, value.Model)))
					throw new XbimException("Cross model entity assignment.");
				SetValue( v =>  _timeLag = v, _timeLag, value,  "TimeLag", 7);
			} 
		}	
		[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 8)]
		public IfcSequenceEnum? @SequenceType 
		{ 
			get 
			{
				if(_activated) return _sequenceType;
				Activate();
				return _sequenceType;
			} 
			set
			{
				SetValue( v =>  _sequenceType = v, _sequenceType, value,  "SequenceType", 8);
			} 
		}	
		[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 9)]
		public IfcLabel? @UserDefinedSequenceType 
		{ 
			get 
			{
				if(_activated) return _userDefinedSequenceType;
				Activate();
				return _userDefinedSequenceType;
			} 
			set
			{
				SetValue( v =>  _userDefinedSequenceType = v, _userDefinedSequenceType, value,  "UserDefinedSequenceType", 9);
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
					base.Parse(propIndex, value, nestedIndex); 
					return;
				case 4: 
					_relatingProcess = (IfcProcess)(value.EntityVal);
					return;
				case 5: 
					_relatedProcess = (IfcProcess)(value.EntityVal);
					return;
				case 6: 
					_timeLag = (IfcLagTime)(value.EntityVal);
					return;
				case 7: 
                    _sequenceType = (IfcSequenceEnum) System.Enum.Parse(typeof (IfcSequenceEnum), value.EnumVal, true);
					return;
				case 8: 
					_userDefinedSequenceType = value.StringVal;
					return;
				default:
					throw new XbimParserException(string.Format("Attribute index {0} is out of range for {1}", propIndex + 1, GetType().Name.ToUpper()));
			}
		}
		#endregion

		#region Equality comparers and operators
        public bool Equals(@IfcRelSequence other)
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
				if (@RelatingProcess != null)
					yield return @RelatingProcess;
				if (@RelatedProcess != null)
					yield return @RelatedProcess;
				if (@TimeLag != null)
					yield return @TimeLag;
			}
		}
		#endregion


		#region IContainsIndexedReferences
        IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences 
		{ 
			get
			{
				if (@RelatingProcess != null)
					yield return @RelatingProcess;
				if (@RelatedProcess != null)
					yield return @RelatedProcess;
				
			} 
		}
		#endregion

		#region Custom code (will survive code regeneration)
		//## Custom code
		//##
		#endregion
	}
}