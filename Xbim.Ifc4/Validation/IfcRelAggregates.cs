using System;
using log4net;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using Xbim.Common.Enumerations;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.Interfaces;
using static Xbim.Ifc4.Functions;
// ReSharper disable once CheckNamespace
// ReSharper disable InconsistentNaming
namespace Xbim.Ifc4.Kernel
{
	public partial class IfcRelAggregates : IExpressValidatable
	{
		public enum IfcRelAggregatesClause
		{
			NoSelfReference,
		}

		/// <summary>
		/// Tests the express where-clause specified in param 'clause'
		/// </summary>
		/// <param name="clause">The express clause to test</param>
		/// <returns>true if the clause is satisfied.</returns>
		public bool ValidateClause(IfcRelAggregatesClause clause) {
			var retVal = false;
			try
			{
				switch (clause)
				{
					case IfcRelAggregatesClause.NoSelfReference:
						retVal = SIZEOF(RelatedObjects.Where(Temp => Object.ReferenceEquals(RelatingObject, Temp))) == 0;
						break;
				}
			} catch (Exception ex) {
				var Log = LogManager.GetLogger("Xbim.Ifc4.Kernel.IfcRelAggregates");
				Log.Error(string.Format("Exception thrown evaluating where-clause 'IfcRelAggregates.{0}' for #{1}.", clause,EntityLabel), ex);
			}
			return retVal;
		}

		public virtual IEnumerable<ValidationResult> Validate()
		{
			if (!ValidateClause(IfcRelAggregatesClause.NoSelfReference))
				yield return new ValidationResult() { Item = this, IssueSource = "IfcRelAggregates.NoSelfReference", IssueType = ValidationFlags.EntityWhereClauses };
		}
	}
}