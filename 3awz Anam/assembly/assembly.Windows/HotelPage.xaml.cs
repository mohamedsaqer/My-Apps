using assembly.Common;
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
using Windows.UI.Xaml.Media.Imaging;
using Windows.Devices.Geolocation;
using BingMapsHelpers;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace assembly
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class HotelPage : Page
    {

        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        /// <summary>
        /// This can be changed to a strongly typed view model.
        /// </summary>
        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        /// <summary>
        /// NavigationHelper is used on each page to aid in navigation and 
        /// process lifetime management
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }


        Data NW = new Data();
        public HotelPage()
        {
            this.InitializeComponent();
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += navigationHelper_LoadState;
            this.navigationHelper.SaveState += navigationHelper_SaveState;

            NW.Data_in();
            HotelLocation();

        }
        private async void HotelLocation()
        {
            var geolocator = new Windows.Devices.Geolocation.Geolocator();
            Geoposition myGeoposition = await geolocator.GetGeopositionAsync();
            Location mylocation = new Location(NW.mylist[key].Latitude, NW.mylist[key].Longitude);
            // Make my current location the center of the Map.
            this.HotelMap.Center = mylocation;
            this.HotelMap.ZoomLevel = 15;
            //Create a small shape to mark the current location.
            Pushpin pushpin = new Pushpin();
            pushpin.Text = "HERE";
            MapLayer.SetPosition(pushpin, mylocation);
            HotelMap.Children.Add(pushpin);
        }

        /// <summary>
        /// Populates the page with content passed during navigation. Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="sender">
        /// The source of the event; typically <see cref="NavigationHelper"/>
        /// </param>
        /// <param name="e">Event data that provides both the navigation parameter passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested and
        /// a dictionary of state preserved by this page during an earlier
        /// session. The state will be null the first time a page is visited.</param>
        private void navigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="sender">The source of the event; typically <see cref="NavigationHelper"/></param>
        /// <param name="e">Event data that provides an empty dictionary to be populated with
        /// serializable state.</param>
        private void navigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
        }

        #region NavigationHelper registration

        /// The methods provided in this section are simply used to allow
        /// NavigationHelper to respond to the page's navigation methods.
        /// 
        /// Page specific logic should be placed in event handlers for the  
        /// <see cref="GridCS.Common.NavigationHelper.LoadState"/>
        /// and <see cref="GridCS.Common.NavigationHelper.SaveState"/>.
        /// The navigation parameter is available in the LoadState method 
        /// in addition to page state preserved during an earlier session.
        int key;
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedTo(e);
            // this condition to make sure that you got data into the index you sent it from mainpage
            if (e.Parameter != null && !string.IsNullOrWhiteSpace(e.Parameter.ToString()))
            {
                 key = int.Parse(e.Parameter.ToString());
                //phone.text " the name of the textblock into your xaml code" = NW.mylist[key].phone " the path of the data that will put it into the textblock"
                phone.Text = NW.mylist[key].Phone.ToString();
                name.Text = NW.mylist[key].Name;
                address.Text = NW.mylist[key].Address;
                //hotellink.Text = NW.mylist[key].Link;
                //bookinglink.Text = NW.mylist[key].BookingLink;
                // to bind a pic you must creat bitmapimage to take the pic into it, and then send it to the name of your image source into the xaml
                pic.ItemsSource = NW.mylist[key].PhotosList;
                FlipViewFlipAuto();
                
            }
        }
        

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedFrom(e);
        }

        #endregion

        private void BookingButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(WebPageView), NW.mylist[key].BookingLink);
        }

        private void LinkButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(WebPageView), NW.mylist[key].Link);
        }

        public void FlipViewFlipAuto()
        {
            try
            {
                int change = 1;


                DispatcherTimer timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromSeconds(2);
                timer.Tick += (o, a) =>
                {
                    // If we'd go out of bounds then reverse
                    int newIndex = pic.SelectedIndex + change;
                    if (newIndex >= pic.Items.Count || newIndex < 0)
                    {
                        change *= -1;
                    }


                    pic.SelectedIndex += change;
                };


                timer.Start();
            }
            catch
            { }
        }
    }
}
