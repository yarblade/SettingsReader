using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Xml.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using SettingsReader.Sources;



namespace SettingsReader.UnitTests.BlackBox.Sources
{
	[TestClass]
	[ExcludeFromCodeCoverage]
	public class ConfigurationSectionSourceTests
	{
		[TestInitialize]
		public void TestInit()
		{
			_source = new ConfigurationSectionSource();
		}

		[TestMethod]
		[TestCategory("BlackBox")]
		public void GetTest()
		{
			var actual = _source.Get("complexSettings");

			Assert.IsNotNull(actual, "Settings shouldn't be null.");
			
			var simplePlainSettingsElement = actual.Element("simplePlainSettings");
			Assert.IsNotNull(simplePlainSettingsElement, "Element 'simplePlainSettings' shouldn't be null.");

			CheckElementValue(simplePlainSettingsElement, "int", "-1000000");
			CheckElementValue(simplePlainSettingsElement, "uint", "1000000");
			CheckElementValue(simplePlainSettingsElement, "long", "-1000000000000");
			CheckElementValue(simplePlainSettingsElement, "ulong", "1000000000000");
			CheckElementValue(simplePlainSettingsElement, "byte", "100");
			CheckElementValue(simplePlainSettingsElement, "string", "String");
			CheckElementValue(simplePlainSettingsElement, "datetime", "10.10.10 10:10:10");
			CheckElementValue(simplePlainSettingsElement, "timespan", "10:10:10");
			CheckElementValue(simplePlainSettingsElement, "bool", "True");
			CheckElementValue(simplePlainSettingsElement, "char", "c");
			CheckElementValue(simplePlainSettingsElement, "double", "1000000000000.0000000000001");
			CheckElementValue(simplePlainSettingsElement, "decimal", "1000000000000.100000000000010000000000001");

			var booksElement = actual.Elements("books").First();
			Assert.IsNotNull(booksElement, "Element 'books' shouldn't be null.");

			CheckElementValue(booksElement, "name", "Совершенный код");
			CheckElementValue(booksElement, "author", "С. Макконнелл");
			CheckElementValue(booksElement, "releaseDate", "1993-09-10");
			CheckElementValue(booksElement, "pages", "518");
			CheckElementValue(booksElement, "isReleased", "true");

			booksElement = actual.Elements("books").Skip(1).First();
			CheckElementValue(booksElement, "name", "Алгоритмы. Построение и анализ");
			CheckElementValue(booksElement, "author", "Томас Кормен, Чарльз Лейзерсон, Рональд Ривест, Клиффорд Штайн");
			CheckElementValue(booksElement, "releaseDate", "1987-05-17");
			CheckElementValue(booksElement, "pages", "423");
			CheckElementValue(booksElement, "isReleased", "true");

			Assert.AreEqual(actual.ToString(), _source.Get("complex").ToString().Replace("complex", "complexSettings"), "Wrong settings.");
		}

		private static void CheckElementValue(XElement parentElement, string name, string value)
		{
			var element = parentElement.Element(name);
			Assert.IsNotNull(element, "Element '{0}' shouldn't be null.", name);
			Assert.AreEqual(value, element.Value, "Wrong value.");
		}

		private ConfigurationSectionSource _source;
	}
}
