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
namespace Xbim.IfcRail.SharedBldgElements
{
	public partial class IfcBeamStandardCase : IExpressValidatable
	{
		public enum IfcBeamStandardCaseClause
		{
			HasMaterialProfileSetUsage,
		}

		/// <summary>
		/// Tests the express where-clause specified in param 'clause'
		/// </summary>
		/// <param name="clause">The express clause to test</param>
		/// <returns>true if the clause is satisfied.</returns>
		public bool ValidateClause(IfcBeamStandardCaseClause clause) {
			var retVal = false;
			try
			{
				switch (clause)
				{
					case IfcBeamStandardCaseClause.HasMaterialProfileSetUsage:
						retVal = Functions.SIZEOF(Functions.USEDIN(this, "IFCRELASSOCIATES.RELATEDOBJECTS").Where(temp => (Functions.TYPEOF(temp).Contains("IFCRELASSOCIATESMATERIAL")) && (Functions.TYPEOF(temp.AsIfcRelAssociatesMaterial().RelatingMaterial).Contains("IFCMATERIALPROFILESETUSAGE")))) == 1;
						break;
				}
			} catch (Exception  ex) {
				var log = Validation.ValidationLogging.CreateLogger<Xbim.IfcRail.SharedBldgElements.IfcBeamStandardCase>();
				log?.LogError(string.Format("Exception thrown evaluating where-clause 'IfcBeamStandardCase.{0}' for #{1}.", clause,EntityLabel), ex);
			}
			return retVal;
		}

		public override IEnumerable<ValidationResult> Validate()
		{
			foreach (var value in base.Validate())
			{
				yield return value;
			}
			if (!ValidateClause(IfcBeamStandardCaseClause.HasMaterialProfileSetUsage))
				yield return new ValidationResult() { Item = this, IssueSource = "IfcBeamStandardCase.HasMaterialProfileSetUsage", IssueType = ValidationFlags.EntityWhereClauses };
		}
	}
}
