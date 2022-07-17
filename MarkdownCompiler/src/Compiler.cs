
using System.Text;

namespace MarkdownCompiler
{
    public sealed class Compiler
    {
        bool IsInsideWebDirectory { get; init; }
        public Compiler(bool isInsideWebDirectory)
        {
            IsInsideWebDirectory = isInsideWebDirectory;
        }

        public async Task CompileFileAsync(string path, string outputDirectoryName )
        {
            string fileName = Path.GetFileNameWithoutExtension(path);
            try
            {
                var result = await GetFileTokens(path);
                if (result.Item1 != null && result.Item2 != null)
                {
                    await CompileAndOutputFileAsync(result.Item1, fileName, result.Item2, outputDirectoryName);
                    await Console.Out.WriteLineAsync(fileName + ".md has been successfully compiled.");
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

        async Task CompileAndOutputFileAsync(List<IToken> resultTokens, string fileName, string title, string outputDirectoryName )
        {
            
            Generator generator = new Generator();
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
            }
        }

        async Task<string> GetTitle(StreamReader reader)
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

        async Task<(List<IToken>, string title)> GetFileTokens(string name)
        {
            ITokenizer tokenizer = new Tokenizer();
            List<IToken> resultTokens = new List<IToken>();
            string title;
            using (StreamReader reader = new StreamReader(name))
            {
                title = await GetTitle(reader);
                if (title == null)
                {
                    return (null,null);
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
    }
}
