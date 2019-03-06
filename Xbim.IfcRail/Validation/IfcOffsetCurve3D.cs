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
namespace Xbim.IfcRail.GeometryResource
{
	public partial class IfcOffsetCurve3D : IExpressValidatable
	{
		public enum IfcOffsetCurve3DClause
		{
			DimIs2D,
		}

		/// <summary>
		/// Tests the express where-clause specified in param 'clause'
		/// </summary>
		/// <param name="clause">The express clause to test</param>
		/// <returns>true if the clause is satisfied.</returns>
		public bool ValidateClause(IfcOffsetCurve3DClause clause) {
			var retVal = false;
			try
			{
				switch (clause)
				{
					case IfcOffsetCurve3DClause.DimIs2D:
						retVal = BasisCurve.Dim == 3;
						break;
				}
			} catch (Exception  ex) {
				var log = Validation.ValidationLogging.CreateLogger<Xbim.IfcRail.GeometryResource.IfcOffsetCurve3D>();
				log?.LogError(string.Format("Exception thrown evaluating where-clause 'IfcOffsetCurve3D.{0}' for #{1}.", clause,EntityLabel), ex);
			}
			return retVal;
		}

		public virtual IEnumerable<ValidationResult> Validate()
		{
			if (!ValidateClause(IfcOffsetCurve3DClause.DimIs2D))
				yield return new ValidationResult() { Item = this, IssueSource = "IfcOffsetCurve3D.DimIs2D", IssueType = ValidationFlags.EntityWhereClauses };
		}
	}
}
