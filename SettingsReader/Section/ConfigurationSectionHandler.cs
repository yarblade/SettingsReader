using System.Configuration;
using System.Xml;
using System.Xml.Linq;

namespace SettingsReader.Section
{
	public class ConfigurationSectionHandler : ConfigurationSection
	{
		protected override void DeserializeSection(XmlReader reader)
		{
			Element = XElement.Load(reader);
		}

		public XElement Element { get; private set; }
	}
}
