using StaticSiteGenerator;

namespace StaticSiteGenerator
{
    internal class Generator
    {
        ICompiler Compiler { get; set; }
        public Generator(ICompiler compiler)
        {
            Compiler = compiler;
        }

        public Generator()
        {
            Compiler = null;
        }
        public void GenerateHTML()
        {
            string[] posts = GetPostNames();
            if (posts == null || posts.Length == 0)
            {
                Console.WriteLine("Could not find any posts. Please add files to the \'posts\' directory.");
            }
            else
            {
                foreach (var post in posts)
                {
                    Task parsingTask = new Task(() => Compiler.CompileFile(post));
                    parsingTask.Start();
                }
            }
        }

        public string[] GetPostNames()
        {
            string dirName = new DirectoryInfo(Directory.GetCurrentDirectory()).Name;
            if (Directory.Exists("website/posts"))
            {
                return Directory.GetFiles("website/posts", "*.md");
            }
            else if (dirName == "website" && Directory.Exists("posts"))
            {
                return Directory.GetFiles("posts", "*.md");
            }
            else
            {
                return null;
            }
        }

        public void GenerateConfigFile()
        {
            string dirName = new DirectoryInfo(Directory.GetCurrentDirectory()).Name;
            try
            {
                if (Directory.Exists("website/posts"))
                {
                    File.Create("website/config.json");
                }
                else if (dirName == "website" && Directory.Exists("posts"))
                {
                    File.Create("config.json");
                }
                else
                {
                    Console.WriteLine("Config file could not be created. Wrong directory structure.");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Config file could not be created.");
            }
           
        }
    }
}