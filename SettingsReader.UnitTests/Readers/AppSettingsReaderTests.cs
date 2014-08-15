﻿using System.Diagnostics.CodeAnalysis;

using Microsoft.VisualStudio.TestTools.UnitTesting;

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
			Assert.AreEqual(typeof(TypeNameConverter), actual.GetType(), "Wrong field name.");

			actual = TestHelper.GetFieldValue(_reader, "_source");
			Assert.IsNotNull(actual, "Field can't be null.");
			Assert.AreEqual(typeof(AppSettingsSource), actual.GetType(), "Wrong field name.");

			actual = TestHelper.GetFieldValue(_reader, "_converter");
			Assert.IsNotNull(actual, "Field can't be null.");
			Assert.AreEqual(typeof(DictionaryToJsonConverter), actual.GetType(), "Wrong field name.");

			actual = TestHelper.GetFieldValue(_reader, "_serializer");
			Assert.IsNotNull(actual, "Field can't be null.");
			Assert.AreEqual(typeof(JsonSerializer), actual.GetType(), "Wrong field name.");
		}

		private AppSettingsReader _reader;
	}
}
