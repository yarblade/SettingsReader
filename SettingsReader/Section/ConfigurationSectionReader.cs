using System;
using System.Configuration;
using System.Globalization;

using Newtonsoft.Json;



namespace SettingsReader.Section
{
	public class ConfigurationSectionReader : ISettingsReader
	{
		#region Implementation of ISettingsReader

		public T Read<T>()
		{
			return Read<T>(CultureInfo.InvariantCulture.TextInfo.ToTitleCase(typeof(T).Name));
		}

		T ISettingsReader.Read<T>(string source)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source", "Source can't be null");
			}

			var section = ConfigurationManager.GetSection(source);
			if (!(section is ConfigurationSectionHandler))
			{
				throw new ConfigurationErrorsException(
					string.Format(
						"The configuration section '{0}' must have a section handler of type '{1}'.",
						source,
						typeof(ConfigurationSectionHandler).FullName));
			}

			if (section == null)
			{
				throw new ConfigurationErrorsException(string.Format("Could not find configuration section '{0}'.", source));
			}

			var json = JsonConvert.SerializeXNode(((ConfigurationSectionHandler)section).Element);
			return JsonConvert.DeserializeObject<T>(json);
		}

		#endregion

		public static T Read<T>(string sectionName = null)
		{
			var reader = (ISettingsReader)new ConfigurationSectionReader();

			return reader.Read<T>(sectionName);
		}
	}
}
