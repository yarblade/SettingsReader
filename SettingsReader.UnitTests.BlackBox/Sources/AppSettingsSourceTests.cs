using System;
using System.Diagnostics.CodeAnalysis;

using FluentAssertions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using SettingsReader.Sources;



namespace SettingsReader.UnitTests.BlackBox.Sources
{
	[TestClass]
	[ExcludeFromCodeCoverage]
	public class AppSettingsSourceTests
	{
		[TestInitialize]
		public void TestInit()
		{
			_settingsSource = new AppSettingsSource();
		}

		[TestMethod]
		[TestCategory("BlackBox")]
		public void GetTest()
		{
			var actual = _settingsSource.Get("SimplePlainSettings");

			Assert.IsNotNull(actual, "Settings shouldn't be null.");
			Assert.AreEqual("-1000000", actual["Int"], "Wrong value.");
			Assert.AreEqual("1000000", actual["Uint"], "Wrong value.");
			Assert.AreEqual("-1000000000000", actual["Long"], "Wrong value.");
			Assert.AreEqual("1000000000000", actual["Ulong"], "Wrong value.");
			Assert.AreEqual("100", actual["Byte"], "Wrong value.");
			Assert.AreEqual("String", actual["String"], "Wrong value.");
			Assert.AreEqual("10.10.10 10:10:10", actual["DateTime"], "Wrong value.");
			Assert.AreEqual("10:10:10", actual["TimeSpan"], "Wrong value.");
			Assert.AreEqual("True", actual["Bool"], "Wrong value.");
			Assert.AreEqual("c", actual["Char"], "Wrong value.");
			Assert.AreEqual("1000000000000.0000000000001", actual["Double"], "Wrong value.");
			Assert.AreEqual("100000000000010000000000001000000000000100000000000010000000000001000000000000", actual["Decimal"], "Wrong value.");

			actual.ShouldBeEquivalentTo(_settingsSource.Get("simple"), "Wrong settings.");
		}

		private AppSettingsSource _settingsSource;
	}
}
