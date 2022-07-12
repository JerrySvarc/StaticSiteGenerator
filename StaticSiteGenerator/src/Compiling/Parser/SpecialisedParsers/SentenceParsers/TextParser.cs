using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticSiteGenerator
{
    internal class TextParser : ISentenceParser
    {
        public Node Parse(List<IToken> tokens)
        {
            if (tokens[0].Type == TokenType.TEXT)
            {
                return Node.NodeFactory(NodeType.TEXT, tokens[0].Value, 1);
            }
            return null;
        }
    }
}
