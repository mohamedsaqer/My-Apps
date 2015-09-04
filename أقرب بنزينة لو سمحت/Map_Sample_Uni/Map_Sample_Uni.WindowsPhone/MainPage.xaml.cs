using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Services.Maps;
using Windows.Storage.Streams;
using Windows.UI.ViewManagement;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;
using Map_Sample_Uni.Code;
using Map_Sample_Uni.Common;
using Windows.UI.Popups;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Map_Sample_Uni
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        FillingData FMobject;
        FillModel DMobject;
        LocationsDataModel POMobject;
        public MainPage()
        {
            this.InitializeComponent();
            InitializeMapData();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            GetMyLication();
            ReverseGeocode();
        }

        void InitializeMapData()
        {
            
            FMobject = new FillingData();
            DMobject = new FillModel();
            POMobject = new LocationsDataModel();
            FMobject.FillGovernrateData();
            LV_POList.ItemsSource = FMobject.PublicGovernrateList[0].LocationList;
        }

        #region adding icon 3ala elmap-- el function di msh 3mltelha call, msh est5demtaha
        private void AddMapIcon()
        {
            MapIcon MapIcon1 = new MapIcon();
            MapIcon1.Location = new Geopoint(new BasicGeoposition()
            {
                Latitude = 30.054632,
                Longitude = 31.314325
            });
            MyMap.Center = new Geopoint(new BasicGeoposition
            {
                Latitude = 30.054632,
                Longitude = 31.314325
            });
            MapIcon1.NormalizedAnchorPoint = new Windows.Foundation.Point(30.054632, 31.314325);
            MapIcon1.Title = "Testing App Factory";
            MyMap.MapElements.Add(MapIcon1);

            

        }
        #endregion

      

        #region Function btgeeb el direction w el estimated time ben two points, w elkilometers
        private void btn_getRoute(object sender, RoutedEventArgs e)
        {
            GetRouteAndDirections();
        }
        //el funtion di tba5od no2t bdaya w no2tt nhaya,
        //then bt2ol el etgahaat ezay mn no2tet elbdaya l,no2tt elnehaya
        //w kman bt7sb el time ma ben el no2teten w elmasafa ma benhom
        private async void GetRouteAndDirections()
        {

            BasicGeoposition startLocation = new BasicGeoposition();
            startLocation.Latitude = 30.054632;
            startLocation.Longitude = 31.314325;
            Geopoint startPoint = new Geopoint(startLocation);

            BasicGeoposition endLocation = new BasicGeoposition();
            endLocation.Latitude = 30.045189;
            endLocation.Longitude = 31.270243;
            Geopoint endPoint = new Geopoint(endLocation);

            // Get the route between the points.
            MapRouteFinderResult routeResult =
                await MapRouteFinder.GetDrivingRouteAsync(
                startPoint,
                endPoint,
                MapRouteOptimization.Time,
                MapRouteRestrictions.None);

            if (routeResult.Status == MapRouteFinderStatus.Success)
            {
                // Display summary info about the route.

                string _time = "Total estimated time (minutes) = "
                    + routeResult.Route.EstimatedDuration.TotalMinutes.ToString();

                string _kiloMeters = "Total length (kilometers) = "
                    + (routeResult.Route.LengthInMeters / 1000).ToString();

            }
            else
            {
                string _problem =
                    "A problem occurred: " + routeResult.Status.ToString();
            }

        }

        #endregion

        #region Function btgeeb el3nwaan
        // el function di bta5od long w lat w btrg3 esm elmkaan bta3hom "el 3nwan"
        
        private async void ReverseGeocode()
        {
            // Location to reverse geocode.

            BasicGeoposition location = new BasicGeoposition();
            location.Latitude = 30.054632;
            location.Longitude = 31.314325;
            Geopoint pointToReverseGeocode = new Geopoint(location);

            // Reverse geocode the specified geographic location.
            MapLocationFinderResult result =
                await MapLocationFinder.FindLocationsAtAsync(pointToReverseGeocode);

            // If the query returns results, display the name of the town
            // contained in the address of the first result.
            if (result.Status == MapLocationFinderStatus.Success)
            {
                string address = result.Locations[0].Address.Town + "," +
                    result.Locations[0].Address.Street;
                pop_search.IsOpen = true;
                txtBlk_popup.Text = "بنزينة : " + "\n" + "العنوان : " + address + "\n" + " يوجد بالبنزينة : " + "\n";
                
            }
        }

        #endregion

        #region Function btrsm el route
        
        //el function di bta5od no2teten, wa7da start w wa7da end, then btrsm el route 3ala 5areta
        private async void ShowRouteOnMap()
        {
            BasicGeoposition startLocation = new BasicGeoposition();
            startLocation.Latitude = 30.054632;
            startLocation.Longitude = 31.314325;
            Geopoint startPoint = new Geopoint(startLocation);

            BasicGeoposition endLocation = new BasicGeoposition();
            endLocation.Latitude = 30.045189;
            endLocation.Longitude = 31.270243;
            Geopoint endPoint = new Geopoint(endLocation);
            // Get a route as shown previously.
            MapRouteFinderResult routeResult =
               await MapRouteFinder.GetDrivingRouteAsync(
               startPoint,
               endPoint,
               MapRouteOptimization.Time,
               MapRouteRestrictions.None);

            if (routeResult.Status == MapRouteFinderStatus.Success)
            {
                // Use the route to initialize a MapRouteView.
                MapRouteView viewOfRoute = new MapRouteView(routeResult.Route);
                viewOfRoute.RouteColor = Colors.Yellow;
                viewOfRoute.OutlineColor = Colors.Black;

                // Add the new MapRouteView to the Routes collection
                // of the MapControl.
                MyMap.Routes.Add(viewOfRoute);

                // Fit the MapControl to the route.
                await MyMap.TrySetViewBoundsAsync(
                    routeResult.Route.BoundingBox,
                    null,
                    Windows.UI.Xaml.Controls.Maps.MapAnimationKind.None);
            }
        }
        #endregion

        #region Function btgeeb my location awel el app ma yft7
        private void AppBarBtn_nearest_click(object sender, RoutedEventArgs e)
        {
            ClearMap();
            GetNearest();
        }
        double MyPositionLatitude, MyPositionLongitude;
        async void GetMyLication()
        {
            try
            {
                Geolocator geo = null;
                if (geo == null)
                {
                    geo = new Geolocator();
                }
                Geoposition pos = await geo.GetGeopositionAsync();
                MyMap.Center = new Windows.Devices.Geolocation.Geopoint(new BasicGeoposition
                {
                    Latitude = pos.Coordinate.Point.Position.Latitude,
                    Longitude = pos.Coordinate.Point.Position.Longitude
                });
                MyPositionLatitude = pos.Coordinate.Point.Position.Latitude;
                MyPositionLongitude = pos.Coordinate.Point.Position.Longitude;
                MyMap.ZoomLevel = 18;
                MapIcon MeAsMapIcon1 = new Windows.UI.Xaml.Controls.Maps.MapIcon();
         //       MeAsMapIcon1.Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/MapPin.png"));
                MeAsMapIcon1.Location = new Geopoint(new BasicGeoposition()
                {
                    Latitude = pos.Coordinate.Point.Position.Latitude,
                    Longitude = pos.Coordinate.Point.Position.Longitude
                });
                //MeAsMapIcon1.NormalizedAnchorPoint = new Windows.Foundation.Point(0.5, 1.0);
                //MeAsMapIcon1.Title = "أنا";
                //MyMap.MapElements.Add(MeAsMapIcon1);

            }
            catch
            {
            }
        }
        #endregion

        #region get nearest point to your location
        public ObservableCollection<LocationsDataModel> TempList;
        FillingData FDObject = new FillingData();
        List<double> _allDestance = new List<double>();
        public async void GetNearest()
        {
            try
            {
                Geolocator geo = null;
                if (geo == null)
                {
                    geo = new Geolocator();
                }
                Geoposition pos = await geo.GetGeopositionAsync();
                FDObject.PublicGovernrateList.Clear();
                _allDestance.Clear();
                FDObject.FillGovernrateData();
                TempList = new ObservableCollection<LocationsDataModel>();
                for (int i = 0; i < FDObject.PublicGovernrateList.Count; i++)
                {
                    for (int j = 0; j < FDObject.PublicGovernrateList[i].LocationList.Count; j++)
                    {
                        _allDestance.Add(GetDistanceBetweenPoints(pos.Coordinate.Point.Position.Latitude,
                            pos.Coordinate.Point.Position.Longitude,
                             double.Parse(FDObject.PublicGovernrateList[i].LocationList[j].Latitude),
                             double.Parse(FDObject.PublicGovernrateList[i].LocationList[j].Longitude)));
                        TempList.Add(new LocationsDataModel()
                        {
                            Latitude = FDObject.PublicGovernrateList[i].LocationList[j].Latitude,
                            Longitude = FDObject.PublicGovernrateList[i].LocationList[j].Longitude,
                            PlaceName = FDObject.PublicGovernrateList[i].LocationList[j].PlaceName
                        });
                    }
                }
                double _minumuDestance = _allDestance.Min();

                int _ListId = 0;
                for (; ; _ListId++)
                {
                    if (_minumuDestance == _allDestance[_ListId])
                    {
                        break;
                    }
                }
                DrawRouteBetweenMeAndSpecificPoint(Double.Parse(TempList[_ListId].Latitude), Double.Parse(TempList[_ListId].Longitude));
                mynearadd = TempList[_ListId].PlaceName;
                //DrawRouteBetweenMeAndSpecificPoint(Double.Parse(TempList[_ListId].Latitude),Double.Parse(TempList[_ListId].Longitude));

            }
            catch { }
        }
        string mynearadd;

        #endregion

        #region Function btgeb elmsafa ma ben no2teteen
        public double GetDistanceBetweenPoints(double lat1, double long1, double lat2, double long2)
        {
            double distance = 0;

            double dLat = (lat2 - lat1) / 180 * Math.PI;
            double dLong = (long2 - long1) / 180 * Math.PI;

            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2)
                        + Math.Cos(lat2) * Math.Sin(dLong / 2) * Math.Sin(dLong / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            //Calculate radius of earth
            // For this you can assume any of the two points.
            double radiusE = 6378135; // Equatorial radius, in metres
            double radiusP = 6356750; // Polar Radius

            //Numerator part of function
            double nr = Math.Pow(radiusE * radiusP * Math.Cos(lat1 / 180 * Math.PI), 2);
            //Denominator part of the function
            double dr = Math.Pow(radiusE * Math.Cos(lat1 / 180 * Math.PI), 2)
                            + Math.Pow(radiusP * Math.Sin(lat1 / 180 * Math.PI), 2);
            double radius = Math.Sqrt(nr / dr);

            //Calculate distance in meters.
            distance = radius * c;
            if (double.IsNaN(distance))
                return 9999999999999999999;
            else
                return distance;
        }

        #endregion

        #region Function bt3ml clear ll,drawings ely 3ala elmap
        void ClearMap()
        {
            MyMap.Children.Clear();
            MyMap.MapElements.Clear();
            MyMap.Routes.Clear();
        }
        #endregion

        #region Function bta5od long w lat w tersmhom
        void DrawOnePoint(double _lat, double _long)
        {
            try
            {
                MyMap.Center = new Windows.Devices.Geolocation.Geopoint(new BasicGeoposition
                {
                    Latitude = _lat,
                    Longitude = _long
                });
                MyMap.ZoomLevel = 18;
                MapIcon MeAsMapIcon1 = new Windows.UI.Xaml.Controls.Maps.MapIcon();
               // MeAsMapIcon1.Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/pushpin.png"));
                MeAsMapIcon1.Location = new Geopoint(new BasicGeoposition()
                {
                    Latitude = _lat,
                    Longitude = _long
                });
                MeAsMapIcon1.NormalizedAnchorPoint = new Windows.Foundation.Point(0.5, 1.0);
                MeAsMapIcon1.Title = "المكان التانى";
                MyMap.MapElements.Add(MeAsMapIcon1);
            }
            catch
            {
            }
        }
        #endregion

        #region Function bta5od Point 3ala el 5areta, w btrsm el route ma beny w maben el point di
        async void DrawRouteBetweenMeAndSpecificPoint(double _lat, double _long)
        {
            try
            {
                ClearMap();
                BasicGeoposition startLocation = new BasicGeoposition();
                startLocation.Latitude = MyPositionLatitude;
                startLocation.Longitude = MyPositionLongitude;
                Geopoint startPoint = new Geopoint(startLocation);

                BasicGeoposition endLocation = new BasicGeoposition();
                endLocation.Latitude = _lat;
                endLocation.Longitude = _long;
                Geopoint endPoint = new Geopoint(endLocation);
                string from = MyPositionLatitude.ToString() + "," + MyPositionLongitude.ToString();
                string to = _lat.ToString() + "," + _long.ToString();
                if (!string.IsNullOrWhiteSpace(from))
                {
                    if (!string.IsNullOrWhiteSpace(to))
                    {
                        // Get a route as shown previously.
                        MapRouteFinderResult routeResult =
                           await MapRouteFinder.GetDrivingRouteAsync(
                           startPoint,
                           endPoint,
                           MapRouteOptimization.Time,
                           MapRouteRestrictions.None);

                        MapIcon MeAsMapIcon = new Windows.UI.Xaml.Controls.Maps.MapIcon();
                        MeAsMapIcon.Location = new Geopoint(new BasicGeoposition()
                        {
                            Latitude = MyPositionLatitude,
                            Longitude = MyPositionLongitude
                        });
                        MeAsMapIcon.NormalizedAnchorPoint = new Windows.Foundation.Point(0.5, 1.0);
                        MeAsMapIcon.Title = "أنا";
                        MyMap.MapElements.Add(MeAsMapIcon);

                        MapIcon thereAsMapIcon = new Windows.UI.Xaml.Controls.Maps.MapIcon();
                        thereAsMapIcon.Location = new Geopoint(new BasicGeoposition()
                        {
                            Latitude = _lat,
                            Longitude = _long
                        });
                        thereAsMapIcon.NormalizedAnchorPoint = new Windows.Foundation.Point(0.5, 1.0);
                        thereAsMapIcon.Title = "المكان التانى";
                        MyMap.MapElements.Add(thereAsMapIcon);


                        if (routeResult.Status == MapRouteFinderStatus.Success)
                        {
                            // Use the route to initialize a MapRouteView.
                            MapRouteView viewOfRoute = new MapRouteView(routeResult.Route);
                            viewOfRoute.RouteColor = Colors.DarkBlue;
                            viewOfRoute.OutlineColor = Colors.White;

                            // Add the new MapRouteView to the Routes collection
                            // of the MapControl.
                            MyMap.Routes.Add(viewOfRoute);
                            
                            // Fit the MapControl to the route.
                            await MyMap.TrySetViewBoundsAsync(
                                routeResult.Route.BoundingBox,
                                null,
                                Windows.UI.Xaml.Controls.Maps.MapAnimationKind.None);
                        }
                    }
                    else
                    {
                        ShowMessage("Invalid 'To' location.");
                    }
                }
                else
                {
                    ShowMessage("Invalid 'From' location.");
                }
            }
            catch
            {

            }
        }
        #endregion

        private async void ShowMessage(string message)
        {
            MessageDialog dialog = new MessageDialog(message);
            await dialog.ShowAsync();
        }

        private void btn_ok_Click(object sender, RoutedEventArgs e)
        {
            pop_search.IsOpen = false;
        }
         
        private void LV_POList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ClearMap();
            Pbar.IsActive = true;
            int _listId = (LV_POList.SelectedItem as LocationsDataModel).Id_location;
            string _officeName = FMobject.PublicGovernrateList[0].LocationList[_listId].PlaceName;
            string _notes = FMobject.PublicGovernrateList[0].LocationList[_listId].notes;
            string _latitude = FMobject.PublicGovernrateList[0].LocationList[_listId].Latitude;
            string _longitude = FMobject.PublicGovernrateList[0].LocationList[_listId].Longitude;
            double lat = double.Parse(_latitude);
            double log = double.Parse(_longitude);
            DrawRouteBetweenMeAndSpecificPoint(lat, log);
            pivot.SelectedIndex = 1;
            

        }
        
        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(about));
        }
    }
}
