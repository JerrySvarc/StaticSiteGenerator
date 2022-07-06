using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticSiteGenerator
{
    static class TextScanner
    {
        public static IToken ScanChar(string text)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char character in text)
            {
                if(SpecialCharScanner.ScanChar(character.ToString()) != null)
                {
                    return Token.TokenFactory(TokenType.TEXT, sb.ToString());
                }
                else
                {
                    sb.Append(character);
                }
            }
            return Token.TokenFactory(TokenType.TEXT, sb.ToString());
        }
    }

    static class SpecialCharScanner
    {
        public static IToken ScanChar(string text)
        {
            switch (text[0])
            {
                case '#':
                    return Token.TokenFactory(TokenType.HASHTAG, null);
                    break;
                case '_':
                    return Token.TokenFactory(TokenType.UNDERSCORE, null);
                    break;
                case '*':
                    return Token.TokenFactory(TokenType.STAR, null);
                    break;
                case '+':
                    return Token.TokenFactory(TokenType.PLUS, null);
                    break;
                case '!':
                    return Token.TokenFactory(TokenType.EXCLAMATIONMARK, null);
                    break;
                case '\n':
                    return Token.TokenFactory(TokenType.NEWLINE, null);
                    break;
                case '[':
                    return Token.TokenFactory(TokenType.LEFTSQUAREBRACKET, null);
                    break;
                case ']':
                    return Token.TokenFactory(TokenType.RIGHTSQUAREBRACKET, null);
                    break;
                case '(':
                    return Token.TokenFactory(TokenType.LEFTBRACKET, null);
                    break;
                case ')':
                    return Token.TokenFactory(TokenType.RIGHTBRACKET, null);
                    break;
                default:
                    return null;
                    break;
            }
        }
    }

    /// <summary>
    /// Different types of tokens.
    /// </summary>
    public enum TokenType
    {
        TEXT,                   //some chars
        HASHTAG,                //#
        UNDERSCORE,             //_
        STAR,                   //*
        PLUS,                   //+
        EXCLAMATIONMARK,        //!
        NEWLINE,                //\n
        LEFTSQUAREBRACKET,      //[
        RIGHTSQUAREBRACKET,     //]
        LEFTBRACKET,            //(
        RIGHTBRACKET,           //)
        EOF                     // end of file
    }

    internal class Tokenizer : ITokenizer
    {
        public TokenList Tokenize(string text)
        {
            List<IToken> tokens = new List<IToken>();
            tokens = TokensToList(text, tokens);
            foreach (IToken token in tokens)
            {
                Console.WriteLine(((Token)token).Type);
            }
            
            return new TokenList(tokens);
        }

        List<IToken> TokensToList(string text, List<IToken> tokens)
        {
            if ( text.Length == 0 || text == null )
            {
                tokens.Add(Token.TokenFactory(TokenType.EOF, null));
            }
            else
            {
                var token = CreateToken(text);
                tokens.Add(token);
                List<IToken> remainingTokens = null;
                if (((Token)token).Value != null)
                {
                        remainingTokens = TokensToList(text[(((Token)token).Value.Length)..], tokens);
                }
                else
                {
                    remainingTokens = TokensToList(text[1..], tokens);
                }
                
            }
            return tokens;
        }

        IToken CreateToken(string text)
        {
            var token = SpecialCharScanner.ScanChar(text);
            if (token != null)
            {
                return token;
            }
            else
            {
                return TextScanner.ScanChar(text);
            }
        }
    }
}
