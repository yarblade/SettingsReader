using System.IO;
using System.Text;

using Newtonsoft.Json;



namespace SettingsReader.Serialization
{
	internal class JsonSerializer : IJsonSerializer
	{
		public JsonSerializer(params JsonConverter[] converters)
		{
			_converters = converters;
		}

		#region Implementation of IJsonSerializer

		public string Serialize<T>(T obj)
		{
			var sb = new StringBuilder();

			using (var writer = new StringWriter(sb))
			{
				var serializer = Newtonsoft.Json.JsonSerializer.CreateDefault(
					new JsonSerializerSettings
					{
						Converters = _converters
					});

				serializer.Serialize(writer, obj);
			}

			return sb.ToString();
		}

		public T Deserialize<T>(string data)
		{
			using (var reader = new StringReader(data))
			using (var jsonReader = new JsonTextReader(reader))
			{
				var serializer = Newtonsoft.Json.JsonSerializer.CreateDefault(
					new JsonSerializerSettings
					{
						Converters = _converters
					});

				return serializer.Deserialize<T>(jsonReader);
			}
		}

		#endregion

		private readonly JsonConverter[] _converters;
	}
}
