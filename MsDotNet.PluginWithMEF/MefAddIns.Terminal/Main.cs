namespace MefAddIns.Terminal
{
	using System.ComponentModel.Composition.Hosting;
    using System.ComponentModel.Composition;
    using System;
	
	class MainClass
	{
		public static void Main (string[] args)
		{
			var bootStrapper = new Bootstrapper();

            //An aggregate catalog that combines multiple catalogs
            var catalog = new AggregateCatalog();
            //Adds all the parts found in same directory where the application is running!
            var currentPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetAssembly(typeof(MainClass)).Location) ?? "./";
            catalog.Catalogs.Add(new DirectoryCatalog(currentPath));

            //Create the CompositionContainer with the parts in the catalog
            var container = new CompositionContainer(catalog);
            
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
            Console.WriteLine("It has been found {0} supported languages",i);
            Console.ReadKey();
		}
	}
}
