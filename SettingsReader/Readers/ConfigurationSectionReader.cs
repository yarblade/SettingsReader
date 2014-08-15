using System.Xml.Linq;

using SettingsReader.Conversion;
using SettingsReader.Serialization;
using SettingsReader.Sources;



namespace SettingsReader.Readers
{
	public class ConfigurationSectionReader : BaseSettingsReader<XElement>
	{
		public ConfigurationSectionReader()
			: base(new CamelCaseTypeNameConverter(), new ConfigurationSectionSettingsSource(), new XmlConverter(), new JsonSerializer())
		{
		}
	}
}
