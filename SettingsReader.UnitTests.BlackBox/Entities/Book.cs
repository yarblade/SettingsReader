using System;



namespace SettingsReader.UnitTests.BlackBox.Entities
{
	internal class Book
	{
		public string Name { get; set; }

		public string Author { get; set; }

		public DateTime ReleaseDate { get; set; }

		public int Pages { get; set; }

		public bool IsReleased { get; set; }
	}
}
