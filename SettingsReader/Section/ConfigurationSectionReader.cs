using System.Configuration;
using System.Globalization;

using Newtonsoft.Json;



namespace SettingsReader.Section
{
	public class ConfigurationSectionReader : ISettingsReader
	{
		public ConfigurationSectionReader()
		{
		}

		public ConfigurationSectionReader(string sectionName)
		{
			_sectionName = sectionName;
		}

		#region Implementation of ISettingsReader

		public T Read<T>()
		{
			_sectionName = _sectionName ?? CultureInfo.InvariantCulture.TextInfo.ToTitleCase(typeof(T).Name);

			var section = ConfigurationManager.GetSection(_sectionName);
			if (!(section is ConfigurationSectionHandler))
			{
				throw new ConfigurationErrorsException(
					string.Format(
						"The configuration section '{0}' must have a section handler of type '{1}'.",
						_sectionName,
						typeof(ConfigurationSectionHandler).FullName));
			}

			if (section == null)
			{
				throw new ConfigurationErrorsException(string.Format("Could not find configuration section '{0}'.", _sectionName));
			}

			var json = JsonConvert.SerializeXNode(((ConfigurationSectionHandler)section).Element);
			return JsonConvert.DeserializeObject<T>(json);
		}

		#endregion

		public static T Read<T>(string sectionName = null)
		{
			var reader = (ISettingsReader)new ConfigurationSectionReader(sectionName);

			return reader.Read<T>();
		}

		private string _sectionName;
	}
}
