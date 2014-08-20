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
	public class ConfigurationSectionReaderTests
	{
		[TestInitialize]
		public void TestInit()
		{
			_settingsReader = new ConfigurationSectionReader();
		}

		[TestMethod]
		[TestCategory("BlackBox")]
		public void ReadTest()
		{
			var actual = _settingsReader.Read<ComplexSettings>();

			Assert.IsNotNull(actual, "Settings shouldn't be null.");
			Assert.AreEqual(-1000000, actual.SimplePlainSettings.Int, "Wrong value.");
			Assert.AreEqual(1000000u, actual.SimplePlainSettings.Uint, "Wrong value.");
			Assert.AreEqual(-1000000000000, actual.SimplePlainSettings.Long, "Wrong value.");
			Assert.AreEqual(1000000000000ul, actual.SimplePlainSettings.Ulong, "Wrong value.");
			Assert.AreEqual(100, actual.SimplePlainSettings.Byte, "Wrong value.");
			Assert.AreEqual("String", actual.SimplePlainSettings.String, "Wrong value.");
			Assert.AreEqual(new DateTime(2010, 10, 10, 10, 10, 10), actual.SimplePlainSettings.DateTime, "Wrong value.");
			Assert.AreEqual(new TimeSpan(10, 10, 10), actual.SimplePlainSettings.TimeSpan, "Wrong value.");
			Assert.AreEqual(true, actual.SimplePlainSettings.Bool, "Wrong value.");
			Assert.AreEqual('c', actual.SimplePlainSettings.Char, "Wrong value.");
			Assert.AreEqual(1000000000000.0000000000001, actual.SimplePlainSettings.Double, "Wrong value.");
			Assert.AreEqual(1000000000000.100000000000010000000000001m, actual.SimplePlainSettings.Decimal, "Wrong value.");

			Assert.AreEqual("Совершенный код", actual.Books[0].Name, "Wrong value.");
			Assert.AreEqual("С. Макконнелл", actual.Books[0].Author, "Wrong value.");
			Assert.AreEqual(new DateTime(1993, 9, 10), actual.Books[0].ReleaseDate, "Wrong value.");
			Assert.AreEqual(518, actual.Books[0].Pages, "Wrong value.");
			Assert.AreEqual(true, actual.Books[0].IsReleased, "Wrong value.");

			Assert.AreEqual("Алгоритмы. Построение и анализ", actual.Books[1].Name, "Wrong value.");
			Assert.AreEqual("Томас Кормен, Чарльз Лейзерсон, Рональд Ривест, Клиффорд Штайн", actual.Books[1].Author, "Wrong value.");
			Assert.AreEqual(new DateTime(1987, 5, 17), actual.Books[1].ReleaseDate, "Wrong value.");
			Assert.AreEqual(423, actual.Books[1].Pages, "Wrong value.");
			Assert.AreEqual(true, actual.Books[1].IsReleased, "Wrong value.");

			actual.ShouldBeEquivalentTo(_settingsReader.Read<ComplexSettings>("complex"), "Wrong settings.");
		}

		private ConfigurationSectionReader _settingsReader;
	}
}
