using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticSiteGenerator
{
    internal class TokenList
    {
        int Index { get; set; }
        List<IToken> Tokens { get; set; }

        public TokenList(List<IToken> tokens)
        {
            Index = 0;
            Tokens = tokens;
        }

        public IToken GetToken()
        {
            return Tokens[Index];
            Index++;
        }

        public void AddToken(IToken token)
        {
            Tokens.Add(token);
        }

    }
}
