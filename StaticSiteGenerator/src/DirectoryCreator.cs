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
                Directory.CreateDirectory(websiteDirectory + "/output");
            }
            catch (Exception)
            {
                Console.WriteLine("An error has occured. Cannot create website directories.");
            }
        }
    }
}
