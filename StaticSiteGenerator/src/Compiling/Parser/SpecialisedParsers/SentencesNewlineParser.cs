namespace StaticSiteGenerator
{
    internal class SentencesNewlineParser : ISentencesParser
    {
        public ParagraphNode Parse(List<IToken> tokens)
        {
            List<Node> sentences;
            int consumed;
            MatchAllSentences(tokens, new SentenceParser(), out sentences, out consumed);
            if (tokens != null && (tokens.Count >= consumed + 2) &&
                 tokens[consumed].Type == TokenType.NEWLINE &&
                 tokens[consumed + 1].Type == TokenType.NEWLINE)
            {
                 return ParagraphNode.ParagraphNodeFactory(sentences, consumed + 2);   
            }
            return null;
        }

        private void MatchAllSentences(List<IToken> tokens, SentenceParser sentenceParser, out List<Node> sentences, out int consumed)
        {
            sentences = new List<Node>();
            consumed = 0;

            while (true)
            {
                var subList = tokens.GetRange(consumed, tokens.Count - consumed);
                var sentence = sentenceParser.Parse(subList);
                if (subList.Count <= 0 || (subList.Count == 1 && subList[0].Type == TokenType.EOF))
                {
                    break;
                }
                if (sentence == null && subList[0].Type == TokenType.NEWLINE && subList[1].Type != TokenType.NEWLINE )
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
