namespace MefAddIns.Terminal
{
    using System.ComponentModel.Composition.Hosting;
    using System.ComponentModel.Composition;
    using System;
    using System.ComponentModel.Composition.Registration;


    class MainClass
    {
        public static void Main(string[] args)
        {
            var bootStrapper = new Bootstrapper();

            //Adds all the parts found in same directory where the application is running!. It loads by default classes which exposes Export/Immport attributes
            var currentPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetAssembly(typeof(MainClass)).Location) ?? "./";
            var directoryCatalog = new DirectoryCatalog(currentPath);

            // Loading Portuguese implementation, which does not have Export or Import Attributes
            var assemblyCatalog = GetCustomAssemblyCatalog<Extensibility.ISupportedLanguage>(System.IO.Path.Combine(currentPath, @"MefAddIns.Language.Portuguese.dll"));


            //Create the CompositionContainer with the parts in the catalog (An aggregate catalog that combines multiple catalogs)
            var aggregateCatalog = new AggregateCatalog(assemblyCatalog, directoryCatalog);
            var container = new CompositionContainer(aggregateCatalog);

            //Fill the imports of this object
            try
            {
                container.ComposeParts(bootStrapper);
            }
            catch (CompositionException compositionException)
            {
                Console.WriteLine(compositionException.ToString());
            }



            //Prints all the languages that were found into the application directory
            var i = 0;
            foreach (var language in bootStrapper.Languages)
            {
                Console.WriteLine("[{0}] {1} by {2}.\n\t{3}\n", language.Version, language.Name, language.Author, language.Description);
                i++;
            }
            Console.WriteLine("It has been found {0} supported languages", i);
            Console.ReadKey();
        }

        public static System.ComponentModel.Composition.Primitives.ComposablePartCatalog GetCustomAssemblyCatalog<TContract>(string assemblyFilePath)
        {
            return ComposeRegistrationForAssembly<TContract>(System.Reflection.Assembly.LoadFile(assemblyFilePath));
        }
        public static System.ComponentModel.Composition.Primitives.ComposablePartCatalog ComposeRegistrationForAssembly<TContract>(System.Reflection.Assembly assembly)
        {
            var registration = new RegistrationBuilder();

            registration.ForTypesDerivedFrom<TContract>()
                        .Export<TContract>();

            var catalog = new AssemblyCatalog(assembly, registration);
            return catalog;
        }
    }
}
