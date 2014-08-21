using System;



namespace SettingsReader.Converters
{
	public interface ITypeNameConverter
	{
		string Convert(Type type);
	}
}
