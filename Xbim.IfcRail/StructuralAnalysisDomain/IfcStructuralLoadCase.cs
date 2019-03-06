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
using Xbim.IfcRail.StructuralAnalysisDomain;
//## Custom using statements
//##


namespace Xbim.IfcRail.StructuralAnalysisDomain
{
	[ExpressType("IfcStructuralLoadCase", 1090)]
	// ReSharper disable once PartialTypeWithSinglePart
	public  partial class @IfcStructuralLoadCase : IfcStructuralLoadGroup, IInstantiableEntity, IContainsEntityReferences, IEquatable<@IfcStructuralLoadCase>
	{

		//internal constructor makes sure that objects are not created outside of the model/ assembly controlled area
		internal IfcStructuralLoadCase(IModel model, int label, bool activated) : base(model, label, activated)  
		{
			_selfWeightCoefficients = new OptionalItemSet<IfcRatioMeasure>( this, 3,  11);
		}

		#region Explicit attribute fields
		private readonly OptionalItemSet<IfcRatioMeasure> _selfWeightCoefficients;
		#endregion
	
		#region Explicit attribute properties
		[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.List, EntityAttributeType.None, new int [] { 3 }, new int [] { 3 }, 25)]
		public IOptionalItemSet<IfcRatioMeasure> @SelfWeightCoefficients 
		{ 
			get 
			{
				if(_activated) return _selfWeightCoefficients;
				Activate();
				return _selfWeightCoefficients;
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
				case 9: 
					base.Parse(propIndex, value, nestedIndex); 
					return;
				case 10: 
					_selfWeightCoefficients.InternalAdd(value.RealVal);
					return;
				default:
					throw new XbimParserException(string.Format("Attribute index {0} is out of range for {1}", propIndex + 1, GetType().Name.ToUpper()));
			}
		}
		#endregion

		#region Equality comparers and operators
        public bool Equals(@IfcStructuralLoadCase other)
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