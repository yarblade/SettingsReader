using System.Diagnostics.CodeAnalysis;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using SettingsReader.Conversion;



namespace SettingsReader.UnitTests.Conversion
{
	[TestClass]
	[ExcludeFromCodeCoverage]
	public class CamelCaseTypeNameConverterTests
	{
		[TestInitialize]
		public void TestInit()
		{
			_typeNameConverter = new CamelCaseTypeNameConverter();
		}

		[TestMethod]
		public void ConvertTest()
		{
			var actual = _typeNameConverter.Convert(typeof(CamelCaseTypeNameConverter));
			Assert.AreEqual("camelCaseTypeNameConverter", actual, "Wrong type name.");

			actual = _typeNameConverter.Convert(typeof(CamelCaseTypeNameConverterTests));
			Assert.AreEqual("camelCaseTypeNameConverterTests", actual, "Wrong type name.");
		}

		private CamelCaseTypeNameConverter _typeNameConverter;
	}
}
