using System.Collections.Generic;

using SettingsReader.Conversion;
using SettingsReader.Serialization;
using SettingsReader.Sources;



namespace SettingsReader.Readers
{
	public class AppSettingsReader : BaseSettingsReader<IDictionary<string, string>>
	{
		public AppSettingsReader()
			: base(new TypeNameConverter(), new AppSettingsSource(), new DictionaryToJsonConverter(), new JsonSerializer())
		{
		}
	}
}
