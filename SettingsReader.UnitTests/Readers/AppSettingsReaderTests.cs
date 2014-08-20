using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

using SettingsReader.Conversion;
using SettingsReader.Readers;
using SettingsReader.Serialization;
using SettingsReader.Sources;



namespace SettingsReader.UnitTests.Readers
{
	[TestClass]
	[ExcludeFromCodeCoverage]
	public class AppSettingsReaderTests
	{
		[TestInitialize]
		public void TestInit()
		{
			_reader = new AppSettingsReader();
		}

		[TestMethod]
		public void ConstructorTest()
		{
			var actual = TestHelper.GetFieldValue(_reader, "_typeNameConverter");
			Assert.IsNotNull(actual, "Field can't be null.");
			Assert.AreEqual(typeof(TypeNameConverter), actual.GetType(), "Wrong field type.");

			actual = TestHelper.GetFieldValue(_reader, "_source");
			Assert.IsNotNull(actual, "Field can't be null.");
			Assert.AreEqual(typeof(AppSettingsSource), actual.GetType(), "Wrong field type.");

			var deserializer = TestHelper.GetFieldValue(_reader, "_deserializer");
			Assert.IsNotNull(deserializer, "Field can't be null.");
			Assert.AreEqual(typeof(Deserializer<IDictionary<string, string>>), deserializer.GetType(), "Wrong field type.");

			var jsonSerializer = TestHelper.GetFieldValue(deserializer, "_serializer");
			Assert.IsNotNull(jsonSerializer, "Field can't be null.");
			Assert.AreEqual(typeof(Serialization.JsonSerializer), jsonSerializer.GetType(), "Wrong field type.");

			actual = TestHelper.GetFieldValue(jsonSerializer, "_converters");
			Assert.IsNotNull(actual, "Field can't be null.");
			Assert.AreEqual(typeof(JsonConverter[]), actual.GetType(), "Wrong field type.");
			Assert.AreEqual(1, ((JsonConverter[])actual).Length, "Wrong field length.");
			Assert.AreEqual(typeof(KeyValuePairConverter), ((JsonConverter[])actual)[0].GetType(), "Wrong field type.");

			jsonSerializer = TestHelper.GetFieldValue(deserializer, "_deserializer");
			Assert.IsNotNull(jsonSerializer, "Field can't be null.");
			Assert.AreEqual(typeof(Serialization.JsonSerializer), jsonSerializer.GetType(), "Wrong field type.");

			actual = TestHelper.GetFieldValue(jsonSerializer, "_converters");
			Assert.IsNotNull(actual, "Field can't be null.");
			Assert.AreEqual(typeof(JsonConverter[]), actual.GetType(), "Wrong field type.");
			Assert.AreEqual(0, ((JsonConverter[])actual).Length, "Wrong field length.");
		}

		private AppSettingsReader _reader;
	}
}
