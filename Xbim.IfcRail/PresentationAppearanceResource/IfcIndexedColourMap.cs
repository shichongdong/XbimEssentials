// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool Xbim.CodeGeneration 
//  
//     Changes to this file may cause incorrect behaviour and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------

using Xbim.IfcRail.PresentationDefinitionResource;
using Xbim.IfcRail.GeometricModelResource;
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
	[ExpressType("IfcIndexedColourMap", 754)]
	// ReSharper disable once PartialTypeWithSinglePart
	public  partial class @IfcIndexedColourMap : IfcPresentationItem, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<@IfcIndexedColourMap>
	{

		//internal constructor makes sure that objects are not created outside of the model/ assembly controlled area
		internal IfcIndexedColourMap(IModel model, int label, bool activated) : base(model, label, activated)  
		{
			_colourIndex = new ItemSet<IfcPositiveInteger>( this, 0,  4);
		}

		#region Explicit attribute fields
		private IfcTessellatedFaceSet _mappedTo;
		private IfcNormalisedRatioMeasure? _opacity;
		private IfcColourRgbList _colours;
		private readonly ItemSet<IfcPositiveInteger> _colourIndex;
		#endregion
	
		#region Explicit attribute properties
		[IndexedProperty]
		[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 1)]
		public IfcTessellatedFaceSet @MappedTo 
		{ 
			get 
			{
				if(_activated) return _mappedTo;
				Activate();
				return _mappedTo;
			} 
			set
			{
				if (value != null && !(ReferenceEquals(Model, value.Model)))
					throw new XbimException("Cross model entity assignment.");
				SetValue( v =>  _mappedTo = v, _mappedTo, value,  "MappedTo", 1);
			} 
		}	
		[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
		public IfcNormalisedRatioMeasure? @Opacity 
		{ 
			get 
			{
				if(_activated) return _opacity;
				Activate();
				return _opacity;
			} 
			set
			{
				SetValue( v =>  _opacity = v, _opacity, value,  "Opacity", 2);
			} 
		}	
		[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
		public IfcColourRgbList @Colours 
		{ 
			get 
			{
				if(_activated) return _colours;
				Activate();
				return _colours;
			} 
			set
			{
				if (value != null && !(ReferenceEquals(Model, value.Model)))
					throw new XbimException("Cross model entity assignment.");
				SetValue( v =>  _colours = v, _colours, value,  "Colours", 3);
			} 
		}	
		[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.None, new int [] { 1 }, new int [] { -1 }, 4)]
		public IItemSet<IfcPositiveInteger> @ColourIndex 
		{ 
			get 
			{
				if(_activated) return _colourIndex;
				Activate();
				return _colourIndex;
			} 
		}	
		#endregion




		#region IPersist implementation
		public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
		{
			switch (propIndex)
			{
				case 0: 
					_mappedTo = (IfcTessellatedFaceSet)(value.EntityVal);
					return;
				case 1: 
					_opacity = value.RealVal;
					return;
				case 2: 
					_colours = (IfcColourRgbList)(value.EntityVal);
					return;
				case 3: 
					_colourIndex.InternalAdd(value.IntegerVal);
					return;
				default:
					throw new XbimParserException(string.Format("Attribute index {0} is out of range for {1}", propIndex + 1, GetType().Name.ToUpper()));
			}
		}
		#endregion

		#region Equality comparers and operators
        public bool Equals(@IfcIndexedColourMap other)
	    {
	        return this == other;
	    }
        #endregion

		#region IContainsEntityReferences
		IEnumerable<IPersistEntity> IContainsEntityReferences.References 
		{
			get 
			{
				if (@MappedTo != null)
					yield return @MappedTo;
				if (@Colours != null)
					yield return @Colours;
			}
		}
		#endregion


		#region IContainsIndexedReferences
        IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences 
		{ 
			get
			{
				if (@MappedTo != null)
					yield return @MappedTo;
				
			} 
		}
		#endregion

		#region Custom code (will survive code regeneration)
		//## Custom code
		//##
		#endregion
	}
}