using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticSiteGenerator
{
    internal class BodyNode : INode
    {
        List<ParagraphNode> Paragraphs { get; init; }
        int Consumed { get; init; }

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
