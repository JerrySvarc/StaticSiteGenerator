namespace StaticSiteGenerator
{
    /// <summary>
    /// A node representing a paragraph. Contains all sentences inside of the paragraph.
    /// </summary>
    public class ParagraphNode : INode
    {
        public List<Node> Sentences { get; init; }
        public int Consumed { get; init; }

        private ParagraphNode(List<Node> sentences, int consumed)
        {
            Sentences = sentences;
            Consumed = consumed;
        }

        public static ParagraphNode ParagraphNodeFactory(List<Node> sentences, int consumed)
        {
            return new ParagraphNode(sentences, consumed);
        }

    }
}
