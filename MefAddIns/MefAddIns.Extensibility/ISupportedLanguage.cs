namespace MefAddIns.Extensibility
{
    /// <summary>
    /// Defines the functionality that third parties have to implement for my language plug in
    /// </summary>
    public interface ISupportedLanguage
    {
        string Author { get; }
        string Version { get; }
        string Description { get; }
        string Name { get; }
    }
}
