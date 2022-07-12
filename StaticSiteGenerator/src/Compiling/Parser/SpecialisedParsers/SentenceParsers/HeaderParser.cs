using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticSiteGenerator
{
    internal class HeaderParser : ISentenceParser
    {
        public Node Parse(List<IToken> tokens)
        {
            int hashtagCount = 0;
            int index = 0;
            while (tokens[index].Type == TokenType.HASHTAG && index <= 6)
            {
                hashtagCount++;
            }

            if (tokens[hashtagCount].Type == TokenType.TEXT)
            {
                switch (hashtagCount)
                {
                    case 1:
                        return Node.NodeFactory(NodeType.H1, tokens[hashtagCount].Value, hashtagCount + 1);
                        break;
                    case 2:
                        return Node.NodeFactory(NodeType.H1, tokens[hashtagCount].Value, hashtagCount + 1);
                        break;
                    case 3:
                        return Node.NodeFactory(NodeType.H1, tokens[hashtagCount].Value, hashtagCount + 1);
                        break;
                    case 4:
                        return Node.NodeFactory(NodeType.H1, tokens[hashtagCount].Value, hashtagCount + 1);
                        break;
                    case 5:
                        return Node.NodeFactory(NodeType.H1, tokens[hashtagCount].Value, hashtagCount + 1);
                        break;
                    case 6:
                        return Node.NodeFactory(NodeType.H1, tokens[hashtagCount].Value, hashtagCount + 1);
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
