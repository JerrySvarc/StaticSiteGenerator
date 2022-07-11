
namespace StaticSiteGenerator
{
    sealed class MarkdownCompiler : ICompiler
    {
        /// <summary>
        /// Tokenizes and parses a Markdown text and generates an HTML file in the 'output' directory.
        /// </summary>
        /// <param name="name">path to a file inside the 'posts' directory</param>
        public void CompileFile(string name)
        {
            string text = null;
            ITokenizer tokenizer = new Tokenizer();
            Parser parser = new Parser();
            List<IToken> tokens;
            using (StreamReader reader = new StreamReader(name))
            {
                text = reader.ReadToEnd();
            }
            tokens = tokenizer.Tokenize(text);
            if (tokens != null)
            {
                //TODO:PARSER call
            }
        }
    }
}
