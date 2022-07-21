using System.Text;

namespace MarkdownCompiler
{
    class IndexFileCreator
    {
        Dictionary<string, string> FileTitles { get; init; }
        bool IsInsideWebDirectory { get; init; }
        string ConfigFileName { get; init; }

        public IndexFileCreator(Dictionary<string, string> fileTitles, string configFileName)
        {
            FileTitles = fileTitles;
            ConfigFileName = configFileName;
        }

        /// <summary>
        /// Returns the contents of the index file(header, all postst and the footer).
        /// </summary>
        /// <returns>A string representing the contents of the index page.</returns>
        public async Task<string> GetIndexFileContents()
        {
            var authorAndTitle = await ConfigLoader.GetConfigContentAsync(IsInsideWebDirectory, ConfigFileName);
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(GetHeader(authorAndTitle));
            stringBuilder.AppendLine("<h2>All posts:</h2>");
            foreach (var post in GetPosts())
            {
                stringBuilder.AppendLine(post);
            }
            stringBuilder.AppendLine(GetFooter(authorAndTitle));
            return stringBuilder.ToString();
        }


        /// <summary>
        /// Returns a string representing the header of the index page. 
        /// </summary>
        /// <param name="authorAndTitle">A class containg fields WebsiteName and Author.</param>
        /// <returns>A string representing the header.</returns>
        string GetHeader(ConfigContent authorAndTitle)
        {
            string template = "<!DOCTYPE html>\n <html>\n<head>\n<title>" + authorAndTitle.WebsiteName.ToString() + "</title>\n<link rel=\"stylesheet\" type='text/css' href=\"style.css\">\n</head>\n<body>\n" +
                "<h1>" + authorAndTitle.WebsiteName.ToString() + "</h1>";
            return template;

        }
        /// <summary>
        /// Returns an IEnumerable of strings representing a post which should be written to the index page.
        /// </summary>
        /// <returns>IEnumerable of strings.</returns>
        IEnumerable<string> GetPosts()
        {
            foreach (var post in FileTitles)
            {
                yield return "<li>" + " <a href = \"" + post.Key.ToString() + "\">" + post.Value.ToString() + " </a>" + "</li>\n";
            }
        }
        /// <summary>
        /// Returns the footer.
        /// </summary>
        /// <param name="authorAndTitle">A class containg fields WebsiteName and Author.</param>
        /// <returns>A string representing the footer.</returns>
        string GetFooter(ConfigContent authorAndTitle)
        {
            return "<footer> \n <p> Author: " + authorAndTitle.Author.ToString() + "</footer>";
        }
    }
}
