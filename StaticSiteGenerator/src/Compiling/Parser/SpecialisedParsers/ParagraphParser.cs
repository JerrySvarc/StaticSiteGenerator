using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticSiteGenerator
{
    class ParagraphParser
    {
        public ParagraphNode Parse(List<IToken> tokens)
        {
            var parsers = new List<ISentencesParser>() { new SentencesNewlineParser(), new SentencesEOFParser() };
            return MatchOneSentece(tokens, parsers);
        }

        private ParagraphNode MatchOneSentece(List<IToken> tokens, List<ISentencesParser> parsers)
        {
            foreach(var parser in parsers)
            {
                var node = parser.Parse(tokens);
                if (node != null)
                {
                    return node;
                }
            }
            return null;
        }
    }
}
