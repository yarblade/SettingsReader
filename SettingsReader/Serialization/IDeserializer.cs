namespace SettingsReader.Serialization
{
	public interface IDeserializer<in TSource>
	{
		TTarget Deserialize<TTarget>(TSource source);
	}
}
