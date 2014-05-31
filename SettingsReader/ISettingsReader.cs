namespace SettingsReader
{
	public interface ISettingsReader
	{
		T Read<T>(string source);
	}
}
