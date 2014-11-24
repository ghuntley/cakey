using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using CakeyApp.Services;
using CakeyApp.ViewModels;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using CakeyApp.WindowsPhone.Resources;
using Microsoft.Phone.Tasks;
using ReactiveUI;
using Splat;
using Xamarin.Forms;
using YoutubeExtractor;

namespace CakeyApp.WindowsPhone
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            Forms.Init();

            var bootstrapper = RxApp.SuspensionHost.GetAppState<AppBootstrapper>();
            bootstrapper.CreateMainPage().ConvertPageToUIElement(this);

            //HostScreen.Router.Navigate.Execute(new VideoPlayerViewModel(new Uri("pNFu3JMV-y4.mp4", UriKind.Relative)));
            //HostScreen.Router.Navigate.Execute(new VideoPlayerViewModel(new Uri("https://www.youtube.com/watch?v=pFgvvgGEpkQ", UriKind.Absolute)));
            
            //player.PlayVideo(new Uri("pNFu3JMV-y4.mp4", UriKind.Relative));

            // Sample code to localize the ApplicationBar
            BuildLocalizedApplicationBar();
        }

        // Sample code for building a localized ApplicationBar
        private void BuildLocalizedApplicationBar()
        {
            // Set the page's ApplicationBar to a new instance of ApplicationBar.
            ApplicationBar = new ApplicationBar();

            // Create a new button and set the text value to the localized string from AppResources.
            ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
            appBarButton.Text = AppResources.AppBarButtonText;
            ApplicationBar.Buttons.Add(appBarButton);

            // Create a new menu item with the localized string from AppResources.
            ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
            ApplicationBar.MenuItems.Add(appBarMenuItem);
        }
    }
}