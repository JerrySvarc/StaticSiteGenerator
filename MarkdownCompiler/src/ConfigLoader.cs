using System.Text.Json;

namespace MarkdownCompiler
{
    class ConfigContent
    {
        public string Author { get; set; }
        public string WebsiteName { get; set; }
    }

    internal static class ConfigLoader
    {
        public static async Task<ConfigContent> GetConfigContentAsync(bool isInsideWebDirectory, string configName)
        {
            ConfigContent? authorAndTitle;
            if (isInsideWebDirectory)
            {
                using (StreamReader reader = new StreamReader(configName))
                {
                    var configContent = await reader.ReadToEndAsync();
                    authorAndTitle = JsonSerializer.Deserialize<ConfigContent>(configContent);
                }
            }
            else
            {
                using (StreamReader reader = new StreamReader("website/" + configName))
                {
                    var configContent = await reader.ReadToEndAsync();
                    authorAndTitle = JsonSerializer.Deserialize<ConfigContent>(configContent);
                }
            }
            return authorAndTitle;
        }
    }
}
