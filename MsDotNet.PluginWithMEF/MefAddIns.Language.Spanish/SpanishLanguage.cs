namespace MefAddIns.Language.Spanish
{
    using MefAddIns.Extensibility;
    using System.ComponentModel.Composition;

    [Export(typeof(ISupportedLanguage))]
    public class SpanishLanguage : ISupportedLanguage
    {
        public string Author
        {
            get { return @"Fernando Madrigal"; }
        }

        public string Version
        {
            get { return @"ES-CR.1.0.0"; }
        }

        public string Description
        {
            get { return "Soporte del idioma Español de Costa Rica"; }
        }


        public string Name
        {
            get { return @"Español"; }
        }
    }
}
