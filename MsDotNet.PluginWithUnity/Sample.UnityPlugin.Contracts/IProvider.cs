namespace Sample.UnityPlugin.Contracts
{
    public interface IProvider
    {
        object Connection { get; }
        string Name { get; }
    }
}