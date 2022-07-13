namespace StaticSiteGenerator
{
    class BodyParser
    {
        public BodyNode Parse(List<IToken> tokens)
        {
            List<ParagraphNode> paragraphs;
            int consumed;
            MatchAllParagraphs(tokens, new ParagraphParser(), out paragraphs, out consumed);
            if (paragraphs != null)
            {
                return BodyNode.BodyNodeFactory(paragraphs, consumed);
            }
            Console.WriteLine("An error has occured.");
            return null;
        }

        public void MatchAllParagraphs(List<IToken> tokens, ParagraphParser paragraphParser, out List<ParagraphNode> paragraphNodes, out int consumed)
        {
            paragraphNodes = new List<ParagraphNode>();
            consumed = 0;

            while (true)
            {
                var paragraphNode = paragraphParser.Parse(tokens.GetRange(consumed, tokens.Count - consumed));
                if (paragraphNode == null)
                {
                    break;
                }
                paragraphNodes.Add(paragraphNode);
                consumed += paragraphNode.Consumed;
            }
        }
    }
}
