using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticSiteGenerator.src.Compiling.Parser
{
    /// <summary>
    /// Must represent a parser with a corresponding tokenizer.
    /// </summary>
    internal interface IParser
    {
        IToken Match(TokenList tokens);
    }
}
