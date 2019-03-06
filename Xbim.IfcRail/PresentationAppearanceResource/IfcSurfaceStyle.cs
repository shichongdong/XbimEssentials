// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool Xbim.CodeGeneration 
//  
//     Changes to this file may cause incorrect behaviour and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------

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
	[ExpressType("IfcSurfaceStyle", 1127)]
	// ReSharper disable once PartialTypeWithSinglePart
	public  partial class @IfcSurfaceStyle : IfcPresentationStyle, IInstantiableEntity, IfcPresentationStyleSelect, IContainsEntityReferences, IEquatable<@IfcSurfaceStyle>
	{

		//internal constructor makes sure that objects are not created outside of the model/ assembly controlled area
		internal IfcSurfaceStyle(IModel model, int label, bool activated) : base(model, label, activated)  
		{
			_styles = new ItemSet<IfcSurfaceStyleElementSelect>( this, 5,  3);
		}

		#region Explicit attribute fields
		private IfcSurfaceSide _side;
		private readonly ItemSet<IfcSurfaceStyleElementSelect> _styles;
		#endregion
	
		#region Explicit attribute properties
		[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 2)]
		public IfcSurfaceSide @Side 
		{ 
			get 
			{
				if(_activated) return _side;
				Activate();
				return _side;
			} 
			set
			{
				SetValue( v =>  _side = v, _side, value,  "Side", 2);
			} 
		}	
		[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int [] { 1 }, new int [] { 5 }, 3)]
		public IItemSet<IfcSurfaceStyleElementSelect> @Styles 
		{ 
			get 
			{
				if(_activated) return _styles;
				Activate();
				return _styles;
			} 
		}	
		#endregion




		#region IPersist implementation
		public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
		{
			switch (propIndex)
			{
				case 0: 
					base.Parse(propIndex, value, nestedIndex); 
					return;
				case 1: 
                    _side = (IfcSurfaceSide) System.Enum.Parse(typeof (IfcSurfaceSide), value.EnumVal, true);
					return;
				case 2: 
					_styles.InternalAdd((IfcSurfaceStyleElementSelect)value.EntityVal);
					return;
				default:
					throw new XbimParserException(string.Format("Attribute index {0} is out of range for {1}", propIndex + 1, GetType().Name.ToUpper()));
			}
		}
		#endregion

		#region Equality comparers and operators
        public bool Equals(@IfcSurfaceStyle other)
	    {
	        return this == other;
	    }
        #endregion

		#region IContainsEntityReferences
		IEnumerable<IPersistEntity> IContainsEntityReferences.References 
		{
			get 
			{
				foreach(var entity in @Styles)
					yield return entity;
			}
		}
		#endregion

		#region Custom code (will survive code regeneration)
		//## Custom code
        public new IEnumerable<IIfcSurfaceStyle> SurfaceStyles { get { return new []{this}; } }
		//##
		#endregion
	}
}