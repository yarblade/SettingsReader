using System;



namespace SettingsReader.Conversion
{
	internal class TypeNameConverter : ITypeNameConverter
	{
		public string Convert(Type type)
		{
			return type.Name;
		}
	}
}
