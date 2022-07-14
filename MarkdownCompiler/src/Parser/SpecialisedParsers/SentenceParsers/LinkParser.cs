namespace StaticSiteGenerator
{
    /// <summary>
    /// A paprser specialised to recognise a token patter representing a link. 
    /// </summary>
    internal class LinkParser : ISentenceParser
    {
        List<TokenType> LinkNoNameTemplate = new List<TokenType>() { TokenType.LEFTSQUAREBRACKET, TokenType.RIGHTSQUAREBRACKET, TokenType.LEFTBRACKET, TokenType.TEXT, TokenType.RIGHTBRACKET };
        List<TokenType> NamedLinkTemplate = new List<TokenType>() { TokenType.LEFTSQUAREBRACKET, TokenType.TEXT,
                                                                    TokenType.RIGHTSQUAREBRACKET, TokenType.LEFTBRACKET, TokenType.TEXT, TokenType.RIGHTBRACKET };

        /// <summary>
        /// Parses tokens and looks for a pattern representing a link. 
        /// </summary>
        /// <param name="tokens">A list of tokens.</param>
        /// <returns>Null if no sequence was found or a node containing the text representing the link and an optional name.</returns>
        public Node Parse(List<IToken> tokens)
        {
            if (tokens.Count >= 5)
            {
                if (SentenceParser.CheckTypes(tokens, LinkNoNameTemplate))
                {
                    return Node.NodeFactory(NodeType.LINK, tokens[3].Value, 5);
                }
                else if (SentenceParser.CheckTypes(tokens, NamedLinkTemplate))
                {
                    return Node.NamedNodeFactory(NodeType.LINK, tokens[4].Value, 6, tokens[1].Value);
                }
            }
            return null;
        }
    }
}
