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
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 0, OfficeName = "Java", book = "http://1drv.ms/1DcZMfA", historylink = "https://en.wikipedia.org/wiki/Java_(programming_language)", totorial = "https://goo.gl/4RsJBJ", ide = "http://download.netbeans.org/netbeans/8.0.2/final/bundles/netbeans-8.0.2-windows.exe" });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 1, OfficeName = "C / C++", book = "http://1drv.ms/1DcZIN3", historylink = "https://en.wikipedia.org/wiki/C%2B%2B", totorial = "https://goo.gl/b1i8UR", ide = "http://garr.dl.sourceforge.net/project/codeblocks/Binaries/13.12/Windows/codeblocks-13.12mingw-setup.exe" });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 2, OfficeName = "Python", book = "http://1drv.ms/1Dd0eKZ", historylink = "https://en.wikipedia.org/wiki/Python_(programming_language)", totorial = "https://goo.gl/0xOHe8", ide = "https://www.python.org/ftp/python/3.4.3/python-3.4.3.msi" });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 3, OfficeName = "C#", book = "http://1drv.ms/1DcZEN8", historylink = "https://en.wikipedia.org/wiki/C_Sharp_(programming_language)", totorial = "http://goo.gl/Voxh7A", ide = "http://download.microsoft.com/download/0/B/C/0BC321A4-013F-479C-84E6-4A2F90B11269/vs_community.exe" });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 4, OfficeName = "Java Script", book = "http://1drv.ms/1DcZXHP", historylink = "https://en.wikipedia.org/wiki/JavaScript", totorial = "https://goo.gl/MRUpPR", ide = "https://ccmdls.adobe.com/AdobeProducts/DRWV/16/win64/AAMmetadataLS20/CreativeCloudSet-Up.exe" });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 5, OfficeName = "PHP", book = "http://1drv.ms/1Dd0ae7", historylink = "https://en.wikipedia.org/wiki/PHP", totorial = "https://goo.gl/p64oLY", ide = "http://mirror.ufs.ac.za/eclipse/technology/epp/downloads/release/mars/R/eclipse-php-mars-R-win32.zip" });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 6, OfficeName = "SQL", book = "http://1drv.ms/1Dd0mdl", historylink = "https://en.wikipedia.org/wiki/SQL", totorial = "https://goo.gl/QdJ1fv", ide = "http://download.microsoft.com/download/0/B/C/0BC321A4-013F-479C-84E6-4A2F90B11269/vs_community.exe" });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 7, OfficeName = "Ruby", book = "http://1drv.ms/1Dd0jya", historylink = "https://en.wikipedia.org/wiki/Ruby_(programming_language)", totorial = "https://goo.gl/mdFVhr", ide = "http://download.netbeans.org/netbeans/6.9.1/final/bundles/netbeans-6.9.1-ml-ruby-windows.exe" });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 8, OfficeName = "Objective-C / Swift ", book = "http://1drv.ms/1Dd01r5", historylink = "https://en.wikipedia.org/wiki/Objective-C", totorial = "https://goo.gl/at9ejL", ide = "http://adcdownload.apple.com/Developer_Tools/Xcode_7_beta_4/Xcode_7_beta_4.dmg" });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 9, OfficeName = "HTML", book = "http://1drv.ms/1DcZMMA", historylink = "https://en.wikipedia.org/wiki/HTML", totorial = "https://goo.gl/P0Y9wF", ide = "https://notepad-plus-plus.org/repository/6.x/6.8/npp.6.8.Installer.exe" });
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
    }
}
