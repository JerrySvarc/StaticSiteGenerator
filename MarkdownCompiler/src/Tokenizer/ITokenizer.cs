namespace StaticSiteGenerator
{
    /// <summary>
    /// Must represent a Tokenizer. Must be accompanied by a creation of a specific parser. 
    /// </summary>
    internal interface ITokenizer
    {
        public List<IToken> Tokenize(string text);
    }
}
