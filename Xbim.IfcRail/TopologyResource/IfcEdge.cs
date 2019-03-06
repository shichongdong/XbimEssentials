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
using Xbim.IfcRail.TopologyResource;
//## Custom using statements
//##


namespace Xbim.IfcRail.TopologyResource
{
	[ExpressType("IfcEdge", 640)]
	// ReSharper disable once PartialTypeWithSinglePart
	public  partial class @IfcEdge : IfcTopologicalRepresentationItem, IInstantiableEntity, IContainsEntityReferences, IEquatable<@IfcEdge>
	{

		//internal constructor makes sure that objects are not created outside of the model/ assembly controlled area
		internal IfcEdge(IModel model, int label, bool activated) : base(model, label, activated)  
		{
		}

		#region Explicit attribute fields
		private IfcVertex _edgeStart;
		private IfcVertex _edgeEnd;
		#endregion
	
		#region Explicit attribute properties
		[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
		public virtual IfcVertex @EdgeStart 
		{ 
			get 
			{
				if(_activated) return _edgeStart;
				Activate();
				return _edgeStart;
			} 
			set
			{
				if (value != null && !(ReferenceEquals(Model, value.Model)))
					throw new XbimException("Cross model entity assignment.");
				SetValue( v =>  _edgeStart = v, _edgeStart, value,  "EdgeStart", 1);
			} 
		}	
		[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 4)]
		public virtual IfcVertex @EdgeEnd 
		{ 
			get 
			{
				if(_activated) return _edgeEnd;
				Activate();
				return _edgeEnd;
			} 
			set
			{
				if (value != null && !(ReferenceEquals(Model, value.Model)))
					throw new XbimException("Cross model entity assignment.");
				SetValue( v =>  _edgeEnd = v, _edgeEnd, value,  "EdgeEnd", 2);
			} 
		}	
		#endregion




		#region IPersist implementation
		public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
		{
			switch (propIndex)
			{
				case 0: 
					_edgeStart = (IfcVertex)(value.EntityVal);
					return;
				case 1: 
					_edgeEnd = (IfcVertex)(value.EntityVal);
					return;
				default:
					throw new XbimParserException(string.Format("Attribute index {0} is out of range for {1}", propIndex + 1, GetType().Name.ToUpper()));
			}
		}
		#endregion

		#region Equality comparers and operators
        public bool Equals(@IfcEdge other)
	    {
	        return this == other;
	    }
        #endregion

		#region IContainsEntityReferences
		IEnumerable<IPersistEntity> IContainsEntityReferences.References 
		{
			get 
			{
				if (@EdgeStart != null)
					yield return @EdgeStart;
				if (@EdgeEnd != null)
					yield return @EdgeEnd;
			}
		}
		#endregion

		#region Custom code (will survive code regeneration)
		//## Custom code
		//##
		#endregion
	}
}