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
            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
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
            kkkk.SelectedIndex = 1;

        }

        private void Four_Checked(object sender, RoutedEventArgs e)
        {
            myUri = new Uri(_totraial);
            allwords.Source = myUri;
            kkkk.SelectedIndex = 1;
        }

        private void Third_Checked(object sender, RoutedEventArgs e)
        {
            myUri = new Uri(_book);
            allwords.Source = myUri;
            kkkk.SelectedIndex = 1;
        }

        private void Two_Checked(object sender, RoutedEventArgs e)
        {
            myUri = new Uri(_ide);
            allwords.Source = myUri;
            kkkk.SelectedIndex = 1;
        }

        private void On_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(about));
        }
    }
}
