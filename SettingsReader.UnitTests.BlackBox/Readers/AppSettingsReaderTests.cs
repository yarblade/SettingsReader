using System;
using System.Diagnostics.CodeAnalysis;

using FluentAssertions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using SettingsReader.Readers;
using SettingsReader.UnitTests.BlackBox.Entities;



namespace SettingsReader.UnitTests.BlackBox.Readers
{
	[TestClass]
	[ExcludeFromCodeCoverage]
	public class AppSettingsReaderTests
	{
		[TestInitialize]
		public void TestInit()
		{
			_settingsReader = new AppSettingsReader();
		}

		[TestMethod]
		[TestCategory("BlackBox")]
		public void ReadTest()
		{
			var actual = _settingsReader.Read<SimplePlainSettings>();

			Assert.IsNotNull(actual, "Settings shouldn't be null.");
			Assert.AreEqual(-1000000, actual.Int, "Wrong value.");
			Assert.AreEqual(1000000u, actual.Uint, "Wrong value.");
			Assert.AreEqual(-1000000000000, actual.Long, "Wrong value.");
			Assert.AreEqual(1000000000000ul, actual.Ulong, "Wrong value.");
			Assert.AreEqual(100, actual.Byte, "Wrong value.");
			Assert.AreEqual("String", actual.String, "Wrong value.");
			Assert.AreEqual(new DateTime(2010, 10, 10, 10, 10, 10), actual.DateTime, "Wrong value.");
			Assert.AreEqual(new TimeSpan(10, 10, 10), actual.TimeSpan, "Wrong value.");
			Assert.AreEqual(true, actual.Bool, "Wrong value.");
			Assert.AreEqual('c', actual.Char, "Wrong value.");
			Assert.AreEqual(1000000000000.0000000000001, actual.Double, "Wrong value.");
			Assert.AreEqual(1000000000000.100000000000010000000000001m, actual.Decimal, "Wrong value.");

			actual.ShouldBeEquivalentTo(_settingsReader.Read<SimplePlainSettings>("simple"), "Wrong settings.");
		}

		private AppSettingsReader _settingsReader;
	}
}
