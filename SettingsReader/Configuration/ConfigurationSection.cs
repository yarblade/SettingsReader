using System.Xml;
using System.Xml.Linq;



namespace SettingsReader.Configuration
{
	public class ConfigurationSection : System.Configuration.ConfigurationSection
	{
		public XElement Element { get; private set; }

		protected override void DeserializeSection(XmlReader reader)
		{
			var doc = new XmlDocument();

			doc.Load(reader);

			Element = XElement.Parse(doc.OuterXml);
		}
	}
}
