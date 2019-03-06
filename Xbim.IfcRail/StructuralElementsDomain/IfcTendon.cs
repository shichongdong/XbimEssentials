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
using Xbim.IfcRail.StructuralElementsDomain;
//## Custom using statements
//##


namespace Xbim.IfcRail.StructuralElementsDomain
{
	[ExpressType("IfcTendon", 1154)]
	// ReSharper disable once PartialTypeWithSinglePart
	public  partial class @IfcTendon : IfcReinforcingElement, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<@IfcTendon>
	{

		//internal constructor makes sure that objects are not created outside of the model/ assembly controlled area
		internal IfcTendon(IModel model, int label, bool activated) : base(model, label, activated)  
		{
		}

		#region Explicit attribute fields
		private IfcTendonTypeEnum? _predefinedType;
		private IfcPositiveLengthMeasure? _nominalDiameter;
		private IfcAreaMeasure? _crossSectionArea;
		private IfcForceMeasure? _tensionForce;
		private IfcPressureMeasure? _preStress;
		private IfcNormalisedRatioMeasure? _frictionCoefficient;
		private IfcPositiveLengthMeasure? _anchorageSlip;
		private IfcPositiveLengthMeasure? _minCurvatureRadius;
		#endregion
	
		#region Explicit attribute properties
		[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 35)]
		public IfcTendonTypeEnum? @PredefinedType 
		{ 
			get 
			{
				if(_activated) return _predefinedType;
				Activate();
				return _predefinedType;
			} 
			set
			{
				SetValue( v =>  _predefinedType = v, _predefinedType, value,  "PredefinedType", 10);
			} 
		}	
		[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 36)]
		public IfcPositiveLengthMeasure? @NominalDiameter 
		{ 
			get 
			{
				if(_activated) return _nominalDiameter;
				Activate();
				return _nominalDiameter;
			} 
			set
			{
				SetValue( v =>  _nominalDiameter = v, _nominalDiameter, value,  "NominalDiameter", 11);
			} 
		}	
		[EntityAttribute(12, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 37)]
		public IfcAreaMeasure? @CrossSectionArea 
		{ 
			get 
			{
				if(_activated) return _crossSectionArea;
				Activate();
				return _crossSectionArea;
			} 
			set
			{
				SetValue( v =>  _crossSectionArea = v, _crossSectionArea, value,  "CrossSectionArea", 12);
			} 
		}	
		[EntityAttribute(13, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 38)]
		public IfcForceMeasure? @TensionForce 
		{ 
			get 
			{
				if(_activated) return _tensionForce;
				Activate();
				return _tensionForce;
			} 
			set
			{
				SetValue( v =>  _tensionForce = v, _tensionForce, value,  "TensionForce", 13);
			} 
		}	
		[EntityAttribute(14, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 39)]
		public IfcPressureMeasure? @PreStress 
		{ 
			get 
			{
				if(_activated) return _preStress;
				Activate();
				return _preStress;
			} 
			set
			{
				SetValue( v =>  _preStress = v, _preStress, value,  "PreStress", 14);
			} 
		}	
		[EntityAttribute(15, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 40)]
		public IfcNormalisedRatioMeasure? @FrictionCoefficient 
		{ 
			get 
			{
				if(_activated) return _frictionCoefficient;
				Activate();
				return _frictionCoefficient;
			} 
			set
			{
				SetValue( v =>  _frictionCoefficient = v, _frictionCoefficient, value,  "FrictionCoefficient", 15);
			} 
		}	
		[EntityAttribute(16, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 41)]
		public IfcPositiveLengthMeasure? @AnchorageSlip 
		{ 
			get 
			{
				if(_activated) return _anchorageSlip;
				Activate();
				return _anchorageSlip;
			} 
			set
			{
				SetValue( v =>  _anchorageSlip = v, _anchorageSlip, value,  "AnchorageSlip", 16);
			} 
		}	
		[EntityAttribute(17, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 42)]
		public IfcPositiveLengthMeasure? @MinCurvatureRadius 
		{ 
			get 
			{
				if(_activated) return _minCurvatureRadius;
				Activate();
				return _minCurvatureRadius;
			} 
			set
			{
				SetValue( v =>  _minCurvatureRadius = v, _minCurvatureRadius, value,  "MinCurvatureRadius", 17);
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
				case 6: 
				case 7: 
				case 8: 
					base.Parse(propIndex, value, nestedIndex); 
					return;
				case 9: 
                    _predefinedType = (IfcTendonTypeEnum) System.Enum.Parse(typeof (IfcTendonTypeEnum), value.EnumVal, true);
					return;
				case 10: 
					_nominalDiameter = value.RealVal;
					return;
				case 11: 
					_crossSectionArea = value.RealVal;
					return;
				case 12: 
					_tensionForce = value.RealVal;
					return;
				case 13: 
					_preStress = value.RealVal;
					return;
				case 14: 
					_frictionCoefficient = value.RealVal;
					return;
				case 15: 
					_anchorageSlip = value.RealVal;
					return;
				case 16: 
					_minCurvatureRadius = value.RealVal;
					return;
				default:
					throw new XbimParserException(string.Format("Attribute index {0} is out of range for {1}", propIndex + 1, GetType().Name.ToUpper()));
			}
		}
		#endregion

		#region Equality comparers and operators
        public bool Equals(@IfcTendon other)
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
				if (@ObjectPlacement != null)
					yield return @ObjectPlacement;
				if (@Representation != null)
					yield return @Representation;
			}
		}
		#endregion


		#region IContainsIndexedReferences
        IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences 
		{ 
			get
			{
				if (@ObjectPlacement != null)
					yield return @ObjectPlacement;
				if (@Representation != null)
					yield return @Representation;
				
			} 
		}
		#endregion

		#region Custom code (will survive code regeneration)
		//## Custom code
		//##
		#endregion
	}
}