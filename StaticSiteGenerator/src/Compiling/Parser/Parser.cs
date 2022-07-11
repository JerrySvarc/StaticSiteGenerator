namespace StaticSiteGenerator
{
    /// <summary>
    /// Different types of nodes. 
    /// </summary>
    public enum NodeType
    {
        H1,
        H2,
        H3,
        H4,
        H5,
        H6,
        BOLD,
        ITALIC,
        CODE,
        LIST,
        IMAGE,
        LINK
    }

    sealed class Parser
    {
        //TODO:implement Parser
        List<IToken> Tokens { get; init; }

        private Parser(List<IToken> tokens)
        {
            Tokens = tokens;
        }

        public Parser ParserFactory(List<IToken> tokens)
        {
            return new Parser(tokens);
        }
        public BodyNode GetRoot()
        {
            BodyParser bodyParser = new BodyParser();
            return bodyParser.Parse(Tokens);
        }
    }
}
