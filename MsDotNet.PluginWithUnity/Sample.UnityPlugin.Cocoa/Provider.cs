using Sample.UnityPlugin.Contracts;

namespace Sample.UnityPlugin.Cocoa
{
    public class Provider : IProvider
    {
        public Provider(string providerName)
        {
            this.Name = providerName;
        }

        public object Connection { get; set; }

        public string Name { get; set; }
    }
}