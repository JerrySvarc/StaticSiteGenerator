namespace StaticSiteGenerator
{
    /// <summary>
    /// A node representing the body of the file. Contains all paragraphs.
    /// </summary>
    class BodyNode : INode
    {
        public List<ParagraphNode> Paragraphs { get; init; }
        public int Consumed { get; init; }

        private BodyNode(List<ParagraphNode> paragraphs, int consumed)
        {
            Paragraphs = paragraphs;
            Consumed = consumed;
        }

        public static BodyNode BodyNodeFactory(List<ParagraphNode> paragraphs, int consumed)
        {
            return new BodyNode(paragraphs, consumed);
        }
    }
}
