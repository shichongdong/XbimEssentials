// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool Xbim.CodeGeneration 
//  
//     Changes to this file may cause incorrect behaviour and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------

using Xbim.IfcRail.MeasureResource;
using Xbim.IfcRail.ProfileResource;
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
	[ExpressType("IfcReinforcingBarType", 958)]
	// ReSharper disable once PartialTypeWithSinglePart
	public  partial class @IfcReinforcingBarType : IfcReinforcingElementType, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<@IfcReinforcingBarType>
	{

		//internal constructor makes sure that objects are not created outside of the model/ assembly controlled area
		internal IfcReinforcingBarType(IModel model, int label, bool activated) : base(model, label, activated)  
		{
			_bendingParameters = new OptionalItemSet<IfcBendingParameterSelect>( this, 0,  16);
		}

		#region Explicit attribute fields
		private IfcReinforcingBarTypeEnum _predefinedType;
		private IfcPositiveLengthMeasure? _nominalDiameter;
		private IfcAreaMeasure? _crossSectionArea;
		private IfcPositiveLengthMeasure? _barLength;
		private IfcReinforcingBarSurfaceEnum? _barSurface;
		private IfcLabel? _bendingShapeCode;
		private readonly OptionalItemSet<IfcBendingParameterSelect> _bendingParameters;
		#endregion
	
		#region Explicit attribute properties
		[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 19)]
		public IfcReinforcingBarTypeEnum @PredefinedType 
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
		[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 20)]
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
		[EntityAttribute(12, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 21)]
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
		[EntityAttribute(13, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 22)]
		public IfcPositiveLengthMeasure? @BarLength 
		{ 
			get 
			{
				if(_activated) return _barLength;
				Activate();
				return _barLength;
			} 
			set
			{
				SetValue( v =>  _barLength = v, _barLength, value,  "BarLength", 13);
			} 
		}	
		[EntityAttribute(14, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 23)]
		public IfcReinforcingBarSurfaceEnum? @BarSurface 
		{ 
			get 
			{
				if(_activated) return _barSurface;
				Activate();
				return _barSurface;
			} 
			set
			{
				SetValue( v =>  _barSurface = v, _barSurface, value,  "BarSurface", 14);
			} 
		}	
		[EntityAttribute(15, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 24)]
		public IfcLabel? @BendingShapeCode 
		{ 
			get 
			{
				if(_activated) return _bendingShapeCode;
				Activate();
				return _bendingShapeCode;
			} 
			set
			{
				SetValue( v =>  _bendingShapeCode = v, _bendingShapeCode, value,  "BendingShapeCode", 15);
			} 
		}	
		[EntityAttribute(16, EntityAttributeState.Optional, EntityAttributeType.List, EntityAttributeType.Class, new int [] { 1 }, new int [] { -1 }, 25)]
		public IOptionalItemSet<IfcBendingParameterSelect> @BendingParameters 
		{ 
			get 
			{
				if(_activated) return _bendingParameters;
				Activate();
				return _bendingParameters;
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
                    _predefinedType = (IfcReinforcingBarTypeEnum) System.Enum.Parse(typeof (IfcReinforcingBarTypeEnum), value.EnumVal, true);
					return;
				case 10: 
					_nominalDiameter = value.RealVal;
					return;
				case 11: 
					_crossSectionArea = value.RealVal;
					return;
				case 12: 
					_barLength = value.RealVal;
					return;
				case 13: 
                    _barSurface = (IfcReinforcingBarSurfaceEnum) System.Enum.Parse(typeof (IfcReinforcingBarSurfaceEnum), value.EnumVal, true);
					return;
				case 14: 
					_bendingShapeCode = value.StringVal;
					return;
				case 15: 
					_bendingParameters.InternalAdd((IfcBendingParameterSelect)value.EntityVal);
					return;
				default:
					throw new XbimParserException(string.Format("Attribute index {0} is out of range for {1}", propIndex + 1, GetType().Name.ToUpper()));
			}
		}
		#endregion

		#region Equality comparers and operators
        public bool Equals(@IfcReinforcingBarType other)
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
				foreach(var entity in @HasPropertySets)
					yield return entity;
				foreach(var entity in @RepresentationMaps)
					yield return entity;
			}
		}
		#endregion


		#region IContainsIndexedReferences
        IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences 
		{ 
			get
			{
				foreach(var entity in @HasPropertySets)
					yield return entity;
				
			} 
		}
		#endregion

		#region Custom code (will survive code regeneration)
		//## Custom code
		//##
		#endregion
	}
}