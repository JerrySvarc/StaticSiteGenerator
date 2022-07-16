namespace MarkdownCompiler
{
    /// <summary>
    /// A paprser specialised to recognise a sentences followed by the End of File character.  
    /// </summary>
    internal class SentencesEOFParser : ISentencesParser
    {
        /// <summary>
        /// Parses the given tokens. Tries to find all sentences which are part of a paragraph in the tokens. 
        /// </summary>
        /// <param name="tokens">A list of tokens.</param>
        /// <returns>Null if no paragraph was found or a ParagraphNode.</returns>
        public ParagraphNode Parse(IToken[] tokens)
        {
            List<Node> sentences;
            int consumed;
            MatchAllSentences(tokens, new SentenceParser(), out sentences, out consumed);
            if (tokens != null && (tokens.Length >= consumed + 1) &&
                 tokens[consumed].Type == TokenType.EOF)
            {
                return ParagraphNode.ParagraphNodeFactory(sentences, consumed + 1);
            }
            else if (tokens != null && (tokens.Length >= consumed + 2) &&
                 tokens[consumed].Type == TokenType.NEWLINE &&
                 tokens[consumed + 1].Type == TokenType.EOF)
            {
                return ParagraphNode.ParagraphNodeFactory(sentences, consumed + 2);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Tries to find all sentences which make up a paragraph.
        /// </summary>
        /// <param name="tokens">A list of tokens.</param>
        /// <param name="sentenceParser">A sentence parser.</param>
        /// <param name="sentences">Found sentences.</param>
        /// <param name="consumed">How many tokens have been consumed.</param>
        private void MatchAllSentences(IToken[] tokens, SentenceParser sentenceParser, out List<Node> sentences, out int consumed)
        {
            sentences = new List<Node>();
            consumed = 0;

            while (true)
            {
                var subList = tokens[consumed..];
                var sentence = sentenceParser.Parse(subList);
                if (subList.Length <= 0 || (subList.Length == 1 && subList[0].Type == TokenType.EOF))
                {
                    break;
                }
                if (sentence == null && subList[0].Type == TokenType.NEWLINE && subList[1].Type != TokenType.NEWLINE)
                {
                    consumed++;
                }
                else if (sentence != null)
                {
                    sentences.Add(sentence);
                    consumed += sentence.Consumed;
                }
                else
                {
                    break;
                }

            }
        }
    }
}
