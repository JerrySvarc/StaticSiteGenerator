using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticSiteGenerator
{
    internal interface IGenerator
    {
        public void GenerateHTML();
        public void TemplateConfigFile();
    }
}
