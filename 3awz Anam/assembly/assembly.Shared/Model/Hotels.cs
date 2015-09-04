using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace assembly.Model
{
    // the property you're going to use into your code 
   public class hotel
    {
        public int id { get; set; }
        public string Name { get; set; }// prop tap  tap 
        public string Photo { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Link { get; set; }
        public string BookingLink { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        private ObservableCollection<string> photosList=new ObservableCollection<string>();

        public ObservableCollection<string> PhotosList
        {
            get { return photosList; }
            set { photosList = value; }
        }

    }
    // create another class to put your list into it
    public class Data
    {
        // create a list of < your main class>
        public List<hotel> mylist
        {
            get
            {
                return showlist;
            }

        }
        // make a list to return its data into your last list to prevented from losing data 
        private List<hotel> showlist = new List<hotel>();

        // create a method to use it into the cs page to got your data 
        public void Data_in()
        {ObservableCollection<string> fourseasonphotos = new ObservableCollection<string>();
            fourseasonphotos.Add("Assets/cairo/1.jpeg");
            fourseasonphotos.Add("Assets/cairo/2.jpeg");
            fourseasonphotos.Add("Assets/cairo/3.jpeg");
            fourseasonphotos.Add("Assets/cairo/4.jpeg");
            fourseasonphotos.Add("Assets/cairo/5.jpeg");
            fourseasonphotos.Add("Assets/cairo/6.jpeg");
            fourseasonphotos.Add("Assets/cairo/7.jpeg");
            fourseasonphotos.Add("Assets/cairo/8.jpeg");
            fourseasonphotos.Add("Assets/cairo/9.jpeg");
            fourseasonphotos.Add("Assets/cairo/10.jpeg");
            fourseasonphotos.Add("Assets/cairo/11.jpeg");
            fourseasonphotos.Add("Assets/cairo/12.jpeg");
            fourseasonphotos.Add("Assets/cairo/13.jpeg");
            fourseasonphotos.Add("Assets/cairo/14.jpeg");

            showlist.Add(new hotel()
            {
                id=0,

                Name = "FOUR SEASONS HOTEL CAIRO",
                Photo = "Assets/1.jpeg",
                Address = "35 Giza Street, Cairo, Egypt",
                Phone = "20(2)3567-1600",
                Link = "http://www.fourseasons.com/cairofr/",
                BookingLink = "https://secure.fourseasons.com/content/fourseasons/en/booking/your_trip_b.html",
                PhotosList=fourseasonphotos ,
                Latitude = 30.023824,
                Longitude = 31.217716
                
            });
            ObservableCollection<string> sharm = new ObservableCollection<string>();
            sharm.Add("Assets/sharm/1.jpg");
            sharm.Add("Assets/sharm/2.jpg");
            sharm.Add("Assets/sharm/3.jpg");
            sharm.Add("Assets/sharm/4.jpg");
            sharm.Add("Assets/sharm/5.jpg");
            sharm.Add("Assets/sharm/6.jpg");
            sharm.Add("Assets/sharm/7.jpg");
            sharm.Add("Assets/sharm/8.jpg");
            sharm.Add("Assets/sharm/9.jpg");
            sharm.Add("Assets/sharm/10.jpg");
            sharm.Add("Assets/sharm/11.jpg");
            sharm.Add("Assets/sharm/12.jpg");
            sharm.Add("Assets/sharm/13.jpg");
            sharm.Add("Assets/sharm/14.jpg");
            sharm.Add("Assets/sharm/15.jpg");
            sharm.Add("Assets/sharm/16.jpg");
            
            showlist.Add(new hotel()
            {
                id=1,

                Name = "ROYAL SAVOY SHARM EL SHEIKH",
                Photo = "Assets/2.jpg",
                Address = "169, SOHO Square Sharm El Sheikh, South Sinai, Egypt",
                Phone = "(+ 2069) 3 602 500",
                Link = "http://www.savoy-sharm.com/royal-savoy/",
                BookingLink = "http://www.savoy-sharm.com/early-bird.php",
                PhotosList = sharm,
                Latitude = 27.955377,
                Longitude = 34.389623


            });
            ObservableCollection<string> luxor = new ObservableCollection<string>();
            luxor.Add("Assets/luxor/1.jpg"); luxor.Add("Assets/luxor/2.jpg");
            luxor.Add("Assets/luxor/3.jpg"); luxor.Add("Assets/luxor/4.jpg");
            luxor.Add("Assets/luxor/5.jpg"); luxor.Add("Assets/luxor/6.jpg");
            luxor.Add("Assets/luxor/7.jpg"); luxor.Add("Assets/luxor/8.jpg");
            luxor.Add("Assets/luxor/9.jpg"); luxor.Add("Assets/luxor/10.jpg");
            luxor.Add("Assets/luxor/11.jpg"); luxor.Add("Assets/luxor/12.jpg");
            luxor.Add("Assets/luxor/13.jpg"); luxor.Add("Assets/luxor/14.jpg");
            luxor.Add("Assets/luxor/15.jpg"); luxor.Add("Assets/luxor/16.jpg");
            luxor.Add("Assets/luxor/17.jpg"); luxor.Add("Assets/luxor/18.jpg");
            luxor.Add("Assets/luxor/19.jpg"); luxor.Add("Assets/luxor/20.jpg");
            luxor.Add("Assets/luxor/21.jpg"); luxor.Add("Assets/luxor/22.jpg");
            luxor.Add("Assets/luxor/23.jpg"); luxor.Add("Assets/luxor/24.jpg");
            luxor.Add("Assets/luxor/25.jpg");

            showlist.Add(new hotel()
            {
                id = 2,

                Name = "SHERATON LUXOR RESORT",
                Photo = "Assets/3.jpg",
                Address = "2 Fathi AL-AWamrey Street, LUXOR, EGYPT",
                Phone = "20 (95) 227-4544",
                Link = "http://www.sheratonluxor.com/",
                BookingLink = "http://www.sheratonluxor.com/contact",
                PhotosList = luxor,
                Latitude = 25.687243,
                Longitude = 32.639636


            });
            ObservableCollection<string> alex = new ObservableCollection<string>();
            alex.Add("Assets/alex/1.jpeg");
            alex.Add("Assets/alex/2.jpeg");
            alex.Add("Assets/alex/3.jpeg");
            alex.Add("Assets/alex/4.jpeg");
            alex.Add("Assets/alex/5.jpeg");
            alex.Add("Assets/alex/6.jpeg");
            alex.Add("Assets/alex/7.jpeg");
            alex.Add("Assets/alex/8.jpeg");
            alex.Add("Assets/alex/9.jpeg");
            alex.Add("Assets/alex/10.jpeg");
            alex.Add("Assets/alex/11.jpeg");
            alex.Add("Assets/alex/12.jpeg");
            alex.Add("Assets/alex/13.jpeg");
            alex.Add("Assets/alex/14.jpeg");
            alex.Add("Assets/alex/15.jpeg");
            alex.Add("Assets/alex/16.jpeg");
            alex.Add("Assets/alex/17.jpeg"); 

            showlist.Add(new hotel()
            {
                id = 3,

                Name = "FOUR SEASONS HOTEL ALEX AT SANSTEFANO",
                Photo = "Assets/4.jpeg",
                Address = "399 El-gaish Street, Alex, Egypt",
                Phone = "20(3)581-8000",
                Link = "http://www.fourseasons.com/ar/alexandria/",
                BookingLink = "https://secure.fourseasons.com/content/fourseasons/ar/booking/your_trip_b.html",
                PhotosList=alex,
                Latitude = 31.246071,
                Longitude = 29.965827

            });
                
                
                
        }

    }
}