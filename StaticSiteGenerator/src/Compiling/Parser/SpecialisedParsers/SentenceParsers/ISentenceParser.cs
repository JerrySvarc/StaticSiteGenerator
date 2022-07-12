using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticSiteGenerator
{
    /// <summary>
    /// Represents a parser which looks for a specific set of tags which form a specific sentence. 
    /// </summary>
    internal interface ISentenceParser
    {
        public Node Parse(List<IToken> tokens);
    }
}
