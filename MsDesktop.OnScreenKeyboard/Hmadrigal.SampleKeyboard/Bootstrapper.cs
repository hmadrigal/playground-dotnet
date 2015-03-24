using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.UnityExtensions;

namespace Hmadrigal.SampleKeyboard
{
    public class Bootstrapper : UnityBootstrapper
    {


        protected override System.Windows.DependencyObject CreateShell()
        {
            var shell = new Shell();
            shell.DataContext = new ViewModels.ViewModelLocator();
            shell.Show();
            return shell;
        }
    }
}
