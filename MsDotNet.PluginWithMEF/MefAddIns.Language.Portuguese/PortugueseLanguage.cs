using MefAddIns.Extensibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MefAddIns.Language.Portuguese
{
    class PortugueseLanguage : ISupportedLanguage
    {
        public string Author
        {
            get { return @"Fernando Madrigal"; }
        }

        public string Version
        {
            get { return @"PT-BR.1.0.0"; }
        }

        public string Description
        {
            get { return "Nesta lingua é Português"; }
        }


        public string Name
        {
            get { return @"Português"; }
        }
    }
}
