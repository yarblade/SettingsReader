using System.Configuration;
using System.Globalization;

using Newtonsoft.Json;



namespace SettingsReader.Section
{
	public class ConfigurationSectionReader : ISettingsReader
	{
		#region Implementation of ISettingsReader

		T ISettingsReader.Read<T>(string source)
		{
			source = source ?? CultureInfo.InvariantCulture.TextInfo.ToTitleCase(typeof(T).Name);

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

		public static T Read<T>(string sectionName)
		{
			var reader = (ISettingsReader)new ConfigurationSectionReader();

			return reader.Read<T>(sectionName);
		}
	}
}
