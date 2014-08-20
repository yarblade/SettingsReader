using System;
using System.Configuration;
using System.Xml.Linq;



namespace SettingsReader.Sources
{
	internal class ConfigurationSectionSource : ISettingsSource<XElement>
	{
		#region Implementation of ISettingsSource<XElement>

		public XElement Get(string sourceName)
		{
			if (string.IsNullOrEmpty(sourceName))
			{
				throw new ArgumentException("Source name can't be null or empty", "sourceName");
			} 
			
			var section = ConfigurationManager.GetSection(sourceName);
			if (section == null)
			{
				throw new ConfigurationErrorsException(string.Format("Could not find configuration section '{0}'.", sourceName));
			}

			var handler = section as Configuration.ConfigurationSection;
			if (handler != null)
			{
				return handler.Element;
			}

			throw new ConfigurationErrorsException(
				string.Format(
					"The configuration section '{0}' must have a section handler of type '{1}'.",
					sourceName,
					typeof(Configuration.ConfigurationSection).FullName));
		}

		#endregion
	}
}
