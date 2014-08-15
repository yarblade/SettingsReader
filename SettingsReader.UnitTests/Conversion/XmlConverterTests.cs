using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Xml.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Ploeh.AutoFixture;

using SettingsReader.Conversion;



namespace SettingsReader.UnitTests.Conversion
{
	[TestClass]
	[ExcludeFromCodeCoverage]
	public class XmlConverterTests
	{
		[TestInitialize]
		public void TestInit()
		{
			_fixture = new Fixture();

			_xmlConverter = new XmlConverter();
		}

		[TestMethod]
		public void ConvertTest()
		{
			var xElement = CreateXElement();

			var sb = new StringBuilder();
			sb.AppendLine("{");
			sb.AppendFormat("  \"{0}\": {{", xElement.Name);

			foreach (var element in xElement.Elements())
			{
				sb.AppendLine();
				sb.AppendFormat("    \"{0}\": {{", element.Name);

				foreach (var elem in element.Elements())
				{
					sb.AppendLine();
					sb.AppendFormat("      \"{0}\": \"{1}\",", elem.Name, elem.Value);
				}
				
				sb.Remove(sb.Length - 1, 1);
				sb.AppendLine();
				sb.Append("    },");
			}

			sb.Remove(sb.Length - 1, 1);
			sb.AppendLine();
			sb.AppendLine("  }");
			sb.Append("}");

			var actual = _xmlConverter.Convert(xElement);
			Assert.AreEqual(sb.ToString(), actual, "Wrong json.");
		}

		private XElement CreateXElement()
		{
			var xElement = _fixture.Build<XElement>().Without(x => x.Value).Create();

			for (int i = 0; i < 3; i++)
			{
				var element = _fixture.Build<XElement>().Without(x => x.Value).Create();
				for (int j = 0; j < 3; j++)
				{
					element.Add(_fixture.Create<XElement>());
				}

				xElement.Add(element);
			}

			return xElement;
		}

		private IFixture _fixture;
		private XmlConverter _xmlConverter;
	}
}
