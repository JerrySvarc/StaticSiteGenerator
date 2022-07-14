
namespace StaticSiteGenerator
{
    public sealed class MarkdownCompiler 
    {
        /// <summary>
        /// Tokenizes and parses a Markdown text and generates an HTML file in the 'output' directory.
        /// </summary>
        /// <param name="name">path to a file inside the 'posts' directory</param>
        public void CompileFile(string name)
        {
            string text = null;
            ITokenizer tokenizer = new Tokenizer();

            List<IToken> tokens;
            using (StreamReader reader = new StreamReader(name))
            {
                text = reader.ReadToEnd();
            }
            tokens = tokenizer.Tokenize(text);
            BodyNode root = null;
            if (tokens != null)
            {
                Parser parser = Parser.ParserFactory(tokens);
                root = parser.GetRoot();
            }
            if (root.Consumed != tokens.Count)
            {
                throw new ApplicationException();
            }

        }
    }
}
