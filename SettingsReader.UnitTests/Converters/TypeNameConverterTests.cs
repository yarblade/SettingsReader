﻿using System.Diagnostics.CodeAnalysis;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using SettingsReader.Converters;



namespace SettingsReader.UnitTests.Converters
{
	[TestClass]
	[ExcludeFromCodeCoverage]
	public class TypeNameConverterTests
	{
		[TestInitialize]
		public void TestInit()
		{
			_typeNameConverter = new TypeNameConverter();
		}

		[TestMethod]
		public void ConvertTest()
		{
			var actual = _typeNameConverter.Convert(typeof(TypeNameConverter));
			Assert.AreEqual("TypeNameConverter", actual, "Wrong type name.");
		}

		private TypeNameConverter _typeNameConverter;
	}
}
