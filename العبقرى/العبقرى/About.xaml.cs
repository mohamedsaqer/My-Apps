using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace العبقرى
{
    public sealed partial class About : UserControl
    {
        public About()
        {
            this.InitializeComponent();
        }
        public async static void about()
        {
            var gg = new About();
            ContentDialog tt = new ContentDialog();
            tt.PrimaryButtonText = "ok";
            tt.PrimaryButtonClick += Ok_Click;
            tt.SecondaryButtonText = "Rate Us";
            tt.SecondaryButtonClick += Rate_Click;
            tt.Title = "العبقرى";
            tt.Content = gg;
            await tt.ShowAsync();
        }

        private static async void Rate_Click(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            //throw new NotImplementedException();
            //if (ReadAppRatingSetting())
            //    return;
            //OpenStoreRating();
            await Launcher.LaunchUriAsync(new Uri(string.Format("ms-windows-store:REVIEW?PFN={0}", Windows.ApplicationModel.Package.Current.Id.FamilyName)));
        }
        ApplicationDataContainer _roamingData = ApplicationData.Current.RoamingSettings;
        ApplicationDataContainer _localData = ApplicationData.Current.LocalSettings;
        private bool ReadAppRatingSetting()
        {
            if (_localData.Values["AppRatingDone"] != null)
                return (bool)_localData.Values["AppRatingDone"];
            if (_roamingData.Values["AppRatingDone"] != null)
                return (bool)_roamingData.Values["AppRatingDone"];
            return false;
        }
        private async void OpenStoreRating()
        {
            string name = Package.Current.Id.FamilyName;
            await Windows.System.Launcher.LaunchUriAsync(new Uri("ms-windows-store:REVIEW?PFN=" + name));
            //await Windows.System.Launcher.LaunchUriAsync(new Uri("ms-windows-store:REVIEW?PFN=6b7b722b-a69d-42fc-8fba-f1b30776edec"));
            //SaveAppRatingSetting();
        }

        private static void Ok_Click(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            //throw new NotImplementedException();
        }

        private void HyperLink(object sender, RoutedEventArgs e)
        {

            var uri = new Uri("https://mohamedsaqer.wordpress.com/privacy-policy/");
            IAsyncOperation<bool> x = Windows.System.Launcher.LaunchUriAsync(uri);
        }
        //facebook tap
        private void Image_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var uri = new Uri("https://www.facebook.com/realmohamedsaqer");
            IAsyncOperation<bool> x = Windows.System.Launcher.LaunchUriAsync(uri);
        }

        //facebook tap
        private void TextBlock_Tapped_1(object sender, TappedRoutedEventArgs e)
        {
            var uri = new Uri("https://www.facebook.com/realmohamedsaqer");
            IAsyncOperation<bool> x = Windows.System.Launcher.LaunchUriAsync(uri);
        }

        //twitter tap
        private void Image_Tapped_1(object sender, TappedRoutedEventArgs e)
        {
            var uri = new Uri("https://twitter.com/realmohmedsaqer");
            IAsyncOperation<bool> x = Windows.System.Launcher.LaunchUriAsync(uri);
        }

        //twitter tap
        private void TextBlock_Tapped_2(object sender, TappedRoutedEventArgs e)
        {
            var uri = new Uri("https://twitter.com/realmohmedsaqer");
            IAsyncOperation<bool> x = Windows.System.Launcher.LaunchUriAsync(uri);
        }
    }
}
