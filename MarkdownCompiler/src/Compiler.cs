
using System.Text;

namespace MarkdownCompiler
{
    public sealed class Compiler
    {
        bool IsInsideWebDirectory { get; init; }
        Dictionary<string, string> FileTitles;
        string ConfigFileName { get; set; }

        public Compiler(bool isInsideWebDirectory, string configFileName)
        {
            IsInsideWebDirectory = isInsideWebDirectory;
            FileTitles = new Dictionary<string, string>();
            ConfigFileName = configFileName;
        }

        /// <summary>
        /// Asynchronously reads, tokenizes and parses a markdown file and converts its contents into HTML and writes the result asynchronously into a file with the extension ".html" at 
        /// the specified output directory. Will let the user know if an error during the compilation occured via the console. 
        /// </summary>
        /// <param name="path">The path to a file we want to compile.</param>
        /// <param name="outputDirectoryName">The output directory where we want to put our newly generated HTML file.</param>
        /// <returns>A task.</returns>
        public async Task CompileFileAsync(string path, string outputDirectoryName)
        {
            string fileName = Path.GetFileNameWithoutExtension(path);
            try
            {
                var result = await GetFileTokens(path);
                if (result.Item1 != null && result.Item2 != null)
                {
                    FileTitles[fileName + ".html"] = result.Item2;
                    if (await CompileAndOutputFileAsync(result.Item1, fileName, result.Item2, outputDirectoryName))
                    {
                        await Console.Out.WriteLineAsync(fileName + ".md has been successfully compiled.");
                    }
                }
                else
                {
                    await Console.Out.WriteLineAsync(fileName + ".md could not be parsed. A title tag is missing or the file cannot be tokenized.");
                }
            }
            catch (Exception)
            {
                await Console.Out.WriteLineAsync("An error occured during compilation of the file " + fileName + ".md");
            }
        }

        /// <summary>
        /// Parses the tokens paragraph by paragraph, then generates the HTML of the paragraph and asynchronously writes to a file at the specified location.
        /// </summary>
        /// <param name="resultTokens">A list of tokens.</param>
        /// <param name="fileName">Name of the file we want to put our generated HTML.</param>
        /// <param name="title">The extracted title of the page.</param>
        /// <param name="outputDirectoryName">The output directory where we want to put our newly generated file.</param>
        /// <returns> A task.</returns>
        async Task<bool> CompileAndOutputFileAsync(List<IToken> resultTokens, string fileName, string title, string outputDirectoryName)
        {

            Generator generator = new Generator();

            if (!Directory.Exists(outputDirectoryName) && !Directory.Exists("website/" + outputDirectoryName))
            {
                await Console.Out.WriteLineAsync(outputDirectoryName + " directory not found.");
                return false;
            }

            string newFilePath;
            if (IsInsideWebDirectory)
            {
                newFilePath = outputDirectoryName + "/" + fileName + ".html";
            }
            else
            {
                newFilePath = "website/" + outputDirectoryName + "/" + fileName + ".html";
            }

            using (var writer = new StreamWriter(newFilePath))
            {
                await writer.WriteLineAsync(generator.GetHeader(title));
                foreach (var paragraph in Parser.GetAllParagraphs(resultTokens.ToArray()))
                {
                    if (paragraph != null)
                    {
                        string text = generator.GenerateParagraphText(paragraph);
                        if (text != null)
                        {
                            await writer.WriteLineAsync(text);
                        }
                    }
                }
                await writer.WriteLineAsync(generator.GetBodyEnd());
                await writer.WriteLineAsync(generator.GetFooter(await ConfigLoader.GetConfigContentAsync(IsInsideWebDirectory, ConfigFileName)));
                return true;
            }
        }

        /// <summary>
        /// Asynchronously reads the first three lines of the specified file and returns the title of the page specified by the "Name" tag. 
        /// </summary>
        /// <param name="reader">A stream reader of the file from which we want to extract the title.</param>
        /// <returns>Task where the string represents the title or null if there was an error.</returns>
        async Task<string> TryGetTitleAsync(StreamReader reader)
        {
            string title = null;
            for (int i = 0; i < 3; i++)
            {
                var line = await reader.ReadLineAsync();
                if ((i == 0 || i == 2) && line != "---")
                {
                    title = null;
                    break;
                }
                else if (i == 1 && line != null)
                {
                    var splitLine = line.Split(new char[] { ' ' });
                    if (splitLine[0].ToLower() == "name:")
                    {
                        StringBuilder builder = new StringBuilder();
                        for (int j = 1; j < splitLine.Length; j++)
                        {
                            if (j == splitLine.Length - 1)
                            {
                                builder.Append(splitLine[j]);
                            }
                            else
                            {
                                builder.Append(splitLine[j] + " ");
                            }
                        }
                        title = builder.ToString();
                    }
                    else
                    {
                        title = null;
                        break;
                    }
                }
            }
            return title;
        }

        /// <summary>
        /// Asynchronously reads the specified file line by line and returns the title of the page (specified at the top of the page) and the list of tokens representing 
        /// the contents of the page.
        /// </summary>
        /// <param name="name">The path to a file which we want to tokenize.</param>
        /// <returns>A tuple consisting of a List of Itokens and a string representing the title of the page. Returns (null,null) if an error occured during extraction of the title of tokenizing
        /// </returns>
        async Task<(List<IToken>, string title)> GetFileTokens(string name)
        {
            ITokenizer tokenizer = new Tokenizer();
            List<IToken> resultTokens = new List<IToken>();
            string title;
            using (StreamReader reader = new StreamReader(name))
            {
                title = await TryGetTitleAsync(reader);
                if (title == null)
                {
                    return (null, null);
                }
                var line = await reader.ReadLineAsync();

                while (line != null)
                {
                    var tokens = tokenizer.Tokenize(line);
                    foreach (var token in tokens)
                    {
                        resultTokens.Add(token);
                    }
                    line = await reader.ReadLineAsync();
                }
                resultTokens.Add(Token.TokenFactory(TokenType.EOF, null));
            }
            return (resultTokens, title);
        }

        /// <summary>
        /// Asynchronously creates the index html file in the specified output directory. Uses the contents of the config.json file. All posts are displayed on the index page along with their links and titles.  
        /// </summary>
        /// <param name="outputDirectory">Where to put the index file.</param>
        /// <param name="configFileName">The name of the config file containing the information about the website name and the name of the author.</param>
        /// <returns></returns>
        public async Task CreateIndexFileAsync(string outputDirectory, string configFileName)
        {

            IndexFileCreator indexFileCreator = new IndexFileCreator(FileTitles, configFileName);
            string indexFileContent = await indexFileCreator.GetIndexFileContents();
            try
            {
                if (IsInsideWebDirectory)
                {
                    using (StreamWriter writer = new StreamWriter(outputDirectory + "/index.html"))
                    {
                        writer.WriteAsync(indexFileContent);
                    }
                }
                else
                {
                    using (StreamWriter writer = new StreamWriter("website/" + outputDirectory + "/index.html"))
                    {
                        writer.WriteAsync(indexFileContent);
                    }
                }
                await Console.Out.WriteLineAsync("The index.html has been successfully created.");
            }
            catch (Exception)
            {

                await Console.Out.WriteLineAsync("An error occured during the creation of the index.html");
            }
        }


    }

}
