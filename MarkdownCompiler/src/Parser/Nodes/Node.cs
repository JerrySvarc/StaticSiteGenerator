namespace MarkdownCompiler
{
    /// <summary>
    /// A node representing a sentence in the grammar.
    /// </summary>
    public class Node : INode
    {
        public NodeType Type { get; init; }
        public string Value { get; init; }
        public int Consumed { get; init; }
        public string Name { get; set; }
        private Node(NodeType type, string value, int consumed)
        {
            Type = type;
            Value = value;
            Consumed = consumed;
            Name = null;
        }
        private Node(NodeType type, string value, int consumed, string name)
        {
            Type = type;
            Value = value;
            Consumed = consumed;
            Name = name;
        }
        public static Node NodeFactory(NodeType type, string value, int consumed)
        {
            return new Node(type, value, consumed);
        }
        public static Node NamedNodeFactory(NodeType type, string value, int consumed, string name)
        {
            return new Node(type, value, consumed, name);
        }
    }
}
