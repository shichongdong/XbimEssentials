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
using Xbim.IfcRail.Kernel;
//## Custom using statements
//##


namespace Xbim.IfcRail.Kernel
{
	[ExpressType("IfcControl", 568)]
	// ReSharper disable once PartialTypeWithSinglePart
	public abstract partial class @IfcControl : IfcObject, IEquatable<@IfcControl>
	{

		//internal constructor makes sure that objects are not created outside of the model/ assembly controlled area
		internal IfcControl(IModel model, int label, bool activated) : base(model, label, activated)  
		{
		}

		#region Explicit attribute fields
		private IfcIdentifier? _identification;
		#endregion
	
		#region Explicit attribute properties
		[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 17)]
		public IfcIdentifier? @Identification 
		{ 
			get 
			{
				if(_activated) return _identification;
				Activate();
				return _identification;
			} 
			set
			{
				SetValue( v =>  _identification = v, _identification, value,  "Identification", 6);
			} 
		}	
		#endregion



		#region Inverse attributes
		[InverseProperty("RelatingControl")]
		[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int [] { 0 }, new int [] { -1 }, 18)]
		public IEnumerable<IfcRelAssignsToControl> @Controls 
		{ 
			get 
			{
				return Model.Instances.Where<IfcRelAssignsToControl>(e => Equals(e.RelatingControl), "RelatingControl", this);
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
					_identification = value.StringVal;
					return;
				default:
					throw new XbimParserException(string.Format("Attribute index {0} is out of range for {1}", propIndex + 1, GetType().Name.ToUpper()));
			}
		}
		#endregion

		#region Equality comparers and operators
        public bool Equals(@IfcControl other)
	    {
	        return this == other;
	    }
        #endregion

		#region Custom code (will survive code regeneration)
		//## Custom code
		//##
		#endregion
	}
}