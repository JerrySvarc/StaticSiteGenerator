using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticSiteGenerator
{
    internal class ParagraphNode : INode
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
