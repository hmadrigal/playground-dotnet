using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Collections.Specialized;
using System.Reflection;
using System.IO;

using Transtool.Contracts;

namespace Transtool.Presentation.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            String word = @"word";
            // Loads all the Plugins that implements the contract 'IDictionary'
            var dictionaries = Program.LoadPluginsOf<IDictionary>(false, String.Empty, String.Empty);
            // Call the task(service) 'Define' of each plugin
            System.Console.WriteLine(@"Printing found meanings");
            foreach (var dictionary in dictionaries)
                System.Console.WriteLine(@"The meaning of {0} is {1}", word, dictionary.Define(word));
            System.Console.WriteLine(@"Press Any Key to exit");
            System.Console.ReadKey();
        }

        /// <summary>
        /// This routine loads files that implements a particular interface (TPlugin)
        /// </summary>
        /// <typeparam name="TPlugin">Interface that the file should implement in order to be loaded</typeparam>
        /// <param name="isRecursive">Indicates if the loader should look into subdirectories</param>
        /// <param name="pluginsPath">Path where the plugin should search</param>
        /// <param name="searchPattern">Filter in order to select the files</param>
        /// <returns>A list with all the instances of the plug in </returns>
        public static List<TPlugin> LoadPluginsOf<TPlugin>(Boolean isRecursive, String pluginsPath, String searchPattern)
        {
            List<TPlugin> pluginObjectList = new List<TPlugin>();
            String interfaceName = typeof(TPlugin).Name;
            String[] files = null;

            searchPattern = String.IsNullOrEmpty(searchPattern) ? @"*.dll" : searchPattern;
            //TODO: Add handling exception for reporting the right error message
            pluginsPath = Directory.Exists(pluginsPath) ? pluginsPath : Environment.CurrentDirectory;
            //TODO: Add handling exception for reporting the right error message
            files = Directory.GetFiles(pluginsPath, searchPattern, isRecursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);

            foreach (String filename in files)
            {
#if DEBUG
                System.Diagnostics.Debug.WriteLine(@"Loading file: {0}", filename);
#endif
                try
                {
                    var types = from t in Assembly.LoadFrom(filename).GetTypes()
                                where (t.IsClass && !t.IsAbstract && t.GetInterface(interfaceName) != null)
                                select ((TPlugin)Activator.CreateInstance(t));
                    pluginObjectList.AddRange(types);
                }
                catch (Exception)
                {
#if DEBUG
                    System.Diagnostics.Debug.WriteLine(@"Loding fail: {0}", filename);
#endif
                }
#if DEBUG
                System.Diagnostics.Debug.WriteLine(@"Loading complete.");
#endif
            }
            return pluginObjectList;
        }
    }
}
