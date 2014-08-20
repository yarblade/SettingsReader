namespace SettingsReader.UnitTests.BlackBox.Entities
{
	internal class ComplexSettings
	{
		public SimplePlainSettings SimplePlainSettings { get; set; }

		public Book[] Books { get; set; }
	}
}
