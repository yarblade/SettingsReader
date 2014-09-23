using System;

using SettingsReader.Serialization.Exceptions;



namespace SettingsReader.Exceptions
{
	internal class AppSettingsExceptionWrapper : IExceptionWrapper
	{
		#region Implementation of IExceptionWrapper

		public Exception Wrap(Exception exception)
		{
			if (exception is JsonSerializationException)
			{
				var message = string.Empty;

				return new Exception();
			}

			return exception;
		}

		#endregion
	}
}
