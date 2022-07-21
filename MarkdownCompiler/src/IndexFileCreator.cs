using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<string> GetIndexFileContents()
        {
            var authorAndTitle = await ConfigLoader.GetConfigContentAsync(IsInsideWebDirectory,ConfigFileName);
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(GetHeader(authorAndTitle));
            stringBuilder.AppendLine("<h2>All posts:</h2>");
            foreach (var post  in GetPosts())
            {
                stringBuilder.AppendLine(post);
            }
            stringBuilder.AppendLine(GetFooter(authorAndTitle));
            return stringBuilder.ToString();
        }

        

        string GetHeader(ConfigContent authorAndTitle)
        {
            string template = "<!DOCTYPE html>\n <html>\n<head>\n<title>" + authorAndTitle.WebsiteName.ToString() + "</title>\n<link rel=\"stylesheet\" type='text/css' href=\"style.css\">\n</head>\n<body>\n" +
                "<h1>" + authorAndTitle.WebsiteName.ToString() + "</h1>";
            return template;
            
        }
        IEnumerable<string> GetPosts()
        {
            foreach (var post in FileTitles)
            {
                yield return "<li>" + " <a href = \"" + post.Key.ToString() + "\">" + post.Value.ToString() + " </a>" + "</li>\n";
            }
        }
        string GetFooter(ConfigContent authorAndTitle)
        {
            return "<footer> \n <p> Author: " + authorAndTitle.Author.ToString() + "</footer>";
        }
    }
}
