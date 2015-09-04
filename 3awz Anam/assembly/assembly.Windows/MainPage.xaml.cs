using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using assembly.Model;
using Windows.Storage;
using Windows.Networking.Connectivity;
using Windows.UI.Popups;
using Windows.ApplicationModel;
using Windows.ApplicationModel.DataTransfer;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace assembly
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        //create a new class type of data "NOT THE MAIN CLASS"
        Data ND = new Data();

        public MainPage()
        {
            this.InitializeComponent();
            // CALL THE method to retrive your list here 
            ND.Data_in();
            // showlist.itemssource " the place that you want to show your list into it" = ND.mylist " the path of your list"
            // showlist.ItemsSource = ND.mylist;
            showlist.DataContext = ND.mylist;


        }


        private async void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckInternetConnectivity())
                return;
            if (ReadAppRatingSetting())
                return;
            MessageDialog msg;
            bool retry = false;
            msg = new MessageDialog("Can you rate the application to help us make it better?");
            msg.Commands.Add(new UICommand("Rate", new UICommandInvokedHandler(this.OpenStoreRating)));
            msg.Commands.Add(new UICommand("Not Now", (uiCommand) => { }));
            msg.Commands.Add(new UICommand("No Thanks", new UICommandInvokedHandler(this.IgnoreRating)));
            msg.DefaultCommandIndex = 0;
            msg.CancelCommandIndex = 1;
            await msg.ShowAsync();
            while (retry)
            {
                try { await msg.ShowAsync(); }
                catch { }
            }
        }
        public static bool CheckInternetConnectivity()
        {
            var internetProfile = NetworkInformation.GetInternetConnectionProfile();
            if (internetProfile == null)
                return false;
            return (internetProfile.GetNetworkConnectivityLevel() == NetworkConnectivityLevel.InternetAccess);
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
        private async void OpenStoreRating(IUICommand command)
        {
            string name = Package.Current.Id.FamilyName;
            await Windows.System.Launcher.LaunchUriAsync(new Uri("ms-windows-store:REVIEW?PFN=" + name));
            //await Windows.System.Launcher.LaunchUriAsync(new Uri("ms-windows-store:REVIEW?PFN=6b7b722b-a69d-42fc-8fba-f1b30776edec"));
            //SaveAppRatingSetting();
        }
        private void IgnoreRating(IUICommand command)
        {
            //SaveAppRatingSetting();
        }
        private void Share_Click(object sender, RoutedEventArgs e)
        {
            DataTransferManager.ShowShareUI();
            ShareSourceLoad();
        }
        private void ShareSourceLoad()
        {
            DataTransferManager dataTransferManager = DataTransferManager.GetForCurrentView();
            dataTransferManager.DataRequested += new TypedEventHandler<DataTransferManager, DataRequestedEventArgs>(this.DataRequested);
        }
        private void DataRequested(DataTransferManager sender, DataRequestedEventArgs e)
        {
            string name = Package.Current.Id.FamilyName;
            DataRequest request = e.Request;
            request.Data.Properties.Title = "عawz anam";
            request.Data.SetText("With this App you can find all hotels near you.This App include all the details about many hotels.from this App you can book your room.and see photos from the hotel.and know the road to the hotel by the map.also you can search about your favorite Hotel." + System.Environment.NewLine + (new Uri("ms-windows-store:PDP?PFN=" + name)).ToString());
        }



        

        // its an EVENT created into the list you want to show it, when the itemasource is clicked do the next lines
        private void showlist_ItemClick(object sender, ItemClickEventArgs e)
        {
            // we create an obj to get the list
            var obj = ((hotel )e.ClickedItem);
            // create index to get the id of every user
            int index = obj.id;
            // navigate to the page you want, with the id you want to show its data
            Frame.Navigate(typeof(HotelPage), index);
        }

        private void SearchBox_QuerySubmitted(SearchBox sender, SearchBoxQuerySubmittedEventArgs args)
        {
            this.Frame.Navigate(typeof(SearchResultsPage), args.QueryText);
        }

        private void AppBarButton_getNearest(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MapPage));
        }
    }
}
