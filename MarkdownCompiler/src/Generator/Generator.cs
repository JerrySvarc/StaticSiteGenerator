using System.Text;

namespace MarkdownCompiler
{
    internal class Generator
    {
        static readonly NodeType[] headerTypes = new NodeType[] { NodeType.H1, NodeType.H2, NodeType.H3, NodeType.H4, NodeType.H5, NodeType.H6 };

        public string GenerateParagraphText(ParagraphNode paragraphNode)
        {
            StringBuilder builder = new StringBuilder();

            if (paragraphNode.Sentences.Count > 0)
            {
                if (headerTypes.Contains(paragraphNode.Sentences[0].Type))
                {
                    builder.Append(GenerateHeader(paragraphNode));
                    return builder.ToString();
                }
                else
                {
                    builder.Append("<p>");
                    foreach (var node in paragraphNode.Sentences)
                    {
                        builder.Append(GenerateOther(node));
                    }
                    builder.Append("</p>");
                    return builder.ToString();
                }
            }
            return null;
        }

        string GenerateHeader(ParagraphNode paragraphNode)
        {
            switch (paragraphNode.Sentences[0].Type)
            {
                case NodeType.H1:
                    return GenerateHeaderString("h1", paragraphNode);
                    break;
                case NodeType.H2:
                    return GenerateHeaderString("h2", paragraphNode);
                    break;
                case NodeType.H3:
                    return GenerateHeaderString("h3", paragraphNode);
                    break;
                case NodeType.H4:
                    return GenerateHeaderString("h4", paragraphNode);
                    break;
                case NodeType.H5:
                    return GenerateHeaderString("h5", paragraphNode);
                    break;
                case NodeType.H6:
                    return GenerateHeaderString("h6", paragraphNode);
                    break;
                default:
                    return null;
                    break;
            }
        }
        string GenerateOther(Node node)
        {
            switch (node.Type)
            {
                case NodeType.TEXT:
                    return " " + node.Value;
                    break;
                case NodeType.BOLD:
                    return " <b>" + node.Value + "</b>";
                    break;
                case NodeType.ITALIC:
                    return " <em>" + node.Value + "</em>";
                    break;
                case NodeType.CODE:
                    return " <code>" + node.Value + "</code>";
                    break;
                case NodeType.LIST:
                    return " <li>" + node.Value + "</li>\n";
                    break;
                case NodeType.IMAGE:
                    if (node.Name != null)
                    {
                        return " <img src = " + node.Value + " alt = " + node.Name + " >";
                    }
                    else
                    {
                        return " <img src = " + node.Value + ">";
                    }
                    break;
                case NodeType.LINK:
                    if (node.Name != null)
                    {
                        return " <a href = " + node.Value + " >" + node.Name + " </a>";
                    }
                    else
                    {
                        return " <a href = " + node.Value + " >" + " </a>";
                    }
                    break;
                default:
                    return null;
                    break;
            }
        }
        string GenerateHeaderString(string headerType, ParagraphNode paragraphNode)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(" <" + headerType + ">");
            if (paragraphNode.Sentences.Count != 1 && paragraphNode.Sentences[0].Value == " ")
            {
                foreach (Node node in paragraphNode.Sentences)
                {
                    if (node.Type == NodeType.TEXT)
                    {
                        builder.Append(node.Value + " ");
                    }
                    else
                    {
                        builder.Append(GenerateOther(node));
                    }
                }
            }
            else
            {
                builder.Append(paragraphNode.Sentences[0].Value);
            }
            builder.Append(" </" + headerType + ">");
            return builder.ToString();
        }


        public string GetHeader(string title)
        {
            string template = "<!DOCTYPE html>\n <html>\n<head>\n<title>" + title + "</title>\n</head>\n<body>";
            return template;
        }

        public string GetBodyEnd()
        {
            return "</body>\n</html>";
        }
    }
}
