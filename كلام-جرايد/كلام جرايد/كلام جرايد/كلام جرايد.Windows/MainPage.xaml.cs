using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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
using كلام_جرايد.Model;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace كلام_جرايد
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {




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
            request.Data.Properties.Title = "كلام جرايد";
            request.Data.SetText("يقوم هذا البرنامج بتجميع الأخبار من مصادر متنوعة و تقسيمه حسب نوعه ويقوم بعرض العناوين الأخبار فى الصفحة الرئيسية و يقوم ايضا بعرض الخبر كامل من مصدره" + System.Environment.NewLine + (new Uri("ms-windows-store:PDP?PFN=" + name)).ToString());
        }




        public MainPage()
        {
            this.InitializeComponent();
          
            //LatestGrid=new GridView();
            //SportsGrid = new GridView();
        }
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (((AllNewsLoad)App.Current.Resources["FeedData"]).Feeds.Count == 0)
            {
                allnews.Visibility = Visibility.Collapsed;
              await  Load();
                
            }
        }
        GridView LatestGrid;
        //AllNewsLoad Loaddata = new AllNewsLoad();
        public async Task Load()
        {
          await  ((AllNewsLoad)App.Current.Resources["FeedData"]).GetFeedsAsync();
          stopring.IsActive = false;
          allnews.Visibility = Visibility.Visible;
          //await  Loaddata.GetFeedsAsync();
          //LatestGrid.ItemsSource = Loaddata.Feeds[0].NewsItems;
          //SportsGrid.ItemsSource = Loaddata.Feeds[1].NewsItems;
    
        }

     

        private void LatestNewsGridView_Loaded(object sender, RoutedEventArgs e)
        {
            //LatestGrid = FindChildControl<GridView>(Latest, "LatestNewsGridView") as GridView;
        }
        
        private DependencyObject FindChildControl<T>(DependencyObject control, string ctrlName)
        {
            int childNumber = VisualTreeHelper.GetChildrenCount(control);
            for (int i = 0; i < childNumber; i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(control, i);
                FrameworkElement fe = child as FrameworkElement;
                // Not a framework element or is null
                if (fe == null) return null;

                if (child is T && fe.Name == ctrlName)
                {
                    // Found the control so return
                    return child;
                }
                else
                {
                    // Not found it - search children
                    DependencyObject nextLevel = FindChildControl<T>(child, ctrlName);
                    if (nextLevel != null)
                        return nextLevel;
                }
            }
            return null;

        }
        GridView SportsGrid;
        private void SportsGridView_Loaded(object sender, RoutedEventArgs e)
        {
            //SportsGrid = FindChildControl<GridView>(SportsHub, "SportsGridView") as GridView;

        }

        private void LatestNewsGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            GridViewCategory x = new GridViewCategory();
            x.NameGrid = "اخر الأخبار";
            x.SelectedNews=(NewsItem)e.ClickedItem;
            Frame.Navigate(typeof(NewsPage),x);
        }

        

        private void SportsGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            GridViewCategory x = new GridViewCategory();
            x.NameGrid = "رياضه";
            x.SelectedNews = (NewsItem)e.ClickedItem;
            Frame.Navigate(typeof(NewsPage), x);
        }

        private void LatestButton_Click(object sender, RoutedEventArgs e)
        {
            GridViewCategory x = new GridViewCategory();
            x.NameGrid = "اخر الأخبار";
            Frame.Navigate(typeof(NewsPage),x);
        }

        private void PoliticesButton_Click(object sender, RoutedEventArgs e)
        {
            GridViewCategory x = new GridViewCategory();
            x.NameGrid = "سياسة";
            Frame.Navigate(typeof(NewsPage), x);
        }

        private void SportsButton_Click(object sender, RoutedEventArgs e)
        {
            GridViewCategory x = new GridViewCategory();
            x.NameGrid = "رياضه";
            Frame.Navigate(typeof(NewsPage), x);
        }

        private void ArtsButton_Click(object sender, RoutedEventArgs e)
        {
            GridViewCategory x = new GridViewCategory();
            x.NameGrid = "فن";
            Frame.Navigate(typeof(NewsPage), x);
        }

        private void TechnologyButton_Click(object sender, RoutedEventArgs e)
        {
            GridViewCategory x = new GridViewCategory();
            x.NameGrid = "تكنولوجيا";
            Frame.Navigate(typeof(NewsPage), x);
        }

        private void TechnologyGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            GridViewCategory x = new GridViewCategory();
            x.NameGrid = "تكنولوجيا";
            x.SelectedNews = (NewsItem)e.ClickedItem;
            Frame.Navigate(typeof(NewsPage), x);
        }

        private void ArtsGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            GridViewCategory x = new GridViewCategory();
            x.NameGrid = "فن";
            x.SelectedNews = (NewsItem)e.ClickedItem;
            Frame.Navigate(typeof(NewsPage), x);
        }

        private void WomanButtom_Click(object sender, RoutedEventArgs e)
        {
            GridViewCategory x = new GridViewCategory();
            x.NameGrid = "المرأه";
            Frame.Navigate(typeof(NewsPage), x);
        }

        private void WomanGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            GridViewCategory x = new GridViewCategory();
            x.NameGrid = "المرأه";
            x.SelectedNews = (NewsItem)e.ClickedItem;
            Frame.Navigate(typeof(NewsPage), x);
        }

        private void EconomyGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            GridViewCategory x = new GridViewCategory();
            x.NameGrid = "الإقتصاد";
            x.SelectedNews = (NewsItem)e.ClickedItem;
            Frame.Navigate(typeof(NewsPage), x);
        }

        private void EconomyButton_Click(object sender, RoutedEventArgs e)
        {
            GridViewCategory x = new GridViewCategory();
            x.NameGrid = "الإقتصاد";
            Frame.Navigate(typeof(NewsPage), x);
        }

        private void PoliticsGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            GridViewCategory x = new GridViewCategory();
            x.NameGrid = "سياسة";
            x.SelectedNews = (NewsItem)e.ClickedItem;
            Frame.Navigate(typeof(NewsPage), x);
        }
       
    }

}
