using System;

using Newtonsoft.Json;



namespace SettingsReader.Serialization.Converters
{
	internal class BoolJsonConverter : JsonConverter
	{
		public override bool CanRead { get { return true; } }

		public override bool CanWrite { get { return false; } }

		public override void WriteJson(JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer)
		{
			bool result;
			return true.Equals(reader.Value) || (reader.Value != null && (bool.TryParse(reader.Value.ToString(), out result) && result));
		}

		public override bool CanConvert(Type objectType)
		{
			return objectType == typeof(bool);
		}
	}
}
