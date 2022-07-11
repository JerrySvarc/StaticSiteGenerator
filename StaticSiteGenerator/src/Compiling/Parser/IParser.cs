namespace StaticSiteGenerator
{
    /// <summary>
    /// Must represent a parser with a method that parses a TokenList and returns a BodyNode.
    /// </summary>
    internal interface IParser
    {
        bool TryParse(Stack<Token> tokens, out List<Node> result);
    }
}
