using System.Collections.Generic;

using Newtonsoft.Json.Linq;



namespace SettingsReader.Conversion
{
	internal class DictionaryToJsonConverter : IJsonConverter<IDictionary<string, string>>
	{
		#region Implementation of IJsonConverter<IDictionary<string,string>>

		public string Convert(IDictionary<string, string> data)
		{
			var jObject = new JObject();

			foreach (var pair in data)
			{
				jObject.Add(pair.Key, new JValue(pair.Value));
			}

			return jObject.ToString();
		}

		#endregion
	}
}
