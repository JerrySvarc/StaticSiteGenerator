
namespace StaticSiteGenerator
{
    /// <summary>
    /// Class containing the Main method. 
    /// </summary>
    class Program
    {
        /// <summary>
        /// The main entrypoint of the program. If no arguments are given to the program the generator will create the correct directories and a config
        /// file. If the argument "compile" is given, the generator will
        /// create the output directory compile all markdown files into HTML. 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            switch (args.Length)
            {
                case 0:
                    Creator configCreator = new Creator();
                    configCreator.TemplateConfigFile();
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
                            MarkdownCompiler compiler = new MarkdownCompiler();
                            Creator generator = new Creator(compiler);
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
