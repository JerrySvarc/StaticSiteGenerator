namespace StaticSiteGenerator.src
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
            catch (Exception e)
            {

                throw e;
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
            catch (Exception e)
            {

                throw e;
            }
        }

        public static void CreateOutputDirectory()
        {

        }
        public static void CreateOutputDirectory()
        {

        }
    }
}
