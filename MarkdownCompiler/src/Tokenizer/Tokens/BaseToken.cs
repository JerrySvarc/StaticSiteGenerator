namespace MarkdownCompiler
{
    internal class Token : IToken
    {
        public TokenType Type { get; init; }
        public string Value { get; init; }
        private Token(TokenType type, string value)
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
