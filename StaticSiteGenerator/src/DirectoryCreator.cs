namespace StaticSiteGenerator
{
    static class DirectoryCreator
    {
        public static void CreateTemplateDirectories()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string websiteDirectory = currentDirectory + "/website";
            try
            {
                Directory.CreateDirectory(websiteDirectory);
                Directory.CreateDirectory(websiteDirectory + "/posts");
                Directory.CreateDirectory(websiteDirectory + "/pictures");
            }
            catch (Exception)
            {
                Console.WriteLine("An error has occured. Cannot create website directories.");
            }
        }

        public static void CreateNamedDirectories(string name)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string websiteDirectory = currentDirectory + "/" + name;
            try
            {
                Directory.CreateDirectory(websiteDirectory);
                Directory.CreateDirectory(websiteDirectory + "/posts");
                Directory.CreateDirectory(websiteDirectory + "/pictures");
            }
            catch (Exception)
            {
                Console.WriteLine("An error has occured. Cannot create website directories.");
            }
        }

        public static void CreateOutputDirectory()
        {
            string dirName = new DirectoryInfo(Directory.GetCurrentDirectory()).Name;
            if (Directory.Exists("website/posts") || (dirName == "website" && Directory.Exists("posts")))
            {
                Directory.CreateDirectory("FinishedSite");
            }
        }

    }
}
