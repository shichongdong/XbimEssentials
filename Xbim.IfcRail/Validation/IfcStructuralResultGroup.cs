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
namespace Xbim.IfcRail.StructuralAnalysisDomain
{
	public partial class IfcStructuralResultGroup : IExpressValidatable
	{
		public enum IfcStructuralResultGroupClause
		{
			HasObjectType,
		}

		/// <summary>
		/// Tests the express where-clause specified in param 'clause'
		/// </summary>
		/// <param name="clause">The express clause to test</param>
		/// <returns>true if the clause is satisfied.</returns>
		public bool ValidateClause(IfcStructuralResultGroupClause clause) {
			var retVal = false;
			try
			{
				switch (clause)
				{
					case IfcStructuralResultGroupClause.HasObjectType:
						retVal = (TheoryType != IfcAnalysisTheoryTypeEnum.USERDEFINED) || Functions.EXISTS(this/* as IfcObject*/.ObjectType);
						break;
				}
			} catch (Exception  ex) {
				var log = Validation.ValidationLogging.CreateLogger<Xbim.IfcRail.StructuralAnalysisDomain.IfcStructuralResultGroup>();
				log?.LogError(string.Format("Exception thrown evaluating where-clause 'IfcStructuralResultGroup.{0}' for #{1}.", clause,EntityLabel), ex);
			}
			return retVal;
		}

		public override IEnumerable<ValidationResult> Validate()
		{
			foreach (var value in base.Validate())
			{
				yield return value;
			}
			if (!ValidateClause(IfcStructuralResultGroupClause.HasObjectType))
				yield return new ValidationResult() { Item = this, IssueSource = "IfcStructuralResultGroup.HasObjectType", IssueType = ValidationFlags.EntityWhereClauses };
		}
	}
}
