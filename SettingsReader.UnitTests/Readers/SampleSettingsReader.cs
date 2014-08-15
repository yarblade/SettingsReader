using SettingsReader.Conversion;
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
			IJsonConverter<SampleSource> converter,
			IJsonSerializer serializer)
			: base(typeNameConverter, source, converter, serializer)
		{
		}
	}
}
