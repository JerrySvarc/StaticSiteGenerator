using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticSiteGenerator
{
    /// <summary>
    /// Represents a parser which parses sentences of tokens. Sentence can be for example a bold text, normal text, link, etc.
    /// </summary>
    internal interface ISentenceParser
    {
        public ParagraphNode Parse(List<IToken> nodes);
    }
}
