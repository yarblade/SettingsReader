using System;
using System.Reflection;



namespace SettingsReader.UnitTests
{
	internal static class TestHelper
	{
		public static object GetFieldValue<T>(T obj, string fieldName)
		{
			var fieldInfo = GetPrivateFieldInfo(obj.GetType(), fieldName) ?? GetPrivateFieldInfo(obj.GetType().BaseType, fieldName);
			if (fieldInfo == null)
			{
				throw new InvalidOperationException(string.Format("Can't find field {0} in type {1}.", fieldName, obj.GetType()));
			}

			return fieldInfo.GetValue(obj);
		}

		private static FieldInfo GetPrivateFieldInfo(Type type, string fieldName)
		{
			return type.GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance);
		}
	}
}
