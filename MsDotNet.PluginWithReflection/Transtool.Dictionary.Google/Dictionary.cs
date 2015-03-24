using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Transtool.Contracts;

namespace Transtool.Dictionary.Google
{
    public class Dictionary : IDictionary
    {
        #region IDictionary Members

        /// <summary>
        /// Implements the Plugin task ('Define')
        /// </summary>
        /// <param name="word">Word to define</param>
        /// <returns></returns>
        public string Define(string word)
        {
            String result = @"Transtool.Dictionary.Google";
#if DEBUG
            System.Diagnostics.Debug.WriteLine(@"Define Invoked from: {0}", result);
#endif
            return result;
        }
        #endregion
    }
}
