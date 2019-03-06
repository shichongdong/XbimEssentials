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
namespace Xbim.IfcRail.ElectricalDomain
{
	public partial class IfcElectricTimeControlType : IExpressValidatable
	{
		public enum IfcElectricTimeControlTypeClause
		{
			CorrectPredefinedType,
		}

		/// <summary>
		/// Tests the express where-clause specified in param 'clause'
		/// </summary>
		/// <param name="clause">The express clause to test</param>
		/// <returns>true if the clause is satisfied.</returns>
		public bool ValidateClause(IfcElectricTimeControlTypeClause clause) {
			var retVal = false;
			try
			{
				switch (clause)
				{
					case IfcElectricTimeControlTypeClause.CorrectPredefinedType:
						retVal = (PredefinedType != IfcElectricTimeControlTypeEnum.USERDEFINED) || ((PredefinedType == IfcElectricTimeControlTypeEnum.USERDEFINED) && Functions.EXISTS(this/* as IfcElementType*/.ElementType));
						break;
				}
			} catch (Exception  ex) {
				var log = Validation.ValidationLogging.CreateLogger<Xbim.IfcRail.ElectricalDomain.IfcElectricTimeControlType>();
				log?.LogError(string.Format("Exception thrown evaluating where-clause 'IfcElectricTimeControlType.{0}' for #{1}.", clause,EntityLabel), ex);
			}
			return retVal;
		}

		public override IEnumerable<ValidationResult> Validate()
		{
			foreach (var value in base.Validate())
			{
				yield return value;
			}
			if (!ValidateClause(IfcElectricTimeControlTypeClause.CorrectPredefinedType))
				yield return new ValidationResult() { Item = this, IssueSource = "IfcElectricTimeControlType.CorrectPredefinedType", IssueType = ValidationFlags.EntityWhereClauses };
		}
	}
}
