namespace StaticSiteGenerator
{
    internal class Creator 
    {
        private string TemplateConfigContent = "{\"Author\":\"John Doe\", \"WebsiteName\":\"A very nice website\"}";
        MarkdownCompiler Compiler { get; set; }

        public Creator(MarkdownCompiler compiler)
        {
            Compiler = compiler;
        }

        public Creator()
        {
            Compiler = null;
        }

        /// <summary>
        /// Generator will compile all markdown files inside the posts directory into html and put the inside the output directory.
        /// </summary>
        public async Task GenerateHTMLAsync(string logFile)
        {
            string[] posts = GetPostNames();
            if (posts == null || posts.Length == 0)
            {
                Console.WriteLine("Could not find any posts. Please add files to the \'posts\' directory.");
            }
            else
            {
                List<Task<bool>> tasks = new List<Task<bool>>();
                foreach (var post in posts)
                {
                    tasks.Add(Compiler.CompileFileAsync(post, logFile));
                }
                await Task.WhenAll(tasks);
            }
        }

        /// <summary>
        /// Searches the posts directory and returns an array of names of all markdown files.
        /// </summary>
        /// <returns>All names of markdown files inside the posts directory or null if posts directory cannot be found.</returns>
        private string[] GetPostNames()
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

        /// <summary>
        /// Creates the configuration json file.
        /// </summary>
        private bool GenerateConfigFile()
        {
            string dirName = new DirectoryInfo(Directory.GetCurrentDirectory()).Name;
            try
            {
                if (Directory.Exists("website/posts"))
                {
                    File.Create("website/config.json").Close();
                    return true;
                }
                else if (dirName == "website")
                {
                    File.Create("config.json").Close();
                    return true;
                }
                else
                {
                    Console.WriteLine("Config file could not be created. Wrong directory structure.");
                    return false;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Config file could not be created.");
                return false;
            }
        }

        /// <summary>
        /// Creates the configuration json file and adds the template config structure containing variables 'Name' and 'Author'.
        /// </summary>
        public void TemplateConfigFile()
        {
            if (GenerateConfigFile())
            {
                string dirName = new DirectoryInfo(Directory.GetCurrentDirectory()).Name;
                try
                {
                    if (File.Exists("website/config.json"))
                    {
                        using (StreamWriter writer = new StreamWriter("website/config.json"))
                        {
                            writer.WriteLine(TemplateConfigContent);
                        }
                    }
                    else if (dirName == "website" && File.Exists("config.json"))
                    {
                        using (StreamWriter writer = new StreamWriter("config.json"))
                        {
                            writer.WriteLine(TemplateConfigContent);
                        }
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
}