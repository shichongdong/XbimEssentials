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
using Xbim.IfcRail.PresentationAppearanceResource;
//## Custom using statements
//##


namespace Xbim.IfcRail.PresentationAppearanceResource
{
	[ExpressType("IfcBlobTexture", 464)]
	// ReSharper disable once PartialTypeWithSinglePart
	public  partial class @IfcBlobTexture : IfcSurfaceTexture, IInstantiableEntity, IContainsEntityReferences, IEquatable<@IfcBlobTexture>
	{

		//internal constructor makes sure that objects are not created outside of the model/ assembly controlled area
		internal IfcBlobTexture(IModel model, int label, bool activated) : base(model, label, activated)  
		{
		}

		#region Explicit attribute fields
		private IfcIdentifier _rasterFormat;
		private IfcBinary _rasterCode;
		#endregion
	
		#region Explicit attribute properties
		[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 8)]
		public IfcIdentifier @RasterFormat 
		{ 
			get 
			{
				if(_activated) return _rasterFormat;
				Activate();
				return _rasterFormat;
			} 
			set
			{
				SetValue( v =>  _rasterFormat = v, _rasterFormat, value,  "RasterFormat", 6);
			} 
		}	
		[EntityAttribute(7, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 9)]
		public IfcBinary @RasterCode 
		{ 
			get 
			{
				if(_activated) return _rasterCode;
				Activate();
				return _rasterCode;
			} 
			set
			{
				SetValue( v =>  _rasterCode = v, _rasterCode, value,  "RasterCode", 7);
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
					base.Parse(propIndex, value, nestedIndex); 
					return;
				case 5: 
					_rasterFormat = value.StringVal;
					return;
				case 6: 
					_rasterCode = value.HexadecimalVal;
					return;
				default:
					throw new XbimParserException(string.Format("Attribute index {0} is out of range for {1}", propIndex + 1, GetType().Name.ToUpper()));
			}
		}
		#endregion

		#region Equality comparers and operators
        public bool Equals(@IfcBlobTexture other)
	    {
	        return this == other;
	    }
        #endregion

		#region IContainsEntityReferences
		IEnumerable<IPersistEntity> IContainsEntityReferences.References 
		{
			get 
			{
				if (@TextureTransform != null)
					yield return @TextureTransform;
			}
		}
		#endregion

		#region Custom code (will survive code regeneration)
		//## Custom code
		//##
		#endregion
	}
}