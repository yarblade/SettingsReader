using System;

using Newtonsoft.Json.Serialization;



namespace SettingsReader.Serialization.Exceptions
{
	internal class JsonSerializationException : Exception
	{
		public JsonSerializationException(ErrorContext[] errors)
		{
			Errors = errors;
		}

		public ErrorContext[] Errors { get; private set; }
	}
}
