using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.ServiceModel.DomainServices.Client;

namespace SampleSilverlightApplication
{
    public partial class MainPage : UserControl
    {
        SampleRIAServicesLibrary.Web.WCFWebContext wcfWenContextClient = new SampleRIAServicesLibrary.Web.WCFWebContext();

        public MainPage()
        {
            InitializeComponent();
        }

        private void InvokeOperation_Click(object sender, RoutedEventArgs e)
        {
            this.Message.Text = string.Format("[Client Invoke Start At]{0}", DateTime.Now);
            this.wcfWenContextClient.GetMessage("Hello World", this.CallBack_GetMessage, null);
        }

        private void CallBack_GetMessage(InvokeOperation<string> getMessageOperation)
        {
            if (getMessageOperation.HasError)
            {
                MessageBox.Show(String.Format("Error found!\n {0}.\nStackTrace\n{1}", getMessageOperation.Error.Message, getMessageOperation.Error.StackTrace));
            }
            else
            {
                this.Message.Text = String.Format("{0}The server response is:\t\n{1}\n{2}",
                    this.Message.Text,
                    getMessageOperation.Value,
                    string.Format("[Client Got its Callback At]{0}", DateTime.Now));
            }
        }
    }
}
