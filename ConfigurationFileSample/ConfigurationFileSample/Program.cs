using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationFileSample
{
    class Program
    {
        static void Main(string[] args)
        {

            // NOTE: It is also possible to load the default custom section
            Console.WriteLine("\nLoading default Minestrone thru singleton!");
            var minestroneSection = Minestrone.MinestroneSection.Instance;
            PrintMinestrone(minestroneSection);

            // NOTE: You could ask for a given custom section
            Console.WriteLine("\nLoading Minestrone by manually specifying a section: minestroneSection");
            minestroneSection = ConfigurationManager.GetSection("minestroneSection") as Minestrone.MinestroneSection;
            PrintMinestrone(minestroneSection);

            // NOTE: Loads a custom section, but it uses a .NET built-in class 
            Console.WriteLine("\nLoading a ApplicationSettings using a built-in .NET type. (more at http://msdn.microsoft.com/en-us/library/system.configuration.configurationsection.aspx ) ");
            var myConfigSection = ConfigurationManager.GetSection("myConfigSection") as System.Collections.Specialized.NameValueCollection;
            for (int appSettingIndex = 0; appSettingIndex < myConfigSection.Count; appSettingIndex++)
            {
                Console.WriteLine(string.Format("Key:{0} Value:{1}", myConfigSection.AllKeys[appSettingIndex], myConfigSection[appSettingIndex]));
            }
            Console.WriteLine("\n\n PRESS ANY KEY TO FINISH! ");
            Console.ReadKey();
        }

        private static void PrintMinestrone(Minestrone.MinestroneSection minestroneSection)
        {
            if (minestroneSection != null)
            {
                for (int mappingIndex = 0; mappingIndex < minestroneSection.Mappings.Count; mappingIndex++)
                {
                    Console.WriteLine(string.Format("Name:{0} SourceId:{1} TargetId:{2}", minestroneSection.Mappings[mappingIndex].Name, minestroneSection.Mappings[mappingIndex].SourceId, minestroneSection.Mappings[mappingIndex].TargetId));
                }
            }
        }
    }
}
