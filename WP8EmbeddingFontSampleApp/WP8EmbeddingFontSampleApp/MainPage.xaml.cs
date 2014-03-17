using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using WP8EmbeddingFontSampleApp.Resources;
using System.Threading.Tasks;

namespace WP8EmbeddingFontSampleApp
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private async void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {

            var placeHolderValues = new Dictionary<string, string>
                        {
                            {@"[FontFamilyName]", @"Herr Von Muellerhoff"},
                            {@"[FontBase64]", await FileManager.Instance.GetBase64String(@"ms-appx:///Assets/HtmlTemplate/HerrVonMuellerhoff-Regular.ttf") },
                            {@"[HtmlContent]", System.Net.HttpUtility.HtmlEncode(AppResources.AppLoremIpsum)},
                        };

            var htmlPage = await FileManager.Instance.LoadHtmlPage(@"ms-appx:///Assets/HtmlTemplate/PageView.html", placeHolderValues);
            TextDisplay.Text = AppResources.AppLoremIpsum;
            WebView.NavigateToString(htmlPage);
        }



        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}