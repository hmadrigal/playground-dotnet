namespace MefAddIns.Terminal
{
    using Extensibility;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;

    public class Bootstrapper
    {
        /// <summary>
        /// Holds a list of all the valid languages for this application
        /// </summary>
        [ImportMany]
        public IEnumerable<ISupportedLanguage> Languages { get; set; }

    }
}
