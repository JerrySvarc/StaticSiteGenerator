using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticSiteGenerator
{
    class Node : INode
    {
        public NodeType Type { get; init; }
        public string Value { get; init; }
        public int Consumed { get;  init; }
        public string Name { get; set; }
        private Node(NodeType type, string value, int consumed)
        {
            Type = type;
            Value = value;
            Consumed = consumed;
            Name = null;
        }
        public static Node NodeFactory(NodeType type, string value, int consumed)
        {
            return new Node(type, value, consumed);
        }
    }
}
