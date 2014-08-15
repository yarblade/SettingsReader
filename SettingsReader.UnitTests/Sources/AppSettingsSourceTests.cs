using System;
using System.Diagnostics.CodeAnalysis;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using SettingsReader.Sources;



namespace SettingsReader.UnitTests.Sources
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
		[ExpectedException(typeof(ArgumentException))]
		public void GetWithNullableSourceNameTest()
		{
			_settingsSource.Get(null);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void GetWithEmptySourceNameTest()
		{
			_settingsSource.Get(string.Empty);
		}

		private AppSettingsSource _settingsSource;
	}
}
