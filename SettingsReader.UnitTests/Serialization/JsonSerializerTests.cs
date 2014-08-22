using System;
using System.Diagnostics.CodeAnalysis;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using SettingsReader.Serialization.Converters;
using SettingsReader.UnitTests.Entities;



namespace SettingsReader.UnitTests.Serialization
{
	[TestClass]
	[ExcludeFromCodeCoverage]
	public class JsonSerializerTests
	{
		[TestInitialize]
		public void TestInit()
		{
			_serializer = new SettingsReader.Serialization.JsonSerializer(new BoolJsonConverter());
		}

		[TestMethod]
		public void DeserializeTest()
		{
			const string json = "{ConnectionString:'ConnectionString', Timeout:'ABC', IsTest: true}";

			try
			{
				_serializer.Deserialize<SampleSettings>(json);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}
		}

		private SettingsReader.Serialization.JsonSerializer _serializer;
	}
}
