using SettingsReader.Conversion;
using SettingsReader.Serialization;
using SettingsReader.Sources;



namespace SettingsReader
{
	public abstract class BaseSettingsReader<TSource> : ISettingsReader
	{
		protected BaseSettingsReader(
			ITypeNameConverter typeNameConverter,
			ISettingsSource<TSource> source,
			IJsonConverter<TSource> converter,
			IJsonSerializer serializer)
		{
			_typeNameConverter = typeNameConverter;
			_source = source;
			_serializer = serializer;
			_converter = converter;
		}

		#region Implementation of ISettingsReader

		public T Read<T>()
		{
			return Read<T>(_typeNameConverter.Convert(typeof(T)));
		}

		public T Read<T>(string sourceName)
		{
			var data = _source.Get(sourceName);

			var json = _converter.Convert(data);

			return _serializer.Deserialize<T>(json);
		}

		#endregion

		private readonly IJsonConverter<TSource> _converter;
		private readonly IJsonSerializer _serializer;
		private readonly ISettingsSource<TSource> _source;
		private readonly ITypeNameConverter _typeNameConverter;
	}
}
