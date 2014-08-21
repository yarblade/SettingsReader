using System.Diagnostics.CodeAnalysis;

using FluentAssertions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

using Ploeh.AutoFixture;

using SettingsReader.Serialization;
using SettingsReader.UnitTests.Entities;



namespace SettingsReader.UnitTests.Serialization
{
	[TestClass]
	[ExcludeFromCodeCoverage]
	public class DeserializerTests
	{
		[TestInitialize]
		public void TestInit()
		{
			_fixture = new Fixture();
			_jsonSerializer = new Mock<IJsonSerializer>(MockBehavior.Strict);
			_jsonDeserializer = new Mock<IJsonSerializer>(MockBehavior.Strict);

			_deserializer = new Deserializer<SampleSource>(_jsonSerializer.Object, _jsonDeserializer.Object);
		}

		[TestMethod]
		public void DeserializeTest()
		{
			var source = _fixture.Create<SampleSource>();
			var settings = _fixture.Create<SampleSettings>();
			var json = _fixture.Create<string>();

			_jsonSerializer.Setup(x => x.Serialize(source)).Returns(json);
			_jsonDeserializer.Setup(x => x.Deserialize<SampleSettings>(json)).Returns(settings);

			var actual = _deserializer.Deserialize<SampleSettings>(source);
			actual.ShouldBeEquivalentTo(settings, "Wrong settings.");

			_jsonSerializer.Verify(x => x.Serialize(source), Times.Once());
			_jsonDeserializer.Verify(x => x.Deserialize<SampleSettings>(json), Times.Once());
		}

		private Deserializer<SampleSource> _deserializer;
		private IFixture _fixture;
		private Mock<IJsonSerializer> _jsonDeserializer;
		private Mock<IJsonSerializer> _jsonSerializer;
	}
}
