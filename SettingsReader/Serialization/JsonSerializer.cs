using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;



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
				var serializer = Newtonsoft.Json.JsonSerializer.CreateDefault(new JsonSerializerSettings { Converters = _converters });

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
					new JsonSerializerSettings { Converters = _converters, MissingMemberHandling = MissingMemberHandling.Error });

				var errors = new List<ErrorContext>();
				serializer.Error += (sender, args) =>
				{
					errors.Add(args.ErrorContext);

					args.ErrorContext.Handled = true;
				};

				var result = serializer.Deserialize<T>(jsonReader);

				if (errors.Any())
				{
					throw new Exceptions.JsonSerializationException(errors.ToArray());
				}

				return result;
			}
		}

		#endregion

		private readonly JsonConverter[] _converters;
	}
}
