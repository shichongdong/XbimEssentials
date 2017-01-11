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
namespace Xbim.Ifc4.SharedBldgElements
{
	public partial class IfcBuildingElementProxyType : IExpressValidatable
	{
		public enum IfcBuildingElementProxyTypeClause
		{
			CorrectPredefinedType,
		}

		/// <summary>
		/// Tests the express where-clause specified in param 'clause'
		/// </summary>
		/// <param name="clause">The express clause to test</param>
		/// <returns>true if the clause is satisfied.</returns>
		public bool ValidateClause(IfcBuildingElementProxyTypeClause clause) {
			var retVal = false;
			try
			{
				switch (clause)
				{
					case IfcBuildingElementProxyTypeClause.CorrectPredefinedType:
						retVal = (PredefinedType != IfcBuildingElementProxyTypeEnum.USERDEFINED) || ((PredefinedType == IfcBuildingElementProxyTypeEnum.USERDEFINED) && EXISTS(this/* as IfcElementType*/.ElementType));
						break;
				}
			} catch (Exception ex) {
				var Log = LogManager.GetLogger("Xbim.Ifc4.SharedBldgElements.IfcBuildingElementProxyType");
				Log.Error(string.Format("Exception thrown evaluating where-clause 'IfcBuildingElementProxyType.{0}' for #{1}.", clause,EntityLabel), ex);
			}
			return retVal;
		}

		public override IEnumerable<ValidationResult> Validate()
		{
			foreach (var value in base.Validate())
			{
				yield return value;
			}
			if (!ValidateClause(IfcBuildingElementProxyTypeClause.CorrectPredefinedType))
				yield return new ValidationResult() { Item = this, IssueSource = "IfcBuildingElementProxyType.CorrectPredefinedType", IssueType = ValidationFlags.EntityWhereClauses };
		}
	}
}