using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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