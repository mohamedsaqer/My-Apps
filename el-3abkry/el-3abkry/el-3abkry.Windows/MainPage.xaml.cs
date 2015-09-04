using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Networking.Connectivity;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace el_3abkry
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        DataModel DMobject;
        PoliceOfficeModel POMobject;
        FillModel FMobject;
        public MainPage()
        {
            this.InitializeComponent();
            FMobject = new FillModel();
            DMobject = new DataModel();
            POMobject = new PoliceOfficeModel();
            FMobject.FillingModel();
            showlist.ItemsSource = FMobject.GovernrateList[0].POfficeList;
            showlist.SelectedIndex = 0;
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
            request.Data.Properties.Title = " El - 3abkry";
            request.Data.SetText("this app help you to know the best 10 programming languages of every year and learn them by many ways ( books or tutorial )and offer to you all the materials and IDEs" + System.Environment.NewLine + (new Uri("ms-windows-store:PDP?PFN=" + name)).ToString());
        }




        string _book;
        public string _historylink;
        public string _ide;
        public string _totraial;

        private void showlist_oneitem(object sender, SelectionChangedEventArgs e)
        {

            int _listId = (showlist.SelectedItem as PoliceOfficeModel).Id_Office;
            string _officeName = FMobject.GovernrateList[0].POfficeList[_listId].OfficeName;
            _book = FMobject.GovernrateList[0].POfficeList[_listId].book;
            _historylink = FMobject.GovernrateList[0].POfficeList[_listId].historylink;
            _ide = FMobject.GovernrateList[0].POfficeList[_listId].ide;
            _totraial = FMobject.GovernrateList[0].POfficeList[_listId].totorial;
            radio1.IsChecked = true;



        }
        Uri myUri;
        private void One_Checked(object sender, RoutedEventArgs e)
        {
            myUri = new Uri(_historylink);
            allwords.Source = myUri;

        }

        private void Four_Checked(object sender, RoutedEventArgs e)
        {
            myUri = new Uri(_totraial);
            allwords.Source = myUri;
        }

        private void Third_Checked(object sender, RoutedEventArgs e)
        {
            myUri = new Uri(_book);
            allwords.Source = myUri;
        }

        private void Two_Checked(object sender, RoutedEventArgs e)
        {
            myUri = new Uri(_ide);
            allwords.Source = myUri;
        }
    }
}
