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
using Xbim.IfcRail.MaterialResource;
//## Custom using statements
//##


namespace Xbim.IfcRail.MaterialResource
{
	[ExpressType("IfcMaterialProfileWithOffsets", 810)]
	// ReSharper disable once PartialTypeWithSinglePart
	public  partial class @IfcMaterialProfileWithOffsets : IfcMaterialProfile, IInstantiableEntity, IContainsEntityReferences, IEquatable<@IfcMaterialProfileWithOffsets>
	{

		//internal constructor makes sure that objects are not created outside of the model/ assembly controlled area
		internal IfcMaterialProfileWithOffsets(IModel model, int label, bool activated) : base(model, label, activated)  
		{
			_offsetValues = new ItemSet<IfcLengthMeasure>( this, 2,  7);
		}

		#region Explicit attribute fields
		private readonly ItemSet<IfcLengthMeasure> _offsetValues;
		#endregion
	
		#region Explicit attribute properties
		[EntityAttribute(7, EntityAttributeState.Mandatory, EntityAttributeType.Array, EntityAttributeType.None, new int [] { 1 }, new int [] { 2 }, 11)]
		public IItemSet<IfcLengthMeasure> @OffsetValues 
		{ 
			get 
			{
				if(_activated) return _offsetValues;
				Activate();
				return _offsetValues;
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
					_offsetValues.InternalAdd(value.RealVal);
					return;
				default:
					throw new XbimParserException(string.Format("Attribute index {0} is out of range for {1}", propIndex + 1, GetType().Name.ToUpper()));
			}
		}
		#endregion

		#region Equality comparers and operators
        public bool Equals(@IfcMaterialProfileWithOffsets other)
	    {
	        return this == other;
	    }
        #endregion

		#region IContainsEntityReferences
		IEnumerable<IPersistEntity> IContainsEntityReferences.References 
		{
			get 
			{
				if (@Material != null)
					yield return @Material;
				if (@Profile != null)
					yield return @Profile;
			}
		}
		#endregion

		#region Custom code (will survive code regeneration)
		//## Custom code
		//##
		#endregion
	}
}