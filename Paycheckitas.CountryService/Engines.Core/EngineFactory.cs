using System;
using System.Reflection;
using Paycheckitas.Common;

namespace Paycheckitas.CountryService.Interfaces
{
	public static class EngineFactory<T>
	{
		public static T InstanceForPattern(Assembly assembly, string namespacePrefix, string classnamePrefix, HistoryPattern pattern)
		{
			return GeneralFactory<T>.InstanceFor(assembly, namespacePrefix, ClassNameFor(classnamePrefix, pattern));
		}

		public static T InstanceForClazz (Assembly assembly, string namespacePrefix, string className)
		{
			return GeneralFactory<T>.InstanceFor (assembly, namespacePrefix, className);
		}

		public static string ClassNameFor(string classnamePrefix, HistoryPattern pattern)
		{
			string className = classnamePrefix + pattern.ClassName();

			return className;
		}
	}

}
