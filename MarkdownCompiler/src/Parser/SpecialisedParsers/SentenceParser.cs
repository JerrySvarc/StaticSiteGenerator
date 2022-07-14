namespace StaticSiteGenerator
{
    /// <summary>
    /// A paprser specialised to recognise a sentence node from the list of tokens. 
    /// </summary>
    internal class SentenceParser
    {
        ISentenceParser[] SentenceParsers = new ISentenceParser[] { new ImageParser(), new LinkParser(), new ItalicParser(), new BoldParser(), 
            new CodeParser(), new ListParser(), new HeaderParser(), new TextParser() };
        

        /// <summary>
        /// Parses the given tokens. Tries to find a sentence in the tokens. 
        /// </summary>
        /// <param name="tokens">A list of tokens to be parsed.</param>
        /// <returns>Null if no sequence was found or a Node representing sentence.</returns>
        public Node Parse(IToken[]tokens)
        {   
            return MatchOneSentence(tokens, SentenceParsers);
        }

        /// <summary>
        /// Matches one sentence from the tokens. Tries different sentence parsers until a sentence is found.
        /// </summary>
        /// <param name="tokens">A list of tokens.</param>
        /// <param name="parsers">Parser which parse the tokens until a match is found./param>
        /// <returns>Null if no match was found or a Node.</returns>
        private Node MatchOneSentence(IToken[] tokens, ISentenceParser[] parsers)
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

        /// <summary>
        /// Tries to find a pattern corresponding to a template pattern.
        /// </summary>
        /// <param name="tokens">Tokens to be checked.</param>
        /// <param name="template">A template list.</param>
        /// <returns>False if the two lists differ or true if a match is found.</returns>
        public static bool CheckTypes(IToken[] tokens, List<TokenType> template)
        {
            for (int i = 0; i < template.Count; i++)
            {
                if (tokens[i].Type != template[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
