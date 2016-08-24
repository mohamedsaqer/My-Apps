using el_3abkry;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Networking.Connectivity;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using العبقرى;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace العبقرى
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public static bool IsInternet()
        {
            ConnectionProfile connections = NetworkInformation.GetInternetConnectionProfile();
            bool internet = connections != null && connections.GetNetworkConnectivityLevel() == NetworkConnectivityLevel.InternetAccess;
            return internet;
        }
        DataModel DMobject;
        PoliceOfficeModel POMobject;
        FillModel FMobject;
        public MainPage()
        {
            this.InitializeComponent();
            if (!IsInternet())
            {
                ShowMessage("Network Error");
            }
            FMobject = new FillModel();
            DMobject = new DataModel();
            POMobject = new PoliceOfficeModel();
            FMobject.FillingModel();
            showlist.ItemsSource = FMobject.GovernrateList[0].POfficeList;
            showlist.SelectedIndex = 0;
            book.IsChecked = true;
            MySplitViev.IsPaneOpen = false;
            MySplitViev.DisplayMode = SplitViewDisplayMode.Inline;
        }
        private async void ShowMessage(string message)
        {
            MessageDialog dialog = new MessageDialog(message);
            dialog.Title = "Network Error";
            dialog.Content = "There was a problem retrieving the Data.";
            dialog.Commands.Add(new UICommand("Close", new UICommandInvokedHandler(this.Open)));
            await dialog.ShowAsync();
        }
        private void Open(IUICommand command)
        {
            Application.Current.Exit();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.MyFrame.Navigate(typeof(Views.Home_Page));
            Header.Text = "Home";
        }
        private void Home_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as RadioButton;
            if (button != null)
            {
                switch (button.Content.ToString())
                {
                    case "About":
                        About.about();
                        break;
                }
                MySplitViev.IsPaneOpen = false;
                Header.Text = button.Content.ToString();
            }
        }
        private void SplitTogleBtn_Click(object sender, RoutedEventArgs e)
        {
            MySplitViev.IsPaneOpen = !MySplitViev.IsPaneOpen;
        }
        string _book;
        public string _historylink;
        public string _ide;
        public string _totraial;
        public string _test;

        private void showlist_oneitem(object sender, SelectionChangedEventArgs e)
        {
            StatusPanel.Visibility = Visibility.Visible;
            int _listId = (showlist.SelectedItem as PoliceOfficeModel).Id_Office;
            string _officeName = FMobject.GovernrateList[0].POfficeList[_listId].OfficeName;
            _book = FMobject.GovernrateList[0].POfficeList[_listId].book;
            _historylink = FMobject.GovernrateList[0].POfficeList[_listId].historylink;
            _ide = FMobject.GovernrateList[0].POfficeList[_listId].ide;
            _totraial = FMobject.GovernrateList[0].POfficeList[_listId].totorial;
            _test = FMobject.GovernrateList[0].POfficeList[_listId].test;
            book.IsChecked = true;
            One_Checked(sender, e);
            Header.Text = _officeName;
            MySplitViev.IsPaneOpen = false;
        }
        Uri myUri;
        public void One_Checked(object sender, RoutedEventArgs e)
        {
            myUri = new Uri(_historylink);
            myweb.Source = myUri;
            ring.IsActive = true;

        }

        private void Four_Checked(object sender, RoutedEventArgs e)
        {
            myUri = new Uri(_totraial);
            myweb.Source = myUri;
            ring.IsActive = true;
        }

        private void Third_Checked(object sender, RoutedEventArgs e)
        {
            myUri = new Uri(_book);
            myweb.Source = myUri;
            ring.IsActive = true;
        }

        private void Two_Checked(object sender, RoutedEventArgs e)
        {
            myUri = new Uri(_ide);
            myweb.Source = myUri;
            ring.IsActive = true;
        }

        private void Ring_View(object sender, NavigationEventArgs e)
        {
            ring.IsActive = false;
        }

        private void Fifth_Checked(object sender, RoutedEventArgs e)
        {
            myUri = new Uri(_test);
            myweb.Source = myUri;
            ring.IsActive = true;
        }
    }
}
