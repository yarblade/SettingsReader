using SettingsReader.Converters;
using SettingsReader.Readers;
using SettingsReader.Serialization;
using SettingsReader.Sources;
using SettingsReader.UnitTests.Entities;



namespace SettingsReader.UnitTests.Readers
{
	internal class SampleSettingsReader : BaseSettingsReader<SampleSource>
	{
		public SampleSettingsReader(
			ITypeNameConverter typeNameConverter,
			ISettingsSource<SampleSource> source,
			IDeserializer<SampleSource> deserializer)
			: base(typeNameConverter, source, deserializer)
		{
		}
	}
}
