using System;
using System.Collections.Generic;
using System.Text;

namespace Workbench.Parsers
{
    public struct keyword_t
    {
        public string word;
        public int reserved;

        public keyword_t(string w, int r) => (word, reserved) = (w, r);
    }
}
