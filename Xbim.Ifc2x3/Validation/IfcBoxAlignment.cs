using System;
using log4net;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using Xbim.Common.Enumerations;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.Interfaces;
using Xbim.Ifc2x3.Kernel;
using Xbim.Ifc2x3.ProfileResource;
using Xbim.Ifc2x3.ProfilePropertyResource;
using static Xbim.Ifc2x3.Functions;
// ReSharper disable once CheckNamespace
// ReSharper disable InconsistentNaming
namespace Xbim.Ifc2x3.PresentationDefinitionResource
{
	public partial struct IfcBoxAlignment : IExpressValidatable
	{
		public enum IfcBoxAlignmentClause
		{
			WR1,
		}

		/// <summary>
		/// Tests the express where-clause specified in param 'clause'
		/// </summary>
		/// <param name="clause">The express clause to test</param>
		/// <returns>true if the clause is satisfied.</returns>
		public bool ValidateClause(IfcBoxAlignmentClause clause) {
			var retVal = false;
			try
			{
				switch (clause)
				{
					case IfcBoxAlignmentClause.WR1:
						retVal = NewArray("top-left", "top-middle", "top-right", "middle-left", "center", "middle-right", "bottom-left", "bottom-middle", "bottom-right").Contains(this);
						break;
				}
			} catch (Exception ex) {
				var Log = LogManager.GetLogger("Xbim.Ifc2x3.PresentationDefinitionResource.IfcBoxAlignment");
				Log.Error(string.Format("Exception thrown evaluating where-clause 'IfcBoxAlignment.{0}'.", clause), ex);
			}
			return retVal;
		}

		public IEnumerable<ValidationResult> Validate()
		{
			if (!ValidateClause(IfcBoxAlignmentClause.WR1))
				yield return new ValidationResult() { Item = this, IssueSource = "IfcBoxAlignment.WR1", IssueType = ValidationFlags.EntityWhereClauses };
		}
	}
}