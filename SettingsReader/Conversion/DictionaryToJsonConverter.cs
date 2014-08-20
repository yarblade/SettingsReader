using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;



namespace SettingsReader.Conversion
{
	internal class DictionaryToJsonConverter : IJsonConverter<IDictionary<string, string>>
	{
		#region Implementation of IJsonConverter<IDictionary<string,string>>

		public string Convert(IDictionary<string, string> data)
		{
			return JsonConvert.SerializeObject(data, Formatting.Indented, new KeyValuePairConverter());
		}

		#endregion
	}
}
