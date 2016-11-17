using System;
using Paycheckitas.CountryLocalCZ.Employ;
using Paycheckitas.CountryService.Employ;

namespace Paycheckitas.CountryService.History.EmployEngines
{
	public class EmployEngine2016 : EmployEnginePrototype
	{
		public EmployEngine2016 () : base(EmployGuidesCZ.Guides2016 ())
		{
		}

		#region implemented abstract members of EmployEnginePrototype
		#endregion

	}
}
