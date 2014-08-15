namespace SettingsReader.Sources
{
	public interface ISettingsSource<out T>
	{
		T Get(string sourceName);
	}
}
