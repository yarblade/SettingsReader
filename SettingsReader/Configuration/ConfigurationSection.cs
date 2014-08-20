using System.Xml;
using System.Xml.Linq;



namespace SettingsReader.Configuration
{
	public class ConfigurationSection : System.Configuration.ConfigurationSection
	{
		public XElement Element { get; set; }

		protected override void DeserializeSection(XmlReader reader)
		{
			Element = XElement.Load(reader);
		}
	}
}
