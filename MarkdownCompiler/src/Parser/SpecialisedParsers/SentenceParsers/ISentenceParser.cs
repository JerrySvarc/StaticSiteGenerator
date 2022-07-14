namespace StaticSiteGenerator
{
    /// <summary>
    /// Represents a parser which looks for a specific set of tags which form a specific sentence. 
    /// </summary>
    internal interface ISentenceParser
    {
        /// <summary>
        /// Parses tokens and tries to recognize a certain pattern representing a sentence in the grammar.
        /// </summary>
        /// <param name="tokens">A list of tokens to be parser.</param>
        /// <returns>Null if no acceptable pattern was found.</returns>
        public Node Parse(List<IToken> tokens);
    }
}
