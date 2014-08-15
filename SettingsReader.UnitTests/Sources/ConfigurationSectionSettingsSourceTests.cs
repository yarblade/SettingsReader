using System;
using System.Diagnostics.CodeAnalysis;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using SettingsReader.Sources;



namespace SettingsReader.UnitTests.Sources
{
	[TestClass]
	[ExcludeFromCodeCoverage]
	public class ConfigurationSectionSettingsSourceTests
	{
		[TestInitialize]
		public void TestInit()
		{
			_settingsSource = new ConfigurationSectionSettingsSource();
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

		private ConfigurationSectionSettingsSource _settingsSource;
	}
}
