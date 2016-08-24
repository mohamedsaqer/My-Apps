using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace el_3abkry
{
    public class DataModel
    {
        public int Id_Governrate { get; set; }
        public string GovernrateName { get; set; }
        public ObservableCollection<PoliceOfficeModel> POfficeList { get; set; }
        public string GovernrateImg { get; set; }
    }
    public class FillModel
    {

        public ObservableCollection<DataModel> GovernrateList { get { return _governrateList; } }
        private ObservableCollection<DataModel> _governrateList = new ObservableCollection<DataModel>();

        private ObservableCollection<PoliceOfficeModel> CairoPO = new ObservableCollection<PoliceOfficeModel>();
        public void FillingModel()
        {

            #region cairo 1
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 0, OfficeName = "Java", book = "http://1drv.ms/1DcZMfA", historylink = "https://en.wikipedia.org/wiki/Java_(programming_language)", totorial = "http://bit.ly/1OzTMzL", ide = "https://netbeans.org/downloads/index.html", test= "http://el3abkry.azurewebsites.net/" });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 1, OfficeName = "C / C++", book = "http://1drv.ms/1DcZIN3", historylink = "https://en.wikipedia.org/wiki/C%2B%2B", totorial = "http://bit.ly/1lzJ8i5", ide = "http://www.codeblocks.org/downloads/26", test = "http://el3abkry.azurewebsites.net/" });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 2, OfficeName = "Python", book = "http://1drv.ms/1Dd0eKZ", historylink = "https://en.wikipedia.org/wiki/Python_(programming_language)", totorial = "http://bit.ly/1Vbvqy9", ide = "https://www.python.org/downloads/", test = "http://el3abkry.azurewebsites.net/" });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 3, OfficeName = "C#", book = "http://1drv.ms/1DcZEN8", historylink = "https://en.wikipedia.org/wiki/C_Sharp_(programming_language)", totorial = "http://bit.ly/1RCee6U", ide = "https://www.visualstudio.com/en-us/downloads/download-visual-studio-vs.aspx", test = "http://el3abkry.azurewebsites.net/" });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 4, OfficeName = "Java Script", book = "http://1drv.ms/1DcZXHP", historylink = "https://en.wikipedia.org/wiki/JavaScript", totorial = "http://bit.ly/20hhYMC", ide = "http://www.eclipse.org/downloads/packages/eclipse-ide-javascript-web-developers/indigosr2", test = "http://el3abkry.azurewebsites.net/" });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 5, OfficeName = "PHP", book = "http://1drv.ms/1Dd0ae7", historylink = "https://en.wikipedia.org/wiki/PHP", totorial = "http://bit.ly/1WydbEd", ide = "https://netbeans.org/downloads/index.html", test = "http://el3abkry.azurewebsites.net/" });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 6, OfficeName = "SQL", book = "http://1drv.ms/1Dd0mdl", historylink = "https://en.wikipedia.org/wiki/SQL", totorial = "http://bit.ly/1Qh9wZ9", ide = "https://www.visualstudio.com/en-us/downloads/download-visual-studio-vs.aspx", test = "http://el3abkry.azurewebsites.net/" });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 7, OfficeName = "Ruby", book = "http://1drv.ms/1Dd0jya", historylink = "https://en.wikipedia.org/wiki/Ruby_(programming_language)", totorial = "http://bit.ly/1VbugTm", ide = "https://netbeans.org/downloads/index.html", test = "http://el3abkry.azurewebsites.net/" });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 8, OfficeName = "Objective-C / Swift ", book = "http://1drv.ms/1Dd01r5", historylink = "https://en.wikipedia.org/wiki/Objective-C", totorial = "http://bit.ly/1Nn9vhK", ide = "https://developer.apple.com/xcode/", test = "http://el3abkry.azurewebsites.net/" });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 9, OfficeName = "HTML", book = "http://1drv.ms/1DcZMMA", historylink = "https://en.wikipedia.org/wiki/HTML", totorial = "http://bit.ly/1S7fYUj", ide = "https://notepad-plus-plus.org/download/v6.8.8.html", test = "http://el3abkry.azurewebsites.net/" });
            _governrateList.Add(new DataModel() { Id_Governrate = 0, GovernrateName = "القاهرة الكبرى", POfficeList = CairoPO });
            #endregion
        }
    }
    public class PoliceOfficeModel
    {
        public int Id_Office { get; set; }
        public string OfficeName { get; set; }
        public string book { get; set; }
        public string historylink { get; set; }
        public string ide { get; set; }
        public string totorial { get; set; }
        public string test { get; set; }
    }
}
