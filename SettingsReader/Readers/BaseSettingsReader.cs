using SettingsReader.Conversion;
using SettingsReader.Serialization;
using SettingsReader.Sources;



namespace SettingsReader.Readers
{
	public abstract class BaseSettingsReader<TSource> : ISettingsReader
	{
		protected BaseSettingsReader(
			ITypeNameConverter typeNameConverter,
			ISettingsSource<TSource> source,
			IDeserializer<TSource> deserializer)
		{
			_typeNameConverter = typeNameConverter;
			_source = source;
			_deserializer = deserializer;
		}

		#region Implementation of ISettingsReader

		public T Read<T>()
		{
			return Read<T>(_typeNameConverter.Convert(typeof(T)));
		}

		public T Read<T>(string sourceName)
		{
			var data = _source.Get(sourceName);

			return _deserializer.Deserialize<T>(data);
		}

		#endregion

		private readonly IDeserializer<TSource> _deserializer;
		private readonly ISettingsSource<TSource> _source;
		private readonly ITypeNameConverter _typeNameConverter;
	}
}
