namespace SettingsReader
{
	public interface ISettingsReader
	{
		T Read<T>();
	}
}
