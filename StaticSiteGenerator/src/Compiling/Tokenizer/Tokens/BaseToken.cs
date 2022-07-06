
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticSiteGenerator
{
    internal class BaseToken : IToken
    {
        TokenType Type { get; set; }
        public string Value { get; init; }
        public BaseToken(TokenType type, string value)
        {
            Type = type;
            Value = value;
        }
    }
}
