namespace MarkdownCompiler
{
    /// <summary>
    /// A paprser specialised to recognise a token patter representing a unordered list. 
    /// </summary>
    internal class ListParser : ISentenceParser
    {
        /// <summary>
        /// Parses tokens and looks for a pattern representing a member of an unordered list. 
        /// </summary>
        /// <param name="tokens">A list of tokens.</param>
        /// <returns>Null if no sequence was found or a node containing the text representing a member of an unordered list.</returns>
        public Node Parse(IToken[] tokens)
        {
            if (tokens.Length >= 3)
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
