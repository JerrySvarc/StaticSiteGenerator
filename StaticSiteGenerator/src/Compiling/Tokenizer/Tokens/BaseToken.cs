
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticSiteGenerator
{
    internal class Token : IToken
    {
        public TokenType Type { get; init; }
        public string Value { get; init; }
        public Token(TokenType type, string value)
        {
            Type = type;
            Value = value;
        }

        public static Token TokenFactory(TokenType Type, string Value)
        {
            return new Token(Type, Value);
        } 
    }
}
