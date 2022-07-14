
namespace StaticSiteGenerator
{
    public sealed class MarkdownCompiler 
    {
        public async Task<bool> CompileFileAsync(string name, string logFile)
        {
            var root = await GetASTAsync(name);
            
            return false;
        }


        /// <summary>
        /// Reads a markdown file then tokenizes and parses the text and generates an HTML file in the 'output' directory.
        /// </summary>
        /// <param name="name">A name of the file which is to be read.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">If the parser has not consumed all of the tokens.</exception>
        async Task<BodyNode> GetASTAsync(string name)
        {
            var resultTokens = await GetFileTokens(name);

            BodyNode root = null;
            
            if (resultTokens != null)
            {
                Parser parser = Parser.ParserFactory(resultTokens);
                root = parser.GetRoot();
            }
            if (root == null || root.Consumed != resultTokens.Count)
            {
                return null;
            }
            return root;
        }

        async Task<List<IToken>> GetFileTokens(string name)
        {
            ITokenizer tokenizer = new Tokenizer();

            List<IToken> resultTokens = new List<IToken>();
            using (StreamReader reader = new StreamReader(name))
            {
                var line = await reader.ReadLineAsync();

                while (line != null)
                {
                    var tokens = tokenizer.Tokenize(line);
                    foreach (var token in tokens)
                    {
                        resultTokens.Add(token);
                    }
                    line = await reader.ReadLineAsync();
                }
                resultTokens.Add(Token.TokenFactory(TokenType.EOF, null));
            }
            return resultTokens;
        }
    }
}
