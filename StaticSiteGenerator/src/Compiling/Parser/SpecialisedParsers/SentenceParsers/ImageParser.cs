namespace StaticSiteGenerator
{
    internal class ImageParser : ISentenceParser
    {
        List<TokenType> ImageNoNameTemplate = new List<TokenType>() { TokenType.EXCLAMATIONMARK, TokenType.LEFTSQUAREBRACKET, TokenType.RIGHTSQUAREBRACKET, TokenType.LEFTBRACKET, TokenType.TEXT, TokenType.RIGHTBRACKET };
        List<TokenType> NamedImageTemplate = new List<TokenType>() { TokenType.EXCLAMATIONMARK, TokenType.LEFTSQUAREBRACKET, TokenType.TEXT,
                                                                    TokenType.RIGHTSQUAREBRACKET, TokenType.LEFTBRACKET, TokenType.TEXT, TokenType.RIGHTBRACKET };

        public Node Parse(List<IToken> tokens)
        {
            if (tokens.Count >= 5)
            {
                if (SentenceParser.CheckTypes(tokens, ImageNoNameTemplate))
                {
                    return Node.NodeFactory(NodeType.IMAGE, tokens[4].Value, 6);
                }
                else if (SentenceParser.CheckTypes(tokens, NamedImageTemplate))
                {
                    return Node.NamedNodeFactory(NodeType.IMAGE, tokens[5].Value, 7, tokens[2].Value);
                }
            }
            return null;
        }
    }
}
