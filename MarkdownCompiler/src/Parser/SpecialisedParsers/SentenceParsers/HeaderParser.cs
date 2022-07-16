namespace MarkdownCompiler
{
    /// <summary>
    /// A paprser specialised to recognise a token patter representing a header. 
    /// </summary>
    internal class HeaderParser : ISentenceParser
    {
        /// <summary>
        /// Parses tokens and looks for a pattern representing a header. 
        /// </summary>
        /// <param name="tokens">A list of tokens.</param>
        /// <returns>Null if no sequence was found or a node containing the text which should be coded.</returns>
        public Node Parse(IToken[] tokens)
        {
            int hashtagCount = 0;
            int index = 0;
            if (tokens.Length <= 0)
            {
                return null;
            }
            while (tokens[index].Type == TokenType.HASHTAG && index <= 6)
            {
                hashtagCount++;
                index++;
            }

            if (tokens[hashtagCount].Type == TokenType.TEXT)
            {
                switch (hashtagCount)
                {
                    case 1:
                        return Node.NodeFactory(NodeType.H1, tokens[hashtagCount].Value, hashtagCount + 1);
                        break;
                    case 2:
                        return Node.NodeFactory(NodeType.H2, tokens[hashtagCount].Value, hashtagCount + 1);
                        break;
                    case 3:
                        return Node.NodeFactory(NodeType.H3, tokens[hashtagCount].Value, hashtagCount + 1);
                        break;
                    case 4:
                        return Node.NodeFactory(NodeType.H4, tokens[hashtagCount].Value, hashtagCount + 1);
                        break;
                    case 5:
                        return Node.NodeFactory(NodeType.H5, tokens[hashtagCount].Value, hashtagCount + 1);
                        break;
                    case 6:
                        return Node.NodeFactory(NodeType.H6, tokens[hashtagCount].Value, hashtagCount + 1);
                        break;
                    default:
                        return null;
                        break;
                }
            }
            return null;
        }
    }
}
