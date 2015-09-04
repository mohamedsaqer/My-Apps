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

        private void showlist_ItemClick(object sender, ItemClickEventArgs e)
        {
            // we create an obj to get the list
            var obj = ((hotel)e.ClickedItem);
            // create index to get the id of every user
            int index = obj.id;
            // navigate to the page you want, with the id you want to show its data
            Frame.Navigate(typeof(HotelPage), index);
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(about_page));
        }

        private void AppBarButton_getNearest(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MapPage));
        }
    }
}
