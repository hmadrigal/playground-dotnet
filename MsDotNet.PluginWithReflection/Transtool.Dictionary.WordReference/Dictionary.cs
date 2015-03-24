using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Transtool.Contracts;

namespace Transtool.Dictionary.WordReference
{
    public class Dictionary : IDictionary
    {
        #region IDictionary Members

        public string Define(string word)
        {
            String result = @"Transtool.Dictionary.WordReference";
#if DEBUG
            System.Diagnostics.Debug.WriteLine(@"Define Invoked from: {0}", result);
#endif
            return result;
        }

        #endregion
    }
}
