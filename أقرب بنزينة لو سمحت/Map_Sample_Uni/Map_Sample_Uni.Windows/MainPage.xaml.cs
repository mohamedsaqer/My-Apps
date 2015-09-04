using Bing.Maps;
using Map_Sample_Uni.Code;
using Map_Sample_Uni.GeocodeService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.ApplicationModel.DataTransfer;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Networking.Connectivity;
using Windows.Storage;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Map_Sample_Uni
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            InitializeMapData();
        }

        private Geolocator _geolocator = null;
        //private CancellationTokenSource _cts = null;
    

        private MapShapeLayer routeLayer;
        DataModel DMobject;
        PoliceOfficeModel POMobject;
        FillModel FMobject;

        void InitializeMapData()
        {
            _geolocator = new Geolocator();
            FMobject = new FillModel();
            DMobject = new DataModel();
            POMobject = new PoliceOfficeModel();
            routeLayer = new MapShapeLayer();
            myMap.ShapeLayers.Add(routeLayer);
            FMobject.FillingModel();
            LV_POList.ItemsSource = FMobject.GovernrateList[0].POfficeList;

            var loc = new Bing.Maps.Location(29.837452, 31.362296);
            myMap.Center = loc;
            myMap.ZoomLevel = 6;
        }
        double _latitude, _longitude;
        private void LV_POList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Pbar.IsActive = true;
           
                int _listId = (LV_POList.SelectedItem as PoliceOfficeModel).Id_Office;
                _latitude = FMobject.GovernrateList[0].POfficeList[_listId].Latitude;
                _longitude = FMobject.GovernrateList[0].POfficeList[_listId].Longitude;
                _officeName = FMobject.GovernrateList[0].POfficeList[_listId].OfficeName;
                _notes = FMobject.GovernrateList[0].POfficeList[_listId].notes;
                DrawRoute(_latitude, _longitude);
           
        }
        public async void DrawRoute(double _latitude, double _longitude)
        {
            try
            {
                Geolocator myGeolocator = new Geolocator();
                Geoposition myGeoposition = await myGeolocator.GetGeopositionAsync();
                myLat = myGeoposition.Coordinate.Latitude;
                myLong = myGeoposition.Coordinate.Longitude;

                _distance =GetDistanceBetweenPoints(myLat, myLong, _latitude, _longitude);

                ClearMap();
                string to = _latitude.ToString() + "," + _longitude.ToString();
                //string to = "29.983696,31.133655";
                string from = myLat.ToString() + "," + myLong.ToString();
                //string from = "29.963784,30.914312";


                if (!string.IsNullOrWhiteSpace(from))
                {
                    if (!string.IsNullOrWhiteSpace(to))
                    {
                        //Create the Request URL for the routing service
                        Uri routeRequest = new Uri(
                            string.Format("http://dev.virtualearth.net/REST/V1/Routes/Driving?wp.0={0}&wp.1={1}&rpo=Points&key={2}",
                            from, to, myMap.Credentials));

                        //Make a request and get the response
                        Response r = await GetResponse(routeRequest);

                        if (r != null &&
                            r.ResourceSets != null &&
                            r.ResourceSets.Length > 0 &&
                            r.ResourceSets[0].Resources != null &&
                            r.ResourceSets[0].Resources.Length > 0)
                        {
                            Route route = r.ResourceSets[0].Resources[0] as Route;
                            //Get the route line data
                            double[][] routePath = route.RoutePath.Line.Coordinates;
                            LocationCollection locations = new LocationCollection();

                            for (int i = 0; i < routePath.Length; i++)
                            {
                                if (routePath[i].Length >= 2)
                                {
                                    locations.Add(new Bing.Maps.Location(routePath[i][0],
                                                  routePath[i][1]));
                                }
                            }

                            //Create a MapPolyline of the route and add it to the map
                            MapPolyline routeLine = new MapPolyline()
                            {
                                Color = Colors.DarkBlue,
                                Locations = locations,
                                Width = 5
                            };

                            routeLayer.Shapes.Add(routeLine);


                            //Add start and end pushpins
                            Pushpin start = new Pushpin()
                            {
                                Text = "أنا",
                                Background = new SolidColorBrush(Colors.Green)
                            };
                            start.Tapped += start_Tapped;
                            myMap.Children.Add(start);
                            MapLayer.SetPosition(start,
                                new Bing.Maps.Location(route.RouteLegs[0].ActualStart.Coordinates[0],
                                    route.RouteLegs[0].ActualStart.Coordinates[1]));

                            Pushpin end = new Pushpin()
                            {
                                Text = "المكان التاني",
                                Background = new SolidColorBrush(Colors.Red)
                            };
                            end.Tapped += end_Tapped;

                            myMap.Children.Add(end);
                            MapLayer.SetPosition(end,
                                new Bing.Maps.Location(route.RouteLegs[0].ActualEnd.Coordinates[0],
                                route.RouteLegs[0].ActualEnd.Coordinates[1]));

                            myMap.SetView(new LocationRect(locations));
                          
                            Pbar.IsActive = false;
                        }
                        else
                        {
                            ShowMessage("No Results found.");
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
            catch { }
        }
        private void ClearMap()
        {
            myMap.Children.Clear();
            routeLayer.Shapes.Clear();
        }
        double myLat, myLong, _distance;
        string _officeName;
        string _notes;
        string temAdrress = "";


        async void end_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var point = e.GetPosition(myMap);

            Bing.Maps.Location loc;
            myMap.TryPixelToLocation(point, out loc);

            // Declare ReverseGeocode Request – This is the service that will return address for a particular point.

            ReverseGeocodeRequest reverseGeocodeRequest = new ReverseGeocodeRequest();

            // Set the credentials using a valid Bing Maps key – Replace the text in green with your credentials 
            reverseGeocodeRequest.Credentials = new GeocodeService.Credentials();
            reverseGeocodeRequest.Credentials.ApplicationId = "IVMrdHQvM4jM61vTKgKj~TXSvY7rIpcx2F_BN8ng4SQ~AjX0mRb5gJOYJwB5sPCX2QD4t5bgLR9gHGxJvWGNV93rTgrYThbJM3N1w73r8v3u";

            // Set the point to use to find a matching address 
            GeocodeService.Location point1 = new GeocodeService.Location();
            point1.Latitude = loc.Latitude;
            point1.Longitude = loc.Longitude;
            reverseGeocodeRequest.Location = point1;

            // Make the reverse geocode request 
            GeocodeServiceClient geocodeService = new GeocodeServiceClient(GeocodeServiceClient.EndpointConfiguration.BasicHttpBinding_IGeocodeService);
            var geocodeResponse = await geocodeService.ReverseGeocodeAsync(reverseGeocodeRequest);
            if (geocodeResponse.Results.Count > 0)
            {
                temAdrress = geocodeResponse.Results[0].DisplayName;
                pop_search.IsOpen = true;
                txtBlk_popup.Text = "بنزينة : " + _officeName + "\n" + "العنوان: " + temAdrress + "\n" + " يوجد بالبنزينة : " + _notes;
            }
        }

        async void start_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var point = e.GetPosition(myMap);
            var temAdrress = "";
            Bing.Maps.Location loc;
            myMap.TryPixelToLocation(point, out loc);

            // Declare ReverseGeocode Request – This is the service that will return address for a particular point.

            ReverseGeocodeRequest reverseGeocodeRequest = new ReverseGeocodeRequest();

            // Set the credentials using a valid Bing Maps key – Replace the text in green with your credentials 
            reverseGeocodeRequest.Credentials = new GeocodeService.Credentials();
            reverseGeocodeRequest.Credentials.ApplicationId = "IVMrdHQvM4jM61vTKgKj~TXSvY7rIpcx2F_BN8ng4SQ~AjX0mRb5gJOYJwB5sPCX2QD4t5bgLR9gHGxJvWGNV93rTgrYThbJM3N1w73r8v3u";

            // Set the point to use to find a matching address 
            GeocodeService.Location point1 = new GeocodeService.Location();
            point1.Latitude = loc.Latitude;
            point1.Longitude = loc.Longitude;
            reverseGeocodeRequest.Location = point1;

            // Make the reverse geocode request 
            GeocodeServiceClient geocodeService = new GeocodeServiceClient(GeocodeServiceClient.EndpointConfiguration.BasicHttpBinding_IGeocodeService);
            var geocodeResponse = await geocodeService.ReverseGeocodeAsync(reverseGeocodeRequest);
            if (geocodeResponse.Results.Count > 0)
            {
                temAdrress = geocodeResponse.Results[0].DisplayName;
                pop_search.IsOpen = true;
                txtBlk_popup.Text = "أنا" + "\n" + temAdrress;
            }
        }

        void start_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            pop_search.IsOpen = true;
            txtBlk_popup.Text = "دا مكاني";
        }

        void end_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            pop_search.IsOpen = true;
            txtBlk_popup.Text = _officeName;
        }
        private async Task<Response> GetResponse(Uri uri)
        {
            System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
            var response = await client.GetAsync(uri);

            using (var stream = await response.Content.ReadAsStreamAsync())
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Response));
                return ser.ReadObject(stream) as Response;
            }
        }
        private async void ShowMessage(string message)
        {
            MessageDialog dialog = new MessageDialog(message);
            await dialog.ShowAsync();
        }

        private void btn_ok_Click(object sender, RoutedEventArgs e)
        {
            pop_search.IsOpen = false;
        }
        public static double GetDistanceBetweenPoints(double lat1, double long1, double lat2, double long2)
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
            return distance;
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

        private void AppBarButton_getNearest(object sender, RoutedEventArgs e)
        {
            ClearMap();
            routeLayer = new MapShapeLayer();
            myMap.ShapeLayers.Add(routeLayer);
            getTheNear();
        }

        private async void GetMyLocation()
        {
            // Get my current  location on the map 
            Geolocator myGeolocator = new Geolocator();
            Geoposition myGeoposition = await myGeolocator.GetGeopositionAsync();
            Bing.Maps.Location mylocation = new Bing.Maps.Location(myGeoposition.Coordinate.Latitude, myGeoposition.Coordinate.Longitude);
            // Make my current location the center of the Map.
            this.myMap.Center = mylocation;
            this.myMap.ZoomLevel = 15;
            //Create a small shape to mark the current location.
            Pushpin pushpin = new Pushpin();
            pushpin.Text = "M";
            MapLayer.SetPosition(pushpin, mylocation);
            myMap.Children.Add(pushpin);


        }

        List<double> containerList;

        //string _officeName; double _distance;
        public static double t1, t2;
        public async void getTheNear()
        {
            try
            {
                // Get my current  location on the map 
                Geolocator myGeolocator = new Geolocator();
                Geoposition myGeoposition = await myGeolocator.GetGeopositionAsync();
                Code.DataModel DMobject = new Code.DataModel();
                Code.PoliceOfficeModel POMobject = new Code.PoliceOfficeModel();
                Code.FillModel FMobject = new Code.FillModel();
                FMobject.FillingModel();
                containerList = new List<double>();
                List<Code.PoliceOfficeModel> TempList = new List<Code.PoliceOfficeModel>();

                for (int i = 0; i < (FMobject.GovernrateList.Count - 1); i++)
                {
                    for (int j = 0; j < (FMobject.GovernrateList[i].POfficeList.Count - 1); j++)
                    {
                        //containerList.Add(GetDistanceBetweenPoints(30.077014, 31.019178,
                        //    FMobject.GovernrateList[i].POfficeList[j].Latitude, FMobject.GovernrateList[i].POfficeList[j].Longitude));

                        //containerList.Add(GetDistanceBetweenPoints(myGeoposition.Coordinate.Latitude, myGeoposition.Coordinate.Longitude,
                        //    FMobject.GovernrateList[i].POfficeList[j].Latitude, FMobject.GovernrateList[i].POfficeList[j].Longitude));


                        containerList.Add(CalculateDistance(myGeoposition.Coordinate.Latitude, myGeoposition.Coordinate.Longitude,
                           FMobject.GovernrateList[i].POfficeList[j].Latitude, FMobject.GovernrateList[i].POfficeList[j].Longitude));




                        TempList.Add(new Code.PoliceOfficeModel()
                        {
                            Latitude = FMobject.GovernrateList[i].POfficeList[j].Latitude,
                            Longitude = FMobject.GovernrateList[i].POfficeList[j].Longitude,
                            OfficeName = FMobject.GovernrateList[i].POfficeList[j].OfficeName
                        });
                    }
                }


                //#region Searching Algorithm
                myLat = myGeoposition.Coordinate.Latitude;
                myLong = myGeoposition.Coordinate.Longitude;

                double tttt = containerList.Min();
                int kk = 0;
                for (; ; kk++)
                {
                    if (tttt == containerList[kk])
                    {
                        break;
                    }
                }

                double _long = 0, _lat = 0;
                double min = containerList[0];
                double last = containerList[containerList.Count - 1];


                _lat = TempList[kk].Latitude;
                _long = TempList[kk].Longitude;
                _officeName = TempList[kk].OfficeName;

                _distance = tttt;


                t1 = _lat;
                t2 = _long;
                DrawRoute(t1, t2);


            }

            catch { }
        }

        private async void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckInternetConnectivity())
                return;
            if (ReadAppRatingSetting())
                return;
            MessageDialog msg;
            bool retry = false;
            msg = new MessageDialog("هل يمكنك تقييم التطبيق لمساعدتنا في جعله أفضل؟");
            msg.Commands.Add(new UICommand("تقييم", new UICommandInvokedHandler(this.OpenStoreRating)));
            msg.Commands.Add(new UICommand("ليس الآن", (uiCommand) => { }));
            msg.Commands.Add(new UICommand("لا شكرا", new UICommandInvokedHandler(this.IgnoreRating)));
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
            request.Data.Properties.Title = "أقرب بنزينة لو سمحت";
            request.Data.SetText(" هذا التطبيق يساعدك على الوصول لأقرب بنزينة منك بسرعة و سهولة عن طريق تحديد مكانك و اماكن البنزينات المحيطة بك و رسم الطريق لأقرب واحدة. كما يساعدك على معرفة الخدمات التى تقدمها البنزينة. و كمان لوعايز بنزينة معينة هيعرفك توصلها ازاى على الخريطة و يعرفك عنوانه بالكامل " + System.Environment.NewLine + (new Uri("ms-windows-store:PDP?PFN=" + name)).ToString());
        }

    }
}
