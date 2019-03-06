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
using Xbim.IfcRail.PresentationAppearanceResource;
//## Custom using statements
//##


namespace Xbim.IfcRail.PresentationAppearanceResource
{
	[ExpressType("IfcFillAreaStyleTiles", 706)]
	// ReSharper disable once PartialTypeWithSinglePart
	public  partial class @IfcFillAreaStyleTiles : IfcGeometricRepresentationItem, IInstantiableEntity, IfcFillStyleSelect, IContainsEntityReferences, IEquatable<@IfcFillAreaStyleTiles>
	{

		//internal constructor makes sure that objects are not created outside of the model/ assembly controlled area
		internal IfcFillAreaStyleTiles(IModel model, int label, bool activated) : base(model, label, activated)  
		{
			_tilingPattern = new ItemSet<IfcVector>( this, 2,  1);
			_tiles = new ItemSet<IfcStyledItem>( this, 0,  2);
		}

		#region Explicit attribute fields
		private readonly ItemSet<IfcVector> _tilingPattern;
		private readonly ItemSet<IfcStyledItem> _tiles;
		private IfcPositiveRatioMeasure _tilingScale;
		#endregion
	
		#region Explicit attribute properties
		[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.Class, new int [] { 2 }, new int [] { 2 }, 3)]
		public IItemSet<IfcVector> @TilingPattern 
		{ 
			get 
			{
				if(_activated) return _tilingPattern;
				Activate();
				return _tilingPattern;
			} 
		}	
		[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int [] { 1 }, new int [] { -1 }, 4)]
		public IItemSet<IfcStyledItem> @Tiles 
		{ 
			get 
			{
				if(_activated) return _tiles;
				Activate();
				return _tiles;
			} 
		}	
		[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
		public IfcPositiveRatioMeasure @TilingScale 
		{ 
			get 
			{
				if(_activated) return _tilingScale;
				Activate();
				return _tilingScale;
			} 
			set
			{
				SetValue( v =>  _tilingScale = v, _tilingScale, value,  "TilingScale", 3);
			} 
		}	
		#endregion




		#region IPersist implementation
		public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
		{
			switch (propIndex)
			{
				case 0: 
					_tilingPattern.InternalAdd((IfcVector)value.EntityVal);
					return;
				case 1: 
					_tiles.InternalAdd((IfcStyledItem)value.EntityVal);
					return;
				case 2: 
					_tilingScale = value.RealVal;
					return;
				default:
					throw new XbimParserException(string.Format("Attribute index {0} is out of range for {1}", propIndex + 1, GetType().Name.ToUpper()));
			}
		}
		#endregion

		#region Equality comparers and operators
        public bool Equals(@IfcFillAreaStyleTiles other)
	    {
	        return this == other;
	    }
        #endregion

		#region IContainsEntityReferences
		IEnumerable<IPersistEntity> IContainsEntityReferences.References 
		{
			get 
			{
				foreach(var entity in @TilingPattern)
					yield return entity;
				foreach(var entity in @Tiles)
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