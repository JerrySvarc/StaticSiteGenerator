namespace StaticSiteGenerator
{
    public sealed class TokenList
    {
        int Index { get; set; }
        List<IToken> Tokens { get; set; }

        public TokenList(List<IToken> tokens)
        {
            Index = 0;
            Tokens = tokens;
        }

        public IToken GetToken()
        {
            return Tokens[Index];
            Index++;
        }

        public void AddToken(IToken token)
        {
            Tokens.Add(token);
        }

        public int Count()
        {
            return Tokens.Count;
        }
    }
}
