
namespace StaticSiteGenerator
{
    public sealed class MarkdownCompiler 
    {
        public async Task<bool> CompileFileAsync(string name)
        {
            var resultTokens = await GetFileTokens(name);
            foreach (var paragraph in Parser.GetAllParagraphs(resultTokens.ToArray()))
            {
                if (paragraph == null)
                {
                    throw new InvalidOperationException();
                }
            }

            return false;
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
