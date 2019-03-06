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
using System.ComponentModel;
using Xbim.Common.Metadata;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.IfcRail.RepresentationResource;
//## Custom using statements
//##


namespace Xbim.IfcRail.RepresentationResource
{
	[ExpressType("IfcCoordinateOperation", 577)]
	// ReSharper disable once PartialTypeWithSinglePart
	public abstract partial class @IfcCoordinateOperation : PersistEntity, IEquatable<@IfcCoordinateOperation>
	{

		//internal constructor makes sure that objects are not created outside of the model/ assembly controlled area
		internal IfcCoordinateOperation(IModel model, int label, bool activated) : base(model, label, activated)  
		{
		}

		#region Explicit attribute fields
		private IfcCoordinateReferenceSystemSelect _sourceCRS;
		private IfcCoordinateReferenceSystem _targetCRS;
		#endregion
	
		#region Explicit attribute properties
		[IndexedProperty]
		[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 1)]
		public IfcCoordinateReferenceSystemSelect @SourceCRS 
		{ 
			get 
			{
				if(_activated) return _sourceCRS;
				Activate();
				return _sourceCRS;
			} 
			set
			{
				if (value != null && !(ReferenceEquals(Model, value.Model)))
					throw new XbimException("Cross model entity assignment.");
				SetValue( v =>  _sourceCRS = v, _sourceCRS, value,  "SourceCRS", 1);
			} 
		}	
		[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 2)]
		public IfcCoordinateReferenceSystem @TargetCRS 
		{ 
			get 
			{
				if(_activated) return _targetCRS;
				Activate();
				return _targetCRS;
			} 
			set
			{
				if (value != null && !(ReferenceEquals(Model, value.Model)))
					throw new XbimException("Cross model entity assignment.");
				SetValue( v =>  _targetCRS = v, _targetCRS, value,  "TargetCRS", 2);
			} 
		}	
		#endregion




		#region IPersist implementation
		public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
		{
			switch (propIndex)
			{
				case 0: 
					_sourceCRS = (IfcCoordinateReferenceSystemSelect)(value.EntityVal);
					return;
				case 1: 
					_targetCRS = (IfcCoordinateReferenceSystem)(value.EntityVal);
					return;
				default:
					throw new XbimParserException(string.Format("Attribute index {0} is out of range for {1}", propIndex + 1, GetType().Name.ToUpper()));
			}
		}
		#endregion

		#region Equality comparers and operators
        public bool Equals(@IfcCoordinateOperation other)
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