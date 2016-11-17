using System;
using System.Reflection;
using Paycheckitas.Common;

namespace Paycheckitas.CountryService.Interfaces
{
	public static class EngineFactory<T>
	{
		public static T InstanceFor(Assembly assembly, string namespacePrefix, string classnamePrefix, HistoryPattern pattern)
		{
			return GeneralFactory<T>.InstanceFor(assembly, namespacePrefix, ClassNameFor(classnamePrefix, pattern));
		}

		public static string ClassNameFor(string classnamePrefix, HistoryPattern pattern)
		{
			string className = classnamePrefix + pattern.ClassName();

			return className;
		}
	}

}
