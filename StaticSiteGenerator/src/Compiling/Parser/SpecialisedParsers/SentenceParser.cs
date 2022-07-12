using StaticSiteGenerator.src.Compiling.Parser.SpecialisedParsers.SentenceParsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticSiteGenerator
{
    internal class SentenceParser
    {
        List<ISentenceParser> SentenceParsers;
        public SentenceParser()
        {
            SentenceParsers = new List<ISentenceParser>() { };
        }

        public Node Parse(List<IToken> tokens)
        {
            return MatchOneSentece(tokens, SentenceParsers);
        }

        private Node MatchOneSentece(List<IToken> tokens, List<ISentenceParser> parsers)
        {
            foreach (var parser in parsers)
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
