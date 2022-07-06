namespace StaticSiteGenerator.src.Compiling.Parser
{
    /// <summary>
    /// Must represent a parser with a corresponding tokenizer.
    /// </summary>
    internal interface IParser
    {
        IToken Match(TokenList tokens);
    }
}
