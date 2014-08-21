using System;



namespace SettingsReader.Converters
{
	internal class TypeNameConverter : ITypeNameConverter
	{
		public string Convert(Type type)
		{
			return type.Name;
		}
	}
}
