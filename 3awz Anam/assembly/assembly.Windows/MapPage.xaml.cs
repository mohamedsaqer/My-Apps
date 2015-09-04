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
using Bing.Maps;
using Bing.Maps.Directions;
using Windows.Devices.Geolocation;
using Windows.UI.Popups;
using Windows.UI;
using Newtonsoft.Json;
using assembly.Model;
using Windows.Web.Http;
// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237
namespace assembly
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class MapPage : Page
    {
        MapShapeLayer shapeLayer;
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
        public MapPage()
        {
            this.InitializeComponent();
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += navigationHelper_LoadState;
            this.navigationHelper.SaveState += navigationHelper_SaveState;
            NW.Data_in();
            //  GetMyLocation();
            getTheNear();
        }
        private async void GetMyLocation()
        {
            var geolocator = new Windows.Devices.Geolocation.Geolocator();
            Geoposition myGeoposition = await geolocator.GetGeopositionAsync();
            Location mylocation = new Location(myGeoposition.Coordinate.Latitude, myGeoposition.Coordinate.Longitude);
            // Make my current location the center of the Map.
            this.MyMap.Center = mylocation;
            this.MyMap.ZoomLevel = 15;
            //Create a small shape to mark the current location.
            Pushpin pushpin = new Pushpin();
            pushpin.Text = "S";
            MapLayer.SetPosition(pushpin, mylocation);
            MyMap.Children.Add(pushpin);
        }
        public static double CalculateDistance(double lat1, double long1, double lat2, double long2)
        {
            const double degreesToRadians = (Math.PI / 180.0);
            const double earthRadius = 6371; // kilometers
            // convert latitude and longitude values to radians
            var prevRadLat = lat2 * degreesToRadians;
            var prevRadLong = long2 * degreesToRadians;
            var currRadLat = lat1 * degreesToRadians;
            var currRadLong = long1 * degreesToRadians;
            // calculate radian delta between each position.
            var radDeltaLat = currRadLat - prevRadLat;
            var radDeltaLong = currRadLong - prevRadLong;
            // calculate distance
            var expr1 = (Math.Sin(radDeltaLat / 2.0) *
                         Math.Sin(radDeltaLat / 2.0)) +
                        (Math.Cos(prevRadLat) *
                         Math.Cos(currRadLat) *
                         Math.Sin(radDeltaLong / 2.0) *
                         Math.Sin(radDeltaLong / 2.0));
            var expr2 = 2.0 * Math.Atan2(Math.Sqrt(expr1),
                                         Math.Sqrt(1 - expr1));
            var distance = (earthRadius * expr2);
            return distance * 1000;  // return results as meters
        }
        public async void getTheNear()
        {
            List<double> containerList;
            try
            {
                // Get my current  location on the map 
                Geolocator myGeolocator = new Geolocator();
                Geoposition myGeoposition = await myGeolocator.GetGeopositionAsync();
                // Locations mapdataobject = new Locations();
                // Fill_Data filldata = new Fill_Data();
                //filldata.Store_Data();
                containerList = new List<double>();
                List<hotel> TempList = new List<hotel>();
                for (int i = 0; i < (NW.mylist.Count); i++)
                {
                    containerList.Add(CalculateDistance(myGeoposition.Coordinate.Point.Position.Latitude, myGeoposition.Coordinate.Point.Position.Longitude,
           double.Parse(NW.mylist[i].Latitude.ToString()),
           double.Parse(NW.mylist[i].Longitude.ToString())));
                    TempList.Add(new hotel()
                    {
                        Latitude = NW.mylist[i].Latitude,
                        Name = NW.mylist[i].Name,
                        Longitude = NW.mylist[i].Longitude
                    });
                }
                //#region Searching Algorithm
                double dis = containerList.Min();
                int k = 0;
                for (; ; k++)
                {
                    if (dis == containerList[k])
                    {
                        break;
                    }
                }
                double _long = 0, _lat = 0;
                _lat = double.Parse(TempList[k].Latitude.ToString());
                _long = double.Parse(TempList[k].Longitude.ToString());
                DrawRoute(_lat, _long, "0");
            }
            catch { }
        }
        public double Longitude;
        public double Latitude;
        public async void GetCurrentLocation()
        {
            try
            {
                Pushpin pushpin = new Pushpin();
                Geolocator MyGeolocator = new Geolocator();
                MyGeolocator.DesiredAccuracy = PositionAccuracy.High;
                Geoposition MyGeoposition = await MyGeolocator.GetGeopositionAsync();
                Latitude = MyGeoposition.Coordinate.Latitude;
                Longitude = MyGeoposition.Coordinate.Longitude;
                var CurrentLocation = new Bing.Maps.Location(Latitude, Longitude);
                MyMap.Center = CurrentLocation;
                MyMap.ZoomLevel = 15;
                MyMap.Children.Add(pushpin);
                MapLayer.SetPosition(pushpin, CurrentLocation);
            }
            catch
            {
                MessageDialog error = new MessageDialog("please check your internet conenction!!");
                error.ShowAsync();
            }
        }
        List<ResourceSet> resourceSet = new List<ResourceSet>();
        Resource resource;
        List<ItineraryItem> items = new List<ItineraryItem>();
        List<Location> loc = new List<Location>();
        public async void DrawRoute(double lat, double lon, string falg)
        {
            //try
            //{
            string point2 = "";
            Geolocator myGeolocator = new Geolocator();
            Geoposition myGeoposition = await myGeolocator.GetGeopositionAsync();
            string point1 = myGeoposition.Coordinate.Latitude + "," + myGeoposition.Coordinate.Longitude;
            GetCurrentLocation();
            point2 = lat + "," + lon;
            string reqURL = "http://dev.virtualearth.net/REST/V1/Routes?wp.0=" + point1 + "&wp.1=" + point2 + "&key=AgGh6rnsoa0ho6TQLJ2Sm-gVwIRzUmxnB2MkNdEiglFsJsfXxqBFZkKdetZFyY7q";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(new Uri(reqURL));
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var rootObject = JsonConvert.DeserializeObject<RootObject>(jsonResponse);
            foreach (ResourceSet set in rootObject.resourceSets)
            {
                resourceSet.Add(set);
            }
            loc.Clear();
            resource = resourceSet[0].resources[0];
            items = resource.routeLegs[0].itineraryItems;
            // Colleting location points to draw route got in response. 
            foreach (ItineraryItem item in items)
            {
                loc.Add(new Location() { Latitude = item.maneuverPoint.coordinates[0], Longitude = item.maneuverPoint.coordinates[1] });
            }
            // Declaring Object of MapPolyline to Draw Route
            MapPolyline line;
            line = new MapPolyline();
            // Defining color to Polyline that is Red you can give any color to it. 
            if (falg == "0")
                line.Color = Colors.Red;
            else if (falg == "1")
                line.Color = Colors.Black;
            // Defining width of Polyline so it can easily be visible to naked eye. 
            line.Width = 5;
            // Giving Collection of location points to Map Polyline     
            foreach (Location l in loc)
            {
                line.Locations.Add(l);
            }
            // Defining Map Shape layer Object to add Polyline shape to it. 
            shapeLayer = new MapShapeLayer();
            // Adding line to Shape Layer 
            shapeLayer.Shapes.Add(line);
            // Adding Shape Layer to Map
            MyMap.ShapeLayers.Add(shapeLayer);
            // Calculating Mid between both location to set center of Map
            int mid;
            if (loc.Count % 2 == 0)
            {
                mid = loc.Count / 2;
            }
            else
            {
                mid = (loc.Count + 1) / 2;
            }
            // Setting center of Map to Middle of Both Locations
            MyMap.Center = loc[mid];
            // Setting ZoomLevel of Map
            MyMap.ZoomLevel = 14;
            //}
            //catch (Exception ex)
            //{
            //    Debug.WriteLine(ex.ToString());
            //}
            //finally
            //{
            //  //  drawroute.IsEnabled = true;
            //   // progress.Visibility = Visibility.Collapsed;
            //}
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
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedTo(e);
        }
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedFrom(e);
        }
        #endregion
    }
}