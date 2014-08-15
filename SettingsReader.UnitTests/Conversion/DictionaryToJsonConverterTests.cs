using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Ploeh.AutoFixture;

using SettingsReader.Conversion;



namespace SettingsReader.UnitTests.Conversion
{
	[TestClass]
	[ExcludeFromCodeCoverage]
	public class DictionaryToJsonConverterTests
	{
		[TestInitialize]
		public void TestInit()
		{
			_fixture = new Fixture();

			_jsonConverter = new DictionaryToJsonConverter();
		}

		[TestMethod]
		public void ConvertTest()
		{
			var dictionary = _fixture.Create<Dictionary<string, string>>();

			var sb = new StringBuilder();
			sb.Append("{");

			foreach (var pair in dictionary)
			{
				sb.AppendLine();
				sb.AppendFormat("  \"{0}\": \"{1}\",", pair.Key, pair.Value);
			}

			sb.Remove(sb.Length - 1, 1);
			sb.AppendLine();
			sb.Append("}");

			var actual = _jsonConverter.Convert(dictionary);
			Assert.AreEqual(sb.ToString(), actual, "Wrong json.");
		}

		private IFixture _fixture;
		private DictionaryToJsonConverter _jsonConverter;
	}
}
