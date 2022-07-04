namespace StaticSiteGenerator.src
{
    internal class Generator
    {
        IParser Parser { get; set; }
        public Generator(IParser parser)
        {
            Parser = parser;
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
                    Task parsingTask = new Task(() => Parser.ParseFile(post));
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
    }
}