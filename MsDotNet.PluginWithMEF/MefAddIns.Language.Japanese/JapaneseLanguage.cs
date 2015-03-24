namespace MefAddIns.Language.Japanese
{
    using MefAddIns.Extensibility;
    using System.ComponentModel.Composition;
    
    [Export(typeof(ISupportedLanguage))]
    public class JapaneseLanguage : ISupportedLanguage
    {
        public string Author
        {
            get { return @"エルベルマドリガル"; }
        }

        public string Version
        {
            get { return @"JA-JP.1.0.0"; }
        }

        public string Description
        {
            get { return "これは日本語AｄｄInです。"; }
        }


        public string Name
        {
            get { return @"日本語"; }
        }
    }
}
