using System;



namespace SettingsReader.Conversion
{
	public interface ITypeNameConverter
	{
		string Convert(Type type);
	}
}
