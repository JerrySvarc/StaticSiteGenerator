namespace MarkdownCompiler
{
    /// <summary>
    /// A paprser specialised to recognise a paragraph node from the list of tokens. 
    /// </summary>
    class ParagraphParser
    {
        /// <summary>
        /// Parses the given tokens. Tries to find a paragraph in the tokens. 
        /// </summary>
        /// <param name="tokens">A list of tokens to be parsed.</param>
        /// <returns>Null if no sequence was found or a ParagraphNode containing sentences.</returns>
        public ParagraphNode Parse(IToken[] tokens)
        {
            var parsers = new ISentencesParser[] { new SentencesNewlineParser(), new SentencesEOFParser() };
            return MatchOneParagraph(tokens, parsers);
        }
        /// <summary>
        /// Matches one paragraph from the tokens. Tries different sentence parsers until a pararaph is found.
        /// </summary>
        /// <param name="tokens">A list of tokens.</param>
        /// <param name="parsers">Parser which parse the tokens until a match is found.</param>
        /// <returns>Null if no match was found or a ParagraphNode.</returns>
        private ParagraphNode MatchOneParagraph(IToken[] tokens, ISentencesParser[] parsers)
        {
            foreach (var parser in parsers)
            {
                var node = parser.Parse(tokens);
                if (node != null)
                {
                    return node;
                }
            }
            return null;
        }
    }
}
