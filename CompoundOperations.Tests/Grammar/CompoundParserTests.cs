using CompoundOperations.Grammar;
using PerCederberg.Grammatica.Runtime;
using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace CompoundOperations.Tests.Grammar
{
    public class CompoundParserTests
    {
        private readonly ITestOutputHelper _output;
        public CompoundParserTests(ITestOutputHelper output)
        {
            this._output = output;

        }

        [Fact]
        public void TestUnexpectedEOF()
        {
            Parser parser = CreateParser("b*(a+2)>3 AND 2>2 OR a<b");
            Node root = parser.Parse();
            StringWriter output = new StringWriter();
            root.PrintTo(output);
            this._output.WriteLine(output.ToString());
        }

        private Parser CreateParser(string input)
        {
            Parser parser = new CompoundParser(new StringReader(input));
            parser.Prepare();
            return parser;
        }
    }
}
