using System;



namespace SettingsReader.UnitTests.BlackBox.Entities
{
	internal class SimplePlainSettings
	{
		public int Int { get; set; }

		public uint Uint { get; set; }
		
		public long Long { get; set; }

		public ulong Ulong { get; set; }

		public byte Byte { get; set; }

		public string String { get; set; }

		public DateTime DateTime { get; set; }

		public TimeSpan TimeSpan { get; set; }

		public bool Bool { get; set; }
		
		public char Char { get; set; }
		
		public double Double { get; set; }

		public decimal Decimal { get; set; }
	}
}
