using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
        public MainPage()
        {
            this.InitializeComponent();
       //     s.NavigationCacheMode = NavigationCacheMode.Required;
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (((AllNewsLoad)App.Current.Resources["FeedData"]).Feeds.Count == 0)
            {
                allnews.Visibility = Visibility.Collapsed;
                await Load();

            }
        }
        GridView LatestGrid;
        public async Task Load()
        {
            await ((AllNewsLoad)App.Current.Resources["FeedData"]).GetFeedsAsync();
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
            x.SelectedNews = (NewsItem)e.ClickedItem;
            Frame.Navigate(typeof(NewsWebView), (NewsItem)e.ClickedItem);
        }



        private void SportsGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            GridViewCategory x = new GridViewCategory();
            x.NameGrid = "رياضه";
            x.SelectedNews = (NewsItem)e.ClickedItem;
            Frame.Navigate(typeof(NewsWebView), (NewsItem)e.ClickedItem);
        }

        private void LatestButton_Click(object sender, RoutedEventArgs e)
        {
            GridViewCategory x = new GridViewCategory();
            x.NameGrid = "اخر الأخبار";
            Frame.Navigate(typeof(NewsPage), x);
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
            Frame.Navigate(typeof(NewsWebView), (NewsItem)e.ClickedItem);
        }

        private void ArtsGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            GridViewCategory x = new GridViewCategory();
            x.NameGrid = "فن";
            x.SelectedNews = (NewsItem)e.ClickedItem;
            Frame.Navigate(typeof(NewsWebView), (NewsItem)e.ClickedItem);
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
            Frame.Navigate(typeof(NewsWebView), (NewsItem)e.ClickedItem);
        }

        private void EconomyGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            GridViewCategory x = new GridViewCategory();
            x.NameGrid = "الإقتصاد";
            x.SelectedNews = (NewsItem)e.ClickedItem;
            Frame.Navigate(typeof(NewsWebView), (NewsItem)e.ClickedItem);
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
            Frame.Navigate(typeof(NewsWebView), (NewsItem)e.ClickedItem);
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        //protected override void OnNavigatedTo(NavigationEventArgs e)
        //{
        //    // TODO: Prepare page for display here.

        //    // TODO: If your application contains multiple pages, ensure that you are
        //    // handling the hardware Back button by registering for the
        //    // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
        //    // If you are using the NavigationHelper provided by some templates,
        //    // this event is handled for you.
        //}

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(about_page));
        }
    }
}
