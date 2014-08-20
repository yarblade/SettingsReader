using System.Xml.Linq;

using Newtonsoft.Json.Converters;

using SettingsReader.Conversion;
using SettingsReader.Serialization;
using SettingsReader.Sources;



namespace SettingsReader.Readers
{
	public class ConfigurationSectionReader : BaseSettingsReader<XElement>
	{
		public ConfigurationSectionReader()
			: base(
				new CamelCaseTypeNameConverter(),
				new ConfigurationSectionSource(),
				new Deserializer<XElement>(
					new JsonSerializer(new XmlNodeConverter()),
					new JsonSerializer()))
		{
		}
	}
}
