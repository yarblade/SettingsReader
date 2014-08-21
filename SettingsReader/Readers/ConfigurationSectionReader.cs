using System.Xml.Linq;

using Newtonsoft.Json.Converters;

using SettingsReader.Converters;
using SettingsReader.Serialization;
using SettingsReader.Serialization.Converters;
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
					new JsonSerializer(new XmlNodeConverter { OmitRootObject = true }),
					new JsonSerializer(new BoolJsonConverter())))
		{
		}
	}
}
