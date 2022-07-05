namespace StaticSiteGenerator
{
    static class DirectoryCreator
    {
        /// <summary>
        /// Creates the template website directory structure.
        /// </summary>
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

        /// <summary>
        /// Creates the output directory.
        /// </summary>
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
