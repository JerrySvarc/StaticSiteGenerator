namespace StaticSiteGenerator
{
    /// <summary>
    /// Different types of nodes. 
    /// </summary>
    public enum NodeType
    {
        TEXT,
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
        List<IToken> Tokens { get; init; }

        private Parser(List<IToken> tokens)
        {
            Tokens = tokens;
        }

        public static Parser ParserFactory(List<IToken> tokens)
        {
            return new Parser(tokens);
        }
        /// <summary>
        /// Creates a new body parser and parses the tokens given to the parser.
        /// </summary>
        /// <returns>A root node of the abstract syntax tree.</returns>
        public BodyNode GetRoot()
        {
            BodyParser bodyParser = new BodyParser();
            return bodyParser.Parse(Tokens);
        }
    }
}
