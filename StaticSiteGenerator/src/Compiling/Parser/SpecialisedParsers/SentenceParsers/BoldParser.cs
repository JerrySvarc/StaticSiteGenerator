namespace StaticSiteGenerator
{
    internal class BoldParser : ISentenceParser
    {
        List<TokenType> UnderscoreTemplate = new List<TokenType>() { TokenType.UNDERSCORE, TokenType.UNDERSCORE, TokenType.TEXT, TokenType.UNDERSCORE, TokenType.UNDERSCORE };
        List<TokenType> StarTemplate = new List<TokenType>() { TokenType.STAR, TokenType.STAR, TokenType.TEXT, TokenType.STAR, TokenType.STAR };
        public Node Parse(List<IToken> tokens)
        {
            if (tokens.Count >= 5)
            {
                if (SentenceParser.CheckTypes(tokens, UnderscoreTemplate) || SentenceParser.CheckTypes(tokens, StarTemplate))
                {
                    return Node.NodeFactory(NodeType.BOLD, tokens[2].Value, 5);
                }
            }
            return null;
        }



    }
}
