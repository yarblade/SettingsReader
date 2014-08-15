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
			_jsonConverter = new Mock<IJsonConverter<SampleSource>>(MockBehavior.Strict);
			_serializer = new Mock<IJsonSerializer>(MockBehavior.Strict);

			_baseSettingsReader = new SampleSettingsReader(_typeNameConverter.Object, _settingsSource.Object, _jsonConverter.Object, _serializer.Object);
		}

		[TestMethod]
		public void ReadTest()
		{
			var source = _fixture.Create<SampleSource>();
			var typeName = _fixture.Create<string>();
			var json = _fixture.Create<string>();
			var settings = _fixture.Create<SampleSettings>();

			_typeNameConverter.Setup(x => x.Convert(typeof(SampleSettings))).Returns(typeName);
			_settingsSource.Setup(x => x.Get(typeName)).Returns(source);
			_jsonConverter.Setup(x => x.Convert(source)).Returns(json);
			_serializer.Setup(x => x.Deserialize<SampleSettings>(json)).Returns(settings);

			var actual = _baseSettingsReader.Read<SampleSettings>();
			actual.ShouldBeEquivalentTo(settings, "Wrong settings.");

			_typeNameConverter.Verify(x => x.Convert(typeof(SampleSettings)), Times.Once());
			_settingsSource.Verify(x => x.Get(typeName), Times.Once());
			_jsonConverter.Verify(x => x.Convert(source), Times.Once());
			_serializer.Verify(x => x.Deserialize<SampleSettings>(json), Times.Once());
		}

		[TestMethod]
		public void ReadWithSourceNameTest()
		{
			var source = _fixture.Create<SampleSource>();
			var sourceName = _fixture.Create<string>();
			var json = _fixture.Create<string>();
			var settings = _fixture.Create<SampleSettings>();

			_settingsSource.Setup(x => x.Get(sourceName)).Returns(source);
			_jsonConverter.Setup(x => x.Convert(source)).Returns(json);
			_serializer.Setup(x => x.Deserialize<SampleSettings>(json)).Returns(settings);

			var actual = _baseSettingsReader.Read<SampleSettings>(sourceName);
			actual.ShouldBeEquivalentTo(settings, "Wrong settings.");

			_settingsSource.Verify(x => x.Get(sourceName), Times.Once());
			_jsonConverter.Verify(x => x.Convert(source), Times.Once());
			_serializer.Verify(x => x.Deserialize<SampleSettings>(json), Times.Once());
		}

		private BaseSettingsReader<SampleSource> _baseSettingsReader;
		private IFixture _fixture;
		private Mock<IJsonConverter<SampleSource>> _jsonConverter;
		private Mock<IJsonSerializer> _serializer;
		private Mock<ISettingsSource<SampleSource>> _settingsSource;
		private Mock<ITypeNameConverter> _typeNameConverter;
	}
}
