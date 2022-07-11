using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticSiteGenerator
{
    class Node : INode
    {
        NodeType Type { get; init; }
        string Value { get; init; }
        int Consumed { get;  init; }
        private Node(NodeType type, string value, int consumed)
        {
            Type = type;
            Value = value;
            Consumed = consumed;
        }
        public static Node NodeFactory(NodeType type, string value, int consumed)
        {
            return new Node(type, value, consumed);
        }
    }
}
