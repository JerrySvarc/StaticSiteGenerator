namespace StaticSiteGenerator
{
    /// <summary>
    /// A paprser specialised to recognise a token patter representing an image link. 
    /// </summary>
    internal class ImageParser : ISentenceParser
    {
        List<TokenType> ImageNoNameTemplate = new List<TokenType>() { TokenType.EXCLAMATIONMARK, TokenType.LEFTSQUAREBRACKET, TokenType.RIGHTSQUAREBRACKET, TokenType.LEFTBRACKET, TokenType.TEXT, TokenType.RIGHTBRACKET };
        List<TokenType> NamedImageTemplate = new List<TokenType>() { TokenType.EXCLAMATIONMARK, TokenType.LEFTSQUAREBRACKET, TokenType.TEXT,
                                                                    TokenType.RIGHTSQUAREBRACKET, TokenType.LEFTBRACKET, TokenType.TEXT, TokenType.RIGHTBRACKET };
        /// <summary>
        /// Parses tokens and looks for a pattern representing an image link. 
        /// </summary>
        /// <param name="tokens">A list of tokens.</param>
        /// <returns>Null if no sequence was found or a node containing the text representing the link and an optional name.</returns>
        public Node Parse(IToken[] tokens)
        {
            if (tokens.Length >= 5)
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
