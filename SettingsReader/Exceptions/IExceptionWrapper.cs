using System;



namespace SettingsReader.Exceptions
{
	public interface IExceptionWrapper
	{
		Exception Wrap(Exception exception);
	}
}
