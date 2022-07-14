namespace StaticSiteGenerator
{
    /// <summary>
    /// A paprser specialised to recognise a token patter representing coded text. 
    /// </summary>
    internal class CodeParser : ISentenceParser
    {
        List<TokenType> BacktickTemplate = new List<TokenType>() { TokenType.BACKTICK, TokenType.TEXT, TokenType.BACKTICK };

        /// <summary>
        /// Parses tokens and looks for a pattern representing coded text. 
        /// </summary>
        /// <param name="tokens">A list of tokens.</param>
        /// <returns>Null if no sequence was found or a node containing the text which should be coded.</returns>
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
