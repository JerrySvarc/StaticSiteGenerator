using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticSiteGenerator
{
    /// <summary>
    /// Must represent a Tokenizer. Must be accompanied by a creation of a specific parser. 
    /// </summary>
    internal interface ITokenizer
    {
        TokenList Tokenize(string text);
    }
}
