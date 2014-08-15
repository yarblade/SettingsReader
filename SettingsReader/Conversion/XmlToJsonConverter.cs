using System.Xml.Linq;

using Newtonsoft.Json;



namespace SettingsReader.Conversion
{
	internal class XmlConverter : IJsonConverter<XElement>
	{
		#region Implementation of IJsonConverter<XObject>

		public string Convert(XElement data)
		{
			return JsonConvert.SerializeXNode(data, Formatting.Indented);
		}

		#endregion
	}
}
