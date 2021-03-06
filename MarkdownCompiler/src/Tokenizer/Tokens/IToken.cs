namespace MarkdownCompiler
{
    /// <summary>
    /// An implementation must represent a token with a type and a value created by the Tokenizer while reading the correct char from the file.
    /// </summary>
    public interface IToken
    {
        public TokenType Type { get; init; }
        public string Value { get; init; }
    }
}
