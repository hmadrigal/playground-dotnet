using System;
using System.Windows;

namespace PreviewHandlerWpfApplication
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new Microsoft.Win32.OpenFileDialog();
            if (dlg.ShowDialog().Value)
            {
                previewHandlerHostControlInstance.FilePath = dlg.FileName;
            }
        }
    }
}
