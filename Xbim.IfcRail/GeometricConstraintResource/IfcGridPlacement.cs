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
using Xbim.IfcRail.GeometricConstraintResource;
//## Custom using statements
//##


namespace Xbim.IfcRail.GeometricConstraintResource
{
	[ExpressType("IfcGridPlacement", 745)]
	// ReSharper disable once PartialTypeWithSinglePart
	public  partial class @IfcGridPlacement : IfcObjectPlacement, IInstantiableEntity, IContainsEntityReferences, IEquatable<@IfcGridPlacement>
	{

		//internal constructor makes sure that objects are not created outside of the model/ assembly controlled area
		internal IfcGridPlacement(IModel model, int label, bool activated) : base(model, label, activated)  
		{
		}

		#region Explicit attribute fields
		private IfcVirtualGridIntersection _placementLocation;
		private IfcGridPlacementDirectionSelect _placementRefDirection;
		#endregion
	
		#region Explicit attribute properties
		[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
		public IfcVirtualGridIntersection @PlacementLocation 
		{ 
			get 
			{
				if(_activated) return _placementLocation;
				Activate();
				return _placementLocation;
			} 
			set
			{
				if (value != null && !(ReferenceEquals(Model, value.Model)))
					throw new XbimException("Cross model entity assignment.");
				SetValue( v =>  _placementLocation = v, _placementLocation, value,  "PlacementLocation", 2);
			} 
		}	
		[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 4)]
		public IfcGridPlacementDirectionSelect @PlacementRefDirection 
		{ 
			get 
			{
				if(_activated) return _placementRefDirection;
				Activate();
				return _placementRefDirection;
			} 
			set
			{
				if (value != null && !(ReferenceEquals(Model, value.Model)))
					throw new XbimException("Cross model entity assignment.");
				SetValue( v =>  _placementRefDirection = v, _placementRefDirection, value,  "PlacementRefDirection", 3);
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
					_placementLocation = (IfcVirtualGridIntersection)(value.EntityVal);
					return;
				case 2: 
					_placementRefDirection = (IfcGridPlacementDirectionSelect)(value.EntityVal);
					return;
				default:
					throw new XbimParserException(string.Format("Attribute index {0} is out of range for {1}", propIndex + 1, GetType().Name.ToUpper()));
			}
		}
		#endregion

		#region Equality comparers and operators
        public bool Equals(@IfcGridPlacement other)
	    {
	        return this == other;
	    }
        #endregion

		#region IContainsEntityReferences
		IEnumerable<IPersistEntity> IContainsEntityReferences.References 
		{
			get 
			{
				if (@PlacementRelTo != null)
					yield return @PlacementRelTo;
				if (@PlacementLocation != null)
					yield return @PlacementLocation;
				if (@PlacementRefDirection != null)
					yield return @PlacementRefDirection;
			}
		}
		#endregion

		#region Custom code (will survive code regeneration)
		//## Custom code
		//##
		#endregion
	}
}