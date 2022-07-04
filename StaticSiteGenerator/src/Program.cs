using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticSiteGenerator.src
{
    static class Program
    {
        static void Main(string[] args)
        {
            string websiteName = "website";

            switch (args.Length)
            {
                case 0:
                    DirectoryCreator.CreateTemplateDirectories();
                    break;
                case 1:
                    if (args[0] != "compile")
                    {
                        websiteName = args[0];
                        DirectoryCreator.CreateNamedDirectories(args[0]);
                    }
                    else
                    {
                        IParser parser = new MarkdownParser();
                        Generator generator = new Generator(parser);
                        generator.GenerateHTML();
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
