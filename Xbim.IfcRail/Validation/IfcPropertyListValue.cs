using System;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using Xbim.Common.Enumerations;
using Xbim.Common.ExpressValidation;

// ReSharper disable once CheckNamespace
// ReSharper disable InconsistentNaming
namespace Xbim.IfcRail.PropertyResource
{
	public partial class IfcPropertyListValue : IExpressValidatable
	{
		public enum IfcPropertyListValueClause
		{
			WR31,
		}

		/// <summary>
		/// Tests the express where-clause specified in param 'clause'
		/// </summary>
		/// <param name="clause">The express clause to test</param>
		/// <returns>true if the clause is satisfied.</returns>
		public bool ValidateClause(IfcPropertyListValueClause clause) {
			var retVal = false;
			try
			{
				switch (clause)
				{
					case IfcPropertyListValueClause.WR31:
						retVal = Functions.SIZEOF(this.ListValues.Where(temp => !(Functions.TYPEOF(this.ListValues.ItemAt(0)) == Functions.TYPEOF(temp)))) == 0;
						break;
				}
			} catch (Exception  ex) {
				var log = Validation.ValidationLogging.CreateLogger<Xbim.IfcRail.PropertyResource.IfcPropertyListValue>();
				log?.LogError(string.Format("Exception thrown evaluating where-clause 'IfcPropertyListValue.{0}' for #{1}.", clause,EntityLabel), ex);
			}
			return retVal;
		}

		public virtual IEnumerable<ValidationResult> Validate()
		{
			if (!ValidateClause(IfcPropertyListValueClause.WR31))
				yield return new ValidationResult() { Item = this, IssueSource = "IfcPropertyListValue.WR31", IssueType = ValidationFlags.EntityWhereClauses };
		}
	}
}
