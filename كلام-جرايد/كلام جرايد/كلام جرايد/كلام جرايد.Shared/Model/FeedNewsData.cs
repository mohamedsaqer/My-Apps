using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Syndication;

namespace كلام_جرايد.Model
{
   public class FeedNewsData
    {
        public string CatgoryTitle { get; set; }
        public string CategoryDescription { get; set; }
        public DateTime CategoryPubDate { get; set; }

        private List<NewsItem> _NewsItems = new List<NewsItem>();
        public List<NewsItem> NewsItems
        {
            get
            {
                return this._NewsItems;
            }
        }
    }
   public class NewsItem
   {
       public string NewsTitle { get; set; }
       public string NewsCategory { get; set; }
       public string NewsAuthour { get; set; }
       public string NewsContent { get; set; }
       public DateTime NewsPubDate { get; set; }
       public Uri NewsLink { get; set; }

   }
   public class GridViewCategory
   {
       public string NameGrid { get; set; }
       public NewsItem SelectedNews { get; set; }
   }
   public class AllNewsLoad
   {
       private ObservableCollection<FeedNewsData> _Feeds = new ObservableCollection<FeedNewsData>();
       public ObservableCollection<FeedNewsData> Feeds
       {
           get
           {
               return this._Feeds;
           }
       }


       //private ObservableCollection<FeedNewsData> _Feeds1 = new ObservableCollection<FeedNewsData>();
       //public ObservableCollection<FeedNewsData> Feeds1
       //{
       //    get
       //    {
       //        return this._Feeds1;
       //    }
       //}

       //private ObservableCollection<FeedNewsData> _Feeds2 = new ObservableCollection<FeedNewsData>();
       //public ObservableCollection<FeedNewsData> Feeds2
       //{
       //    get
       //    {
       //        return this._Feeds2;
       //    }
       //}

       //private ObservableCollection<FeedNewsData> _Feeds3 = new ObservableCollection<FeedNewsData>();
       //public ObservableCollection<FeedNewsData> Feeds3
       //{
       //    get
       //    {
       //        return this._Feeds3;
       //    }
       //}

       //private ObservableCollection<FeedNewsData> _Feeds4 = new ObservableCollection<FeedNewsData>();
       //public ObservableCollection<FeedNewsData> Feeds4
       //{
       //    get
       //    {
       //        return this._Feeds4;
       //    }
       //}

       //private ObservableCollection<FeedNewsData> _Feeds5 = new ObservableCollection<FeedNewsData>();
       //public ObservableCollection<FeedNewsData> Feeds5
       //{
       //    get
       //    {
       //        return this._Feeds5;
       //    }
       //}

       //private ObservableCollection<FeedNewsData> _Feeds6 = new ObservableCollection<FeedNewsData>();
       //public ObservableCollection<FeedNewsData> Feeds6
       //{
       //    get
       //    {
       //        return this._Feeds6;
       //    }
       //}
     
