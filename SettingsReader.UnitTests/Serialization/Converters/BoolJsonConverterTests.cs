using System;
using System.Diagnostics.CodeAnalysis;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

using Newtonsoft.Json;

using SettingsReader.Serialization.Converters;
using SettingsReader.UnitTests.Entities;



namespace SettingsReader.UnitTests.Serialization.Converters
{
	[TestClass]
	[ExcludeFromCodeCoverage]
	public class BoolJsonConverterTests
	{
		[TestInitialize]
		public void TestInit()
		{
			_converter = new BoolJsonConverter();
		}

		[TestMethod]
		public void CanReadTest()
		{
			Assert.AreEqual(true, _converter.CanRead, "Wrong property value.");
		}

		[TestMethod]
		public void CanWriteTest()
		{
			Assert.AreEqual(true, _converter.CanWrite, "Wrong property value.");
		}

		[TestMethod]
		public void CanConvertTest()
		{
			Assert.AreEqual(true, _converter.CanConvert(typeof(bool)), "Wrong returned value.");
			Assert.AreEqual(false, _converter.CanConvert(typeof(int)), "Wrong returned value.");
			Assert.AreEqual(false, _converter.CanConvert(typeof(string)), "Wrong returned value.");
			Assert.AreEqual(false, _converter.CanConvert(typeof(SampleSource)), "Wrong returned value.");
		}

		[TestMethod]
		public void ReadJsonTest()
		{
			ReadJsonTest(true, true);
			ReadJsonTest(true, "true");
			ReadJsonTest(true, "True");
			ReadJsonTest(true, "TRUE");
			ReadJsonTest(false, null);
			ReadJsonTest(false, false);
			ReadJsonTest(false, "false");
			ReadJsonTest(false, "False");
			ReadJsonTest(false, "string");
			ReadJsonTest(false, 0);
			ReadJsonTest(false, 1);
			ReadJsonTest(false, new object());
			ReadJsonTest(false, DateTime.UtcNow);
			ReadJsonTest(false, new BoolJsonConverter());
		}

		[TestMethod]
		public void WriteJsonTest()
		{
			WriteJsonTest(true, true);
			WriteJsonTest(true, "true");
			WriteJsonTest(true, "True");
			WriteJsonTest(true, "TRUE");
			WriteJsonTest(false, null);
			WriteJsonTest(false, false);
			WriteJsonTest(false, "false");
			WriteJsonTest(false, "False");
			WriteJsonTest(false, "string");
			WriteJsonTest(false, 0);
			WriteJsonTest(false, 1);
			WriteJsonTest(false, new object());
			WriteJsonTest(false, DateTime.UtcNow);
			WriteJsonTest(false, new BoolJsonConverter());
		}
		
		private void ReadJsonTest(bool expected, object value)
		{
			var reader = new Mock<JsonReader>(MockBehavior.Strict);

			reader.Setup(x => x.Value).Returns(value);

			var actual = _converter.ReadJson(reader.Object, It.IsAny<Type>(), It.IsAny<object>(), It.IsAny<JsonSerializer>());
			Assert.AreEqual(expected, actual, "Wrong returned value.");

			reader.Verify(x => x.Value, Times.AtLeastOnce());
		}

		private void WriteJsonTest(bool expected, object value)
		{
			var writer = new Mock<JsonWriter>(MockBehavior.Strict); 

			writer.Setup(x => x.WriteValue(expected));

			_converter.WriteJson(writer.Object, value, It.IsAny<JsonSerializer>());

			writer.Verify(x => x.WriteValue(expected), Times.Once());
		}

		private BoolJsonConverter _converter;
	}
}
