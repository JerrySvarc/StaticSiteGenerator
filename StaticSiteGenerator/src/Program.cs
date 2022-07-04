namespace StaticSiteGenerator.src
{
    class Program
    {
        static void Main(string[] args)
        {
            switch (args.Length)
            {
                case 0:
                    DirectoryCreator.CreateTemplateDirectories();
                    break;
                case 1:
                    if (args[0].ToLower() != "compile")
                    {
                        Console.WriteLine("Wrong arguments. Please try again.");
                        PrintHelp();
                    }
                    else
                    {
                        var dirName = new DirectoryInfo(Directory.GetCurrentDirectory()).Name;
                        if (Directory.Exists("website/posts") || (dirName == "website" && Directory.Exists("posts")))
                        {
                            IParser parser = new MarkdownParser();
                            Generator generator = new Generator(parser);
                            generator.GenerateHTML();
                        }
                        else
                        {
                            Console.WriteLine("Wrong directory structure. Please run the static site generator without any arguments.");
                        }
                    }
                    break;
                default:
                    PrintHelp();
                    break;
            }
        }

        static void PrintHelp()
        {
            Console.WriteLine();
        }
    }
}
