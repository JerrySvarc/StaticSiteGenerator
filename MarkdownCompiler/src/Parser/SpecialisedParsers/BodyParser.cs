namespace StaticSiteGenerator
{
    /// <summary>
    /// A paprser specialised to recognise a body node of the markdown file. 
    /// </summary>
    class BodyParser
    {
        /// <summary>
        /// Parses the given tokens. Tries to find all paragraphs in the tokens. 
        /// </summary>
        /// <param name="tokens">A list of tokens to be parsed.</param>
        /// <returns>>Null if no sequence was found or a BodyNode containing the paragraphs.</returns>
        public BodyNode Parse(IToken[] tokens)
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

        public void MatchAllParagraphs(IToken[] tokens, ParagraphParser paragraphParser, out List<ParagraphNode> paragraphNodes, out int consumed)
        {
            paragraphNodes = new List<ParagraphNode>();
            consumed = 0;

            while (true)
            {
                var paragraphNode = paragraphParser.Parse(tokens[consumed..]);
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
