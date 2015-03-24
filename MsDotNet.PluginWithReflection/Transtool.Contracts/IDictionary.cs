using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Transtool.Contracts
{
    public interface IDictionary
    {
        /// <summary>
        /// Plug in task
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        String Define(String word);
    }
}
