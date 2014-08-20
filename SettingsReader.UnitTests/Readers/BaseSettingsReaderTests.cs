using System.Diagnostics.CodeAnalysis;

using FluentAssertions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

using Ploeh.AutoFixture;

using SettingsReader.Conversion;
using SettingsReader.Readers;
using SettingsReader.Serialization;
using SettingsReader.Sources;
using SettingsReader.UnitTests.Entities;



namespace SettingsReader.UnitTests.Readers
{
	[TestClass]
	[ExcludeFromCodeCoverage]
	public class BaseSettingsReaderTests
	{
		[TestInitialize]
		public void TestInit()
		{
			_fixture = new Fixture();
			_typeNameConverter = new Mock<ITypeNameConverter>(MockBehavior.Strict);
			_settingsSource = new Mock<ISettingsSource<SampleSource>>(MockBehavior.Strict);
			_deserializer = new Mock<IDeserializer<SampleSource>>(MockBehavior.Strict);

			_baseSettingsReader = new SampleSettingsReader(_typeNameConverter.Object, _settingsSource.Object, _deserializer.Object);
		}

		[TestMethod]
		public void ReadTest()
		{
			var source = _fixture.Create<SampleSource>();
			var typeName = _fixture.Create<string>();
			var settings = _fixture.Create<SampleSettings>();

			_typeNameConverter.Setup(x => x.Convert(typeof(SampleSettings))).Returns(typeName);
			_settingsSource.Setup(x => x.Get(typeName)).Returns(source);
			_deserializer.Setup(x => x.Deserialize<SampleSettings>(source)).Returns(settings);

			var actual = _baseSettingsReader.Read<SampleSettings>();
			actual.ShouldBeEquivalentTo(settings, "Wrong settings.");

			_typeNameConverter.Verify(x => x.Convert(typeof(SampleSettings)), Times.Once());
			_settingsSource.Verify(x => x.Get(typeName), Times.Once());
			_deserializer.Verify(x => x.Deserialize<SampleSettings>(source), Times.Once());
		}

		[TestMethod]
		public void ReadWithSourceNameTest()
		{
			var source = _fixture.Create<SampleSource>();
			var sourceName = _fixture.Create<string>();
			var settings = _fixture.Create<SampleSettings>();

			_settingsSource.Setup(x => x.Get(sourceName)).Returns(source);
			_deserializer.Setup(x => x.Deserialize<SampleSettings>(source)).Returns(settings);

			var actual = _baseSettingsReader.Read<SampleSettings>(sourceName);
			actual.ShouldBeEquivalentTo(settings, "Wrong settings.");

			_settingsSource.Verify(x => x.Get(sourceName), Times.Once());
			_deserializer.Verify(x => x.Deserialize<SampleSettings>(source), Times.Once());
		}

		private BaseSettingsReader<SampleSource> _baseSettingsReader;
		private Mock<IDeserializer<SampleSource>> _deserializer;
		private IFixture _fixture;
		private Mock<ISettingsSource<SampleSource>> _settingsSource;
		private Mock<ITypeNameConverter> _typeNameConverter;
	}
}
