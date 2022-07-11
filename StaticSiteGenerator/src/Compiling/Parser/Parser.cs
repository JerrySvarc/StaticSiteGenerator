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

    internal class Parser
    {
        //TODO:implement Parser

        public BodyNode Parse(List<IToken> tokens)
        {

        }
        
    }
}
