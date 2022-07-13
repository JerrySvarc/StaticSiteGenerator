namespace StaticSiteGenerator
{
    internal class ItalicParser : ISentenceParser
    {

        List<TokenType> UnderscoreTemplate = new List<TokenType>() { TokenType.UNDERSCORE, TokenType.TEXT, TokenType.UNDERSCORE };
        List<TokenType> StarTemplate = new List<TokenType>() { TokenType.STAR, TokenType.TEXT, TokenType.STAR };
        public Node Parse(List<IToken> tokens)
        {
            if (tokens.Count >= 3)
            {
                if (SentenceParser.CheckTypes(tokens, UnderscoreTemplate) || SentenceParser.CheckTypes(tokens, StarTemplate))
                {
                    return Node.NodeFactory(NodeType.ITALIC, tokens[1].Value, 3);
                }
            }
            return null;
        }
    }
}

