namespace SettingsReader
{
	public interface ISettingsReader
	{
		T Read<T>();
		T Read<T>(string sourceName);
	}
}
