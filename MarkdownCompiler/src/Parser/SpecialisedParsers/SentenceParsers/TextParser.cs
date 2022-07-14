namespace StaticSiteGenerator
{
    /// <summary>
    /// A paprser specialised to recognise a token patter representing plain text. 
    /// </summary>
    internal class TextParser : ISentenceParser
    {
        /// <summary>
        /// Parses tokens and looks for a pattern representing plain text. 
        /// </summary>
        /// <param name="tokens">A list of tokens.</param>
        /// <returns>Null if no sequence was found or a node containing the text.</returns>
        public Node Parse(List<IToken> tokens)
        {
            if (tokens.Count >= 1 && tokens[0].Type == TokenType.TEXT)
            {

                return Node.NodeFactory(NodeType.TEXT, tokens[0].Value, 1);
            }
            else if (tokens.Count >= 1)
            {
                switch (tokens[0].Type)
                {
                    case TokenType.HASHTAG:
                        return Node.NodeFactory(NodeType.TEXT, "#", 1);
                        break;
                    case TokenType.UNDERSCORE:
                        return Node.NodeFactory(NodeType.TEXT, "_", 1);
                        break;
                    case TokenType.STAR:
                        return Node.NodeFactory(NodeType.TEXT, "*", 1);
                        break;
                    case TokenType.PLUS:
                        return Node.NodeFactory(NodeType.TEXT, "+", 1);
                        break;
                    case TokenType.EXCLAMATIONMARK:
                        return Node.NodeFactory(NodeType.TEXT, "!", 1);
                        break;
                    case TokenType.LEFTSQUAREBRACKET:
                        return Node.NodeFactory(NodeType.TEXT, "[", 1);
                        break;
                    case TokenType.RIGHTSQUAREBRACKET:
                        return Node.NodeFactory(NodeType.TEXT, "]", 1);
                        break;
                    case TokenType.LEFTBRACKET:
                        return Node.NodeFactory(NodeType.TEXT, "(", 1);
                        break;
                    case TokenType.RIGHTBRACKET:
                        return Node.NodeFactory(NodeType.TEXT, ")", 1);
                        break;
                    case TokenType.BACKTICK:
                        return Node.NodeFactory(NodeType.TEXT, "`", 1);
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
