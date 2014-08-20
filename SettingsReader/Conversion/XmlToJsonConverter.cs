using System.Xml.Linq;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;



namespace SettingsReader.Conversion
{
	internal class XmlConverter : IJsonConverter<XElement>
	{
		#region Implementation of IJsonConverter<XObject>

		public string Convert(XElement data)
		{
			return JsonConvert.SerializeObject(data, Formatting.Indented, new XmlNodeConverter { OmitRootObject = true });
		}

		#endregion
	}
}
