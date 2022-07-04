using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace StaticSiteGenerator.src
{
    static class Creator
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
            catch (Exception e)
            {
                Console.WriteLine("An error has occured. Cannot create website directories.");
            }
        }

        public static void CreateOutputDirectory()
        {

        }
        
    }
}
