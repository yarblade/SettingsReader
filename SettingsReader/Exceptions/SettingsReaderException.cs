using System;



namespace SettingsReader.Exceptions
{
	public class SettingsReaderException : Exception
	{
		public SettingsReaderException()
		{
		}

		public SettingsReaderException(string message)
			: base(message)
		{
		}

		public SettingsReaderException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
	}
}
