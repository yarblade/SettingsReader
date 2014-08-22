using System;



namespace SettingsReader.UnitTests.Entities
{
	internal class SampleSettings
	{
		public string ConnectionString { get; set; }

		public TimeSpan Timeout { get; set; }

		public int Count { get; set; }

		public bool IsTest { get; set; }
	}
}
