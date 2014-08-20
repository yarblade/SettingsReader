namespace SettingsReader.Serialization
{
	internal class Deserializer<T> : IDeserializer<T>
	{
		public Deserializer(IJsonSerializer serializer, IJsonSerializer deserializer)
		{
			_serializer = serializer;
			_deserializer = deserializer;
		}

		#region Implementation of IDeserializer<T>

		public TTarget Deserialize<TTarget>(T source)
		{
			var json = _serializer.Serialize(source);

			return _deserializer.Deserialize<TTarget>(json);
		}

		#endregion

		private readonly IJsonSerializer _serializer;
		private readonly IJsonSerializer _deserializer;
	}
}
