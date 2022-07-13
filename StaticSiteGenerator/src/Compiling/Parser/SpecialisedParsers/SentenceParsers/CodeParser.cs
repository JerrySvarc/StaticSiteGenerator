namespace StaticSiteGenerator
{
    internal class CodeParser : ISentenceParser
    {
        List<TokenType> BacktickTemplate = new List<TokenType>() { TokenType.BACKTICK, TokenType.TEXT, TokenType.BACKTICK };

        public Node Parse(List<IToken> tokens)
        {
            if (tokens.Count >= 3)
            {
                if (SentenceParser.CheckTypes(tokens, BacktickTemplate))
                {
                    return Node.NodeFactory(NodeType.CODE, tokens[1].Value, 3);
                }
            }
            return null;
        }
    }
}
