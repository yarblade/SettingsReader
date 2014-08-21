using System.Diagnostics.CodeAnalysis;
using System.Xml.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

using SettingsReader.Converters;
using SettingsReader.Readers;
using SettingsReader.Serialization;
using SettingsReader.Serialization.Converters;
using SettingsReader.Sources;



namespace SettingsReader.UnitTests.Readers
{
	[TestClass]
	[ExcludeFromCodeCoverage]
	public class ConfigurationSectionReaderTests
	{
		[TestInitialize]
		public void TestInit()
		{
			_reader = new ConfigurationSectionReader();
		}

		[TestMethod]
		public void ConstructorTest()
		{
			var actual = TestHelper.GetFieldValue(_reader, "_typeNameConverter");
			Assert.IsNotNull(actual, "Field can't be null.");
			Assert.AreEqual(typeof(CamelCaseTypeNameConverter), actual.GetType(), "Wrong field type.");

			actual = TestHelper.GetFieldValue(_reader, "_source");
			Assert.IsNotNull(actual, "Field can't be null.");
			Assert.AreEqual(typeof(ConfigurationSectionSource), actual.GetType(), "Wrong field type.");

			var deserializer = TestHelper.GetFieldValue(_reader, "_deserializer");
			Assert.IsNotNull(deserializer, "Field can't be null.");
			Assert.AreEqual(typeof(Deserializer<XElement>), deserializer.GetType(), "Wrong field type.");

			var jsonSerializer = TestHelper.GetFieldValue(deserializer, "_serializer");
			Assert.IsNotNull(jsonSerializer, "Field can't be null.");
			Assert.AreEqual(typeof(Serialization.JsonSerializer), jsonSerializer.GetType(), "Wrong field type.");

			actual = TestHelper.GetFieldValue(jsonSerializer, "_converters");
			Assert.IsNotNull(actual, "Field can't be null.");
			Assert.AreEqual(typeof(JsonConverter[]), actual.GetType(), "Wrong field type.");
			Assert.AreEqual(1, ((JsonConverter[])actual).Length, "Wrong field length.");
			Assert.AreEqual(typeof(XmlNodeConverter), ((JsonConverter[])actual)[0].GetType(), "Wrong field type.");

			jsonSerializer = TestHelper.GetFieldValue(deserializer, "_deserializer");
			Assert.IsNotNull(jsonSerializer, "Field can't be null.");
			Assert.AreEqual(typeof(Serialization.JsonSerializer), jsonSerializer.GetType(), "Wrong field type.");

			actual = TestHelper.GetFieldValue(jsonSerializer, "_converters");
			Assert.IsNotNull(actual, "Field can't be null.");
			Assert.AreEqual(typeof(JsonConverter[]), actual.GetType(), "Wrong field type.");
			Assert.AreEqual(1, ((JsonConverter[])actual).Length, "Wrong field length.");
			Assert.AreEqual(typeof(BoolJsonConverter), ((JsonConverter[])actual)[0].GetType(), "Wrong field type.");
		}

		private ConfigurationSectionReader _reader;
	}
}
