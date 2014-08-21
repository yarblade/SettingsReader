using System;



namespace SettingsReader.Converters
{
	internal class CamelCaseTypeNameConverter : ITypeNameConverter
	{
		#region Implementation of ITypeNameConverter

		public string Convert(Type type)
		{
			return type.Name.Substring(0, 1).ToLowerInvariant() + type.Name.Substring(1);
		}

		#endregion
	}
}
