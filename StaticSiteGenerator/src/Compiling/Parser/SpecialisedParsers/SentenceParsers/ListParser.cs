namespace StaticSiteGenerator
{
    internal class ListParser : ISentenceParser
    {
        public Node Parse(List<IToken> tokens)
        {
            if (tokens.Count >= 2)
            {
                if (tokens[0].Type == TokenType.PLUS && tokens[1].Type == TokenType.TEXT && tokens[2].Type == TokenType.NEWLINE)
                {
                    return Node.NodeFactory(NodeType.LIST, tokens[1].Value, 2);
                }
            }
            return null;
        }
    }
}
