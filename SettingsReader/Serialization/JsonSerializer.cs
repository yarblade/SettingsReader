using System.IO;
using System.Text;

using Newtonsoft.Json;



namespace SettingsReader.Serialization
{
	internal class JsonSerializer : IJsonSerializer
	{
		#region Implementation of IJsonSerializer

		public string Serialize<T>(T obj)
		{
			var sb = new StringBuilder();

			using (var writer = new StringWriter(sb))
			{
				new Newtonsoft.Json.JsonSerializer().Serialize(writer, obj);
			}

			return sb.ToString();
		}

		public T Deserialize<T>(string data)
		{
			using (var reader = new StringReader(data))
			using (var jsonReader = new JsonTextReader(reader))
			{
				return new Newtonsoft.Json.JsonSerializer().Deserialize<T>(jsonReader);
			}
		}

		#endregion
	}
}
