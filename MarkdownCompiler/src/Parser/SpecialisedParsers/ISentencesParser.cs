namespace StaticSiteGenerator
{
    /// <summary>
    /// Represents a parser which parses sentences of tokens. Sentence can be for example a bold text, normal text, link, etc.
    /// </summary>
    internal interface ISentencesParser
    {
        public ParagraphNode Parse(List<IToken> nodes);
    }
}
