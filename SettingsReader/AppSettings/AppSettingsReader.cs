using System;
using System.Configuration;
using System.Text;

using Newtonsoft.Json;



namespace SettingsReader.AppSettings
{
	public class AppSettingsReader : ISettingsReader
	{
		#region Implementation of ISettingsReader

		public T Read<T>()
		{
			return Read<T>(typeof(T).Name);
		}

		T ISettingsReader.Read<T>(string source)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source", "Source can't be null");
			}

			var sb = new StringBuilder("{");

			foreach (var property in typeof(T).GetProperties())
			{
				var name = source != string.Empty ? source + "." + property.Name : property.Name;
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

		public static T Read<T>(string source = null)
		{
			var reader = (ISettingsReader)new AppSettingsReader();
			return reader.Read<T>(source);
		}
	}
}
