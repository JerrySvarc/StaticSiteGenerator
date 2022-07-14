namespace StaticSiteGenerator
{
    /// <summary>
    /// A paprser specialised to recognise a token patter representing text in italic. 
    /// </summary>
    internal class ItalicParser : ISentenceParser
    {

        List<TokenType> UnderscoreTemplate = new List<TokenType>() { TokenType.UNDERSCORE, TokenType.TEXT, TokenType.UNDERSCORE };
        List<TokenType> StarTemplate = new List<TokenType>() { TokenType.STAR, TokenType.TEXT, TokenType.STAR };

        /// <summary>
        /// Parses tokens and looks for a pattern representing text in italic. 
        /// </summary>
        /// <param name="tokens">A list of tokens.</param>
        /// <returns>Null if no sequence was found or a node containing the text representing the text in italic.</returns>
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

