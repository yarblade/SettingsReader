using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;



namespace SettingsReader.Sources
{
	internal class AppSettingsSource : ISettingsSource<IDictionary<string, string>>
	{
		#region Implementation of ISettingsSource<IDictionary<string,string>>

		public IDictionary<string, string> Get(string sourceName)
		{
			if (string.IsNullOrEmpty(sourceName))
			{
				throw new ArgumentException("Source name can't be null or empty", "sourceName");
			}

			var startIndex = sourceName.Length + 1;

			return ConfigurationManager.AppSettings.AllKeys
				.Where(key => key.StartsWith(sourceName + Delimiter))
				.ToDictionary(key => key.Substring(startIndex), key => ConfigurationManager.AppSettings[key]);
		}

		#endregion

		private const string Delimiter = ".";
	}
}
