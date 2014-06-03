using System.Configuration;
using System.Text;

using Newtonsoft.Json;



namespace SettingsReader.AppSettings
{
	public class AppSettingsReader : ISettingsReader
	{
		public AppSettingsReader()
		{
		}

		public AppSettingsReader(string prefix)
		{
			_prefix = prefix;
		}

		#region Implementation of ISettingsReader

		public T Read<T>()
		{
			_prefix = _prefix ?? typeof(T).Name;

			var sb = new StringBuilder("{");

			foreach (var property in typeof(T).GetProperties())
			{
				var name = _prefix != string.Empty ? _prefix + "." + property.Name : property.Name;
				var value = ConfigurationManager.AppSettings[name];
				if (value == null)
				{
					throw new ConfigurationErrorsException(string.Format("Could not find {0} setting in AppSettings.", name));
				}

				sb.AppendLine(string.Format("'{0}':'{1}',", property.Name, value));
			}

			sb.AppendLine("}");

			return JsonConvert.DeserializeObject<T>(sb.ToString());
		}

		#endregion

		public static T Read<T>(string prefix = null)
		{
			var reader = new AppSettingsReader(prefix);
			return reader.Read<T>();
		}

		private string _prefix;
	}
}
