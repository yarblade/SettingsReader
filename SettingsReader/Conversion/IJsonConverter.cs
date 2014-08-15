namespace SettingsReader.Conversion
{
	public interface IJsonConverter<in T>
	{
		string Convert(T data);
	}
}
