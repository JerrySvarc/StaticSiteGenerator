namespace StaticSiteGenerator
{
    internal class SentenceParser
    {
        List<ISentenceParser> SentenceParsers;
        public SentenceParser()
        {
            SentenceParsers = new List<ISentenceParser>() { new ImageParser(), new LinkParser(), new ItalicParser(), new BoldParser(), new CodeParser(), new ListParser(), new HeaderParser(), new TextParser() };
        }

        public Node Parse(List<IToken> tokens)
        {
            return MatchOneSentence(tokens, SentenceParsers);
        }

        private Node MatchOneSentence(List<IToken> tokens, List<ISentenceParser> parsers)
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
        public static bool CheckTypes(List<IToken> tokens, List<TokenType> template)
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
