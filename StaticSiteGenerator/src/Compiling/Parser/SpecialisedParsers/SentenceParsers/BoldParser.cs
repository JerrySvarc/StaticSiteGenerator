namespace StaticSiteGenerator
{
    /// <summary>
    /// A paprser specialised to recognise a token patter representing bold text. 
    /// </summary>
    internal class BoldParser : ISentenceParser
    {
        List<TokenType> UnderscoreTemplate = new List<TokenType>() { TokenType.UNDERSCORE, TokenType.UNDERSCORE, TokenType.TEXT, TokenType.UNDERSCORE, TokenType.UNDERSCORE };
        List<TokenType> StarTemplate = new List<TokenType>() { TokenType.STAR, TokenType.STAR, TokenType.TEXT, TokenType.STAR, TokenType.STAR };
        /// <summary>
        /// Parses tokens and looks for a pattern representing bold text. 
        /// </summary>
        /// <param name="tokens">A list of tokens.</param>
        /// <returns>Null if no pattern was found. A node containing the text which should be bold.</returns>
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
