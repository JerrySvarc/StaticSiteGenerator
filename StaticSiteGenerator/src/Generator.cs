namespace StaticSiteGenerator.src
{
    internal class Generator 
    {
        IParser Parser { get; set; }
        public Generator(IParser parser)
        {
            Parser = parser;
        }

        public void GenerateHTML()
        {

        }
    }
}