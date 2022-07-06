using StaticSiteGenerator.src.Compiling.Parser;
using System;
using System.IO;
namespace StaticSiteGenerator
{
    sealed class MarkdownCompiler : ICompiler
    {
        //TODO: Implement the compiler
        public void CompileFile(string name)
        {
            string text = null;
            ITokenizer tokenizer = new Tokenizer();
            TokenList tokens = new TokenList();
            IParser parser = new Parser();
            using (StreamReader reader = new StreamReader("website/config.json"))
            {
                text = reader.ReadToEnd();
            }
            tokens = tokenizer.Tokenize(text);
            parser.Match(tokens);
        }
    }
}
