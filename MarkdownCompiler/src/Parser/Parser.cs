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

    static class Parser
    { 
        public static IEnumerable<ParagraphNode> GetAllParagraphs(IToken[] tokens)
        {
            int consumed = 0;
            ParagraphParser paragraphParser = new ParagraphParser();
            while (true)
            {
                var paragraphNode = paragraphParser.Parse(tokens[consumed..]);
                if (paragraphNode == null)
                {
                    break;
                }
                consumed += paragraphNode.Consumed;
                yield return paragraphNode;
            }
        }
    }
}
