
namespace StaticSiteGenerator
{
    sealed class MarkdownCompiler : ICompiler
    {
        public void CompileFile(string name)
        {
            string text = null;
            ITokenizer tokenizer = new Tokenizer();
            TokenList tokens;
            IParser parser = new Parser();
            using (StreamReader reader = new StreamReader(name))
            {
                text = reader.ReadToEnd();
            }
            tokens = tokenizer.Tokenize(text);
            if (tokens != null)
            {
                parser.Match(tokens);
            }
        }
    }
}