       public async Task GetFeedsAsync()
       {
           List<string> LatestNews = new List<string>();
           LatestNews.Add("http://youm7.com/rss/SectionRss?SectionID=65");
           LatestNews.Add("http://www.elwatannews.com/home/rssfeeds");
           LatestNews.Add("http://www.akhbarelyom.com/rss/list/5576d6a9d4e39af80c00003c/%D9%85%D8%AE%D8%AA%D8%A7%D8%B1%D8%A7%D8%AA");
           LatestNews.Add("http://www.almasryalyoum.com/rss/rssfeeds");

           List<string> SportsList = new List<string>();
           SportsList.Add("http://youm7.com/rss/SectionRss?SectionID=298");
          // SportsList.Add("http://www.elwatannews.com/home/rssfeeds?sectionId=71");
           SportsList.Add("http://www.akhbarelyom.com/rss/list/5576d6a8d4e39af80c000032/%D8%B1%D9%8A%D8%A7%D8%B6%D8%A9");
           SportsList.Add("http://www.almasryalyoum.com/rss/rssfeeds?sectionId=8");

           List<string> ArtsList = new List<string>();
           ArtsList.Add("http://youm7.com/rss/SectionRss?SectionID=48");
           ArtsList.Add("http://www.elwatannews.com/home/rssfeeds?sectionId=60");
           ArtsList.Add("http://www.akhbarelyom.com/rss/list/5576d6a8d4e39af80c000037/%D9%81%D9%86");
           ArtsList.Add("http://www.almasryalyoum.com/rss/RssFeeds?sectionId=10");

           List<string> PoliticsList = new List<string>();
           PoliticsList.Add("http://youm7.com/rss/SectionRss?SectionID=97");
           PoliticsList.Add("http://www.elwatannews.com/home/rssfeeds?sectionId=115");
           PoliticsList.Add("http://www.akhbarelyom.com/rss/list/5576d6a7d4e39af80c000029/%D8%A3%D8%AE%D8%A8%D8%A7%D8%B1-%D9%85%D8%B5%D8%B1");
           PoliticsList.Add("http://www.almasryalyoum.com/rss/rssfeeds?sectionId=3");

           List<string> TechnoList = new List<string>();
           TechnoList.Add("http://youm7.com/rss/SectionRss?SectionID=328");
      //     TechnoList.Add("http://www.elwatannews.com/home/rssfeeds?sectionId=179");
           TechnoList.Add("http://www.akhbarelyom.com/rss/list/5576d6a9d4e39af80c000042/%D8%B9%D9%84%D9%88%D9%85-%D9%88%D8%AA%D9%83%D9%86%D9%88%D9%84%D9%88%D8%AC%D9%8A%D8%A7");
           TechnoList.Add("http://www.almasryalyoum.com/rss/rssfeeds?sectionId=9");

           List<string> WomanList = new List<string>();
           WomanList.Add("http://youm7.com/rss/SectionRss?SectionID=327");
           WomanList.Add("http://www.elwatannews.com/home/rssfeeds?sectionId=51");
           WomanList.Add("http://www.akhbarelyom.com/rss/list/5576d6a8d4e39af80c000034/%D8%A7%D9%84%D9%85%D8%B1%D8%A3%D8%A9-%D9%88%D8%A7%D9%84%D8%B7%D9%81%D9%84");
           WomanList.Add("http://www.almasryalyoum.com/rss/rssfeeds?sectionId=69");

           List<string> EconomyList = new List<string>();
           EconomyList.Add("http://www.youm7.com/rss/SectionRss?SectionID=297");
           EconomyList.Add("http://www.elwatannews.com/home/rssfeeds?sectionId=77");
           EconomyList.Add("http://www.akhbarelyom.com/rss/list/5576d6a7d4e39af80c00002c/%D8%A7%D9%82%D8%AA%D8%B5%D8%A7%D8%AF");
           EconomyList.Add("http://www.almasryalyoum.com/rss/rssfeeds?sectionId=4");

        FeedNewsData LatestNewsFeed= await GetFeedAsync(LatestNews);
        FeedNewsData SportsNewsFeed = await GetFeedAsync(SportsList);
        FeedNewsData ArtsNewsFeed = await GetFeedAsync(ArtsList);
        FeedNewsData PoliticsNewsFeed = await GetFeedAsync(PoliticsList);
        FeedNewsData TechnoNewsFeed = await GetFeedAsync(TechnoList);
        FeedNewsData WomanNewsFeed = await GetFeedAsync(WomanList);
        FeedNewsData EconomyNewsFeed = await GetFeedAsync(EconomyList);
        Feeds.Add(LatestNewsFeed);
        Feeds.Add(SportsNewsFeed);
        Feeds.Add(ArtsNewsFeed);
        Feeds.Add(PoliticsNewsFeed);
        Feeds.Add(TechnoNewsFeed);
        Feeds.Add(WomanNewsFeed);
        Feeds.Add(EconomyNewsFeed);
       }
       private async Task<FeedNewsData> GetFeedAsync(List<string> feedUriString)
        {
            FeedNewsData BlogData = new FeedNewsData();

            foreach (string web in feedUriString)
            {

                Windows.Web.Syndication.SyndicationClient client = new SyndicationClient();
                Uri feedUri = new Uri(web);

                try
                {
                    SyndicationFeed feed = await client.RetrieveFeedAsync(feedUri);

                    // This code is executed after RetrieveFeedAsync returns the SyndicationFeed.
                    // Process the feed and copy the data you want into the FeedData and FeedItem classes.

                    if (feed.Title != null && feed.Title.Text != null)
                    {
                        BlogData.CatgoryTitle = feed.Title.Text;
                    }
                    if (feed.Subtitle != null && feed.Subtitle.Text != null)
                    {
                        BlogData.CategoryDescription = feed.Subtitle.Text;
                    }
                    if (feed.Items != null && feed.Items.Count > 0)
                    {
                        // Use the date of the latest post as the last updated date.
                        BlogData.CategoryPubDate = feed.Items[0].PublishedDate.DateTime;

                        foreach (SyndicationItem item in feed.Items)
                        {
                            NewsItem PostDetails = new NewsItem();
                            if (item.Title != null && item.Title.Text != null)
                            {
                                PostDetails.NewsTitle = item.Title.Text;
                            }
                            //if (item.Categories != null)
                            //{
                            //    PostDetails.PostCategory = item.Categories[0].Term.ToString();
                            //}
                            if (item.PublishedDate != null)
                            {
                                PostDetails.NewsPubDate = item.PublishedDate.DateTime;
                            }
                            if (item.Authors != null && item.Authors.Count > 0)
                            {
                                PostDetails.NewsAuthour = item.Authors[0].Name.ToString();
                            }
                            if (feed.SourceFormat == SyndicationFormat.Rss20)
                            {
                                if (item.Summary != null && item.Summary.Text != null)
                                {
                                    PostDetails.NewsContent = item.Summary.Text;
                                }
                                if (item.Links != null && item.Links.Count > 0)
                                {
                                    PostDetails.NewsLink = item.Links[0].Uri;
                                }
                            }
                            BlogData.NewsItems.Add(PostDetails);
                        }
                    }
                }
                catch (Exception)
                {
                    return null;
                }
            }
            return BlogData;

        }
       
       }

   }

