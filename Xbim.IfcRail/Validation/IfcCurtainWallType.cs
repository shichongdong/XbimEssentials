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
	public partial class IfcCurtainWallType : IExpressValidatable
	{
		public enum IfcCurtainWallTypeClause
		{
			CorrectPredefinedType,
		}

		/// <summary>
		/// Tests the express where-clause specified in param 'clause'
		/// </summary>
		/// <param name="clause">The express clause to test</param>
		/// <returns>true if the clause is satisfied.</returns>
		public bool ValidateClause(IfcCurtainWallTypeClause clause) {
			var retVal = false;
			try
			{
				switch (clause)
				{
					case IfcCurtainWallTypeClause.CorrectPredefinedType:
						retVal = (PredefinedType != IfcCurtainWallTypeEnum.USERDEFINED) || ((PredefinedType == IfcCurtainWallTypeEnum.USERDEFINED) && Functions.EXISTS(this/* as IfcElementType*/.ElementType));
						break;
				}
			} catch (Exception  ex) {
				var log = Validation.ValidationLogging.CreateLogger<Xbim.IfcRail.SharedBldgElements.IfcCurtainWallType>();
				log?.LogError(string.Format("Exception thrown evaluating where-clause 'IfcCurtainWallType.{0}' for #{1}.", clause,EntityLabel), ex);
			}
			return retVal;
		}

		public override IEnumerable<ValidationResult> Validate()
		{
			foreach (var value in base.Validate())
			{
				yield return value;
			}
			if (!ValidateClause(IfcCurtainWallTypeClause.CorrectPredefinedType))
				yield return new ValidationResult() { Item = this, IssueSource = "IfcCurtainWallType.CorrectPredefinedType", IssueType = ValidationFlags.EntityWhereClauses };
		}
	}
}
