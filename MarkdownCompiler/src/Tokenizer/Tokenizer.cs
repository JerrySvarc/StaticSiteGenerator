using System.Text;

namespace MarkdownCompiler
{
    static class TextScanner
    {
        /// <summary>
        /// Consumes text until it finds a character with a specific assigned tag. Creates a new TEXT token containg the found text.
        /// </summary>
        /// <param name="text">Markdown text</param>
        /// <returns>A token of the type TEXT containg the found text.</returns>
        public static IToken ScanChar(string text)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char character in text)
            {
                if (SpecialCharScanner.ScanChar(character) != null)
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
        /// <summary>
        /// Checks if a character has been assigned a specific tag and returns one if it does. 
        /// </summary>
        /// <param name="text">Markdown text</param>
        /// <returns>Will return a tag of a special type. Will return null if no special tag is assigned.</returns>
        public static IToken ScanChar(char character)
        {
            switch (character)
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
                case '`':
                    return Token.TokenFactory(TokenType.BACKTICK, null);
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
        BACKTICK,
        EOF                     // end of file
    }

    public class Tokenizer : ITokenizer
    {
        /// <summary>
        /// Tokenizes the markdown text. See the enum TokenType to see all the different possible tags.
        /// </summary>
        /// <param name="text">A markdown text set to be Tokenized.</param>
        /// <returns>A List of tokens containing the found tokens. Will return null if the input text was null.</returns>
        public List<IToken> Tokenize(string text)
        {
            List<IToken> tokens = new List<IToken>();
            try
            {
                if (text != null)
                {
                    tokens = TokensToList(text, tokens);
                    return tokens;
                }
                else
                {
                    return null;

                }
            }
            catch (Exception)
            {
                Console.WriteLine("An error has occured while tokenizing.");
                return null;
            }
        }

        /// <summary>
        /// Takes the markdown text and turns it into a list of tokens.
        /// </summary>
        /// <param name="text">A markdown text to be tokenized.</param>
        /// <param name="tokens">An(empty) array of tokens.</param>
        /// <returns>A list of tokens.</returns>
        List<IToken> TokensToList(string text, List<IToken> tokens)
        {
            if (text.Length == 0)
            {
                tokens.Add(Token.TokenFactory(TokenType.NEWLINE, null));
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

        /// <summary>
        /// Create a token from a singe character or a text token from multiple characters.
        /// </summary>
        /// <param name="text">Markdown text.</param>
        /// <returns>A single token.</returns>
        IToken CreateToken(string text)
        {
            var token = SpecialCharScanner.ScanChar(text[0]);
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
