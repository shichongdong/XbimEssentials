// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool Xbim.CodeGeneration 
//  
//     Changes to this file may cause incorrect behaviour and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------

using Xbim.IfcRail.Kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.IfcRail.RepresentationResource;
//## Custom using statements
//##


namespace Xbim.IfcRail.RepresentationResource
{
	[ExpressType("IfcProductDefinitionShape", 898)]
	// ReSharper disable once PartialTypeWithSinglePart
	public  partial class @IfcProductDefinitionShape : IfcProductRepresentation, IInstantiableEntity, IfcProductRepresentationSelect, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<@IfcProductDefinitionShape>
	{

		//internal constructor makes sure that objects are not created outside of the model/ assembly controlled area
		internal IfcProductDefinitionShape(IModel model, int label, bool activated) : base(model, label, activated)  
		{
		}




		#region Inverse attributes
		[InverseProperty("Representation")]
		[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int [] { 1 }, new int [] { -1 }, 4)]
		public IEnumerable<IfcProduct> @ShapeOfProduct 
		{ 
			get 
			{
				return Model.Instances.Where<IfcProduct>(e => Equals(e.Representation), "Representation", this);
			} 
		}
		[InverseProperty("PartOfProductDefinitionShape")]
		[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int [] { 0 }, new int [] { -1 }, 5)]
		public IEnumerable<IfcShapeAspect> @HasShapeAspects 
		{ 
			get 
			{
				return Model.Instances.Where<IfcShapeAspect>(e => Equals(e.PartOfProductDefinitionShape), "PartOfProductDefinitionShape", this);
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
					base.Parse(propIndex, value, nestedIndex); 
					return;
				default:
					throw new XbimParserException(string.Format("Attribute index {0} is out of range for {1}", propIndex + 1, GetType().Name.ToUpper()));
			}
		}
		#endregion

		#region Equality comparers and operators
        public bool Equals(@IfcProductDefinitionShape other)
	    {
	        return this == other;
	    }
        #endregion

		#region IContainsEntityReferences
		IEnumerable<IPersistEntity> IContainsEntityReferences.References 
		{
			get 
			{
				foreach(var entity in @Representations)
					yield return entity;
			}
		}
		#endregion


		#region IContainsIndexedReferences
        IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences 
		{ 
			get
			{
				foreach(var entity in @Representations)
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