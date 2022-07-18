using MarkdownCompiler;
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
        static async Task Main(string[] args)
        {
            switch (args.Length)
            {
                case 0:
                    DirectoryCreator.CreateTemplateDirectories();
                    Creator.TemplateConfigFile();
                    Console.WriteLine("Necessary directories have been created. Please put your .md files into the \'posts\' directory and your pictures into the \'pictures\' directory.\n" +
                        "Your markdown files will be compiled into the \'output\' directory. ");
                    break;
                case 1:
                    if (args[0].ToLower() != "compile")
                    {
                        Console.WriteLine("Wrong arguments. Please try again.");
                    }
                    else
                    {
                        var dirName = new DirectoryInfo(Directory.GetCurrentDirectory()).Name;
                        Compiler compiler;
                        Creator creator;
                        if (Directory.Exists("website/posts"))
                        {
                            compiler = new Compiler(false);
                            creator = new Creator(compiler);
                            await creator.GenerateHTMLAsync();
                            creator.CopyPicturesToOutput("website/pictures", "website/output");
                        }
                        else if (dirName == "website" && Directory.Exists("posts"))
                        {
                            compiler = new Compiler(true);
                            creator = new Creator(compiler);
                            await creator.GenerateHTMLAsync();
                            creator.CopyPicturesToOutput("pictures", "output");
                        }
                        else
                        {
                            Console.WriteLine("Could not find the \"posts\" directory.");
                        }
                    }
                    break;
            }
        }
    }
}
