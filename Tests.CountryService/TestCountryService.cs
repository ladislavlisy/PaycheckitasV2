using NUnit.Framework;
using System;
using Paycheckitas.CountryLocalCZ;

namespace Paycheckitas.CountryService
{
	[TestFixture ()]
	public class TestCountryService
	{
		[Test ()]
		public void TestServiceLoad ()
		{
			var module = CountryServiceModule.CreateModule ();

		}
	}
}
