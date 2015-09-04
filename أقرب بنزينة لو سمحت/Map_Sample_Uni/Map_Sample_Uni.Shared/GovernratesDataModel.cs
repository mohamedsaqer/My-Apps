using Map_Sample_Uni.Code;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Map_Sample_Uni
{
    public class GovernratesDataModel
    {
        public int Id_governrate { get; set; }
        public string GovernrateName { get; set; }
        public ObservableCollection<LocationsDataModel> LocationList { get; set; }

    }
    public class LocationsDataModel
    {
        public int Id_location { get; set; }
        public string PlaceName { get; set; }
        public string notes { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
    }
    public class FillingData
    {
        public ObservableCollection<GovernratesDataModel> PublicGovernrateList { get { return _myGovernrateList; } }
        private ObservableCollection<GovernratesDataModel> _myGovernrateList = new ObservableCollection<GovernratesDataModel>();
        private ObservableCollection<LocationsDataModel> _cairoList = new ObservableCollection<LocationsDataModel>();
        private ObservableCollection<LocationsDataModel> _Alx = new ObservableCollection<LocationsDataModel>();


        public void FillGovernrateData()
        {
            //	02-25787120
            #region CAiro
            _cairoList.Add(new LocationsDataModel { Id_location = 0, PlaceName = "موبيل البطل احمد عبدالعزيز ", Latitude = "30.051598", Longitude = "31.208190", notes = "on the Run" });
            _cairoList.Add(new LocationsDataModel { Id_location = 1, PlaceName = "التعاون محى الدين ابو العز", Latitude = "30.048910", Longitude = "31.198309", notes = "اصلاح اطارات" });
            _cairoList.Add(new LocationsDataModel { Id_location = 2, PlaceName = " موبيل أطلس ", Latitude = "30.057602", Longitude = "31.206216", notes = "on the Run" });
            _cairoList.Add(new LocationsDataModel { Id_location = 3, PlaceName = "التعاون احمد عرابى", Latitude = "30.061725", Longitude = "31.207133", notes = " Car Wash " });
            _cairoList.Add(new LocationsDataModel { Id_location = 4, PlaceName = "غازتك العجوزة", Latitude = "30.061163", Longitude = "31.211529", notes = " " });
            _cairoList.Add(new LocationsDataModel { Id_location = 5, PlaceName = "التعاون العجوزة", Latitude = "30.061179", Longitude = "31.211395", notes = " " });
            _cairoList.Add(new LocationsDataModel { Id_location = 6, PlaceName = "موبيل مصدق", Latitude = "30.040523", Longitude = "31.210690", notes = " " });
            _cairoList.Add(new LocationsDataModel { Id_location = 7, PlaceName = "التعاون الدقى", Latitude = "30.035796", Longitude = "31.211494", notes = " " });
            _cairoList.Add(new LocationsDataModel { Id_location = 8, PlaceName = "مصر للبترول الدقى", Latitude = "30.040221", Longitude = "31.218838", notes = " " });
            _cairoList.Add(new LocationsDataModel { Id_location = 9, PlaceName = "موبيل امين الرافعى", Latitude = "30.035266", Longitude = "31.217811", notes = " " });
            _cairoList.Add(new LocationsDataModel { Id_location = 10, PlaceName = "التعاون ش مراد ", Latitude = "30.017390", Longitude = "31.213817", notes = " " });
            _cairoList.Add(new LocationsDataModel { Id_location = 11, PlaceName = "موبيل ربيع الجيزى ", Latitude = "30.014619", Longitude = "31.209847", notes = " " });
            _cairoList.Add(new LocationsDataModel { Id_location = 12, PlaceName = "موبيل ش السودان ", Latitude = "30.064053", Longitude = "31.190208", notes = " " });
            _cairoList.Add(new LocationsDataModel { Id_location = 13, PlaceName = "موبيل امبابة ", Latitude = "30.071019", Longitude = "31.199878", notes = " " });
            _cairoList.Add(new LocationsDataModel { Id_location = 14, PlaceName = "كالتكس فيصل ", Latitude = "30.000056", Longitude = "31.164749", notes = " " });
            _cairoList.Add(new LocationsDataModel { Id_location = 15, PlaceName = "كالتكس الهرم ", Latitude = "29.991570", Longitude = "31.153532", notes = " " });
            _cairoList.Add(new LocationsDataModel { Id_location = 16, PlaceName = "الهرم ExxonMobil ", Latitude = "29.998174", Longitude = "31.172554", notes = " " });
            _cairoList.Add(new LocationsDataModel { Id_location = 17, PlaceName = "الهرم total ", Latitude = "30.005955", Longitude = "31.191826", notes = " " });
            _cairoList.Add(new LocationsDataModel { Id_location = 18, PlaceName = "العمرانية total ", Latitude = "30.008404", Longitude = "31.202308", notes = " " });
            _cairoList.Add(new LocationsDataModel { Id_location = 19, PlaceName = "التعاون فيصل ", Latitude = "30.000461", Longitude = "31.163929", notes = " " });
            _cairoList.Add(new LocationsDataModel { Id_location = 20, PlaceName = "المريوطية total ", Latitude = "30.001775", Longitude = "31.139913", notes = " " });
            _cairoList.Add(new LocationsDataModel { Id_location = 21, PlaceName = "موبيل فيصل ", Latitude = "29.991410", Longitude = "31.140020", notes = " " });
            _cairoList.Add(new LocationsDataModel { Id_location = 22, PlaceName = "شيل فيصل ", Latitude = "29.991025", Longitude = "31.138137", notes = " " });
            _cairoList.Add(new LocationsDataModel { Id_location = 23, PlaceName = "فيصل Esso ", Latitude = "30.030520", Longitude = "31.182280", notes = " " });
            _cairoList.Add(new LocationsDataModel { Id_location = 24, PlaceName = "غازتك ش العشرين ", Latitude = "30.018321", Longitude = "31.184648", notes = " " });
            _cairoList.Add(new LocationsDataModel { Id_location = 25, PlaceName = "كالتكس ش العشرين ", Latitude = "30.018202", Longitude = "31.184721", notes = " " });
            _cairoList.Add(new LocationsDataModel { Id_location = 26, PlaceName = "موبيل ش شهاب ", Latitude = "30.054875", Longitude = "31.195410", notes = " " });
            _cairoList.Add(new LocationsDataModel { Id_location = 27, PlaceName = "موبيل ش المحروقى ", Latitude = "30.058906", Longitude = "31.208178", notes = " " });
            _cairoList.Add(new LocationsDataModel { Id_location = 28, PlaceName = "موبيل ابوالفدا", Latitude = "30.061153", Longitude = "31.219765", notes = " " });
            _cairoList.Add(new LocationsDataModel { Id_location = 29, PlaceName = "امارات مصر اسكنراية الصحرواى ", Latitude = "30.061190", Longitude = "31.029328", notes = " " });
            _cairoList.Add(new LocationsDataModel { Id_location = 30, PlaceName = "موبيل الصحرواى", Latitude = "30.063641", Longitude = "31.025466", notes = " " });
            _cairoList.Add(new LocationsDataModel { Id_location = 31, PlaceName = "الشيخ زايد total ", Latitude = "30.017073", Longitude = "30.97541", notes = " " });
            _cairoList.Add(new LocationsDataModel { Id_location = 32, PlaceName = "موبيل مول العرب ", Latitude = "30.006946", Longitude = "30.979718", notes = " " });
            _cairoList.Add(new LocationsDataModel { Id_location = 33, PlaceName = "موبيل جامعة النيل ", Latitude = "30.013524", Longitude = "30.997056", notes = " " });
            _cairoList.Add(new LocationsDataModel { Id_location = 34, PlaceName = "كالتكس اكتوبر ", Latitude = "29.995940", Longitude = "30.961342", notes = " مينى مترو - برجر كينج" });
            _cairoList.Add(new LocationsDataModel { Id_location = 35, PlaceName = "موبيل اكتوبر", Latitude = "29.974959", Longitude = "30.956635", notes = " " });
            _cairoList.Add(new LocationsDataModel { Id_location = 36, PlaceName = "موبيل ط الواحات ", Latitude = "29.963369", Longitude = "30.969123", notes = " " });
            _cairoList.Add(new LocationsDataModel { Id_location = 37, PlaceName = "كالتكس الحصرى ", Latitude = "29.971883", Longitude = "30.944393", notes = " " });
            _cairoList.Add(new LocationsDataModel { Id_location = 38, PlaceName = "اكتوبر total ", Latitude = "29.950783", Longitude = "30.906842", notes = " " });
            _cairoList.Add(new LocationsDataModel { Id_location = 39, PlaceName = "التعاون م الجيزة ", Latitude = "29.961398", Longitude = "30.930306", notes = " " });
            _cairoList.Add(new LocationsDataModel { Id_location = 40, PlaceName = " ط الواحات total ", Latitude = "29.974122", Longitude = "30.989980", notes = " " });
            _cairoList.Add(new LocationsDataModel { Id_location = 41, PlaceName = "الوطنية ط الواحات ", Latitude = "29.961686", Longitude = "31.041071", notes = " " });
            _cairoList.Add(new LocationsDataModel { Id_location = 42, PlaceName = "موبيل ط الواحات ", Latitude = "29.956992", Longitude = "31.057615", notes = " " });
            _cairoList.Add(new LocationsDataModel { Id_location = 43, PlaceName = "الوطنية ط الواحات  ", Latitude = "29.958675", Longitude = "31.063719", notes = " " });
            _cairoList.Add(new LocationsDataModel { Id_location = 44, PlaceName = "موبيل ناهيا  ", Latitude = "30.041972", Longitude = "31.167971", notes = " " });
            _cairoList.Add(new LocationsDataModel { Id_location = 45, PlaceName = "الوطنية ش ناهيا  ", Latitude = "30.044517", Longitude = "31.179112", notes = " " });
            _cairoList.Add(new LocationsDataModel { Id_location = 46, PlaceName = "التعاون سكة الحاج على", Latitude = "30.044438", Longitude = "31.173632", notes = " " });
            _cairoList.Add(new LocationsDataModel { Id_location = 47, PlaceName = "موبيل ش شهاب ", Latitude = "30.055167", Longitude = "31.194587", notes = " " });
            _cairoList.Add(new LocationsDataModel { Id_location = 48, PlaceName = "كالتكس الطريق الدائرى ", Latitude = "30.139766", Longitude = "31.204994", notes = " " });
            _cairoList.Add(new LocationsDataModel { Id_location = 49, PlaceName = "كالتكس القناطر ", Latitude = "30.147323", Longitude = "31.216603", notes = " " });
            _cairoList.Add(new LocationsDataModel { Id_location = 50, PlaceName = "التعاون قسم شبرا ", Latitude = "30.153214", Longitude = "31.278953", notes = " " });
            _cairoList.Add(new LocationsDataModel { Id_location = 51, PlaceName = "موبيل الطريق الدائرى ", Latitude = "30.162171", Longitude = "31.288625", notes = " " });
            _cairoList.Add(new LocationsDataModel { Id_location = 52, PlaceName = "امارات مصر الخانكة ", Latitude = "30.163354", Longitude = "31.34973", notes = " " });
            _cairoList.Add(new LocationsDataModel { Id_location = 53, PlaceName = "موبيل جسر السويس ", Latitude = "30.147151", Longitude = "31.420617", notes = " " });
            _cairoList.Add(new LocationsDataModel { Id_location = 54, PlaceName = "موبيل الهايكستب ", Latitude = "30.138449", Longitude = "31.395608", notes = "on the Run " });
            _cairoList.Add(new LocationsDataModel { Id_location = 55, PlaceName = "التجمع total ", Latitude = "30.073571", Longitude = "31.430772", notes = " " });
            _cairoList.Add(new LocationsDataModel { Id_location = 56, PlaceName = "موبيل القاهرة الجديدة ", Latitude = "30.071682", Longitude = "31.430884", notes = " " });
            _cairoList.Add(new LocationsDataModel { Id_location = 57, PlaceName = " القاهرة الجديدةtotal ", Latitude = "30.062991", Longitude = "31.417945", notes = " " });
            _cairoList.Add(new LocationsDataModel { Id_location = 58, PlaceName = "شيل التجمع ", Latitude = "29.993994", Longitude = "31.387427", notes = " " });
            _cairoList.Add(new LocationsDataModel { Id_location = 59, PlaceName = "امارات مصر القاهرة الجديدة ", Latitude = "29.986162", Longitude = "31.308565", notes = " " });
            _cairoList.Add(new LocationsDataModel { Id_location = 60, PlaceName = "الوطنية القاهرة الجديدة ", Latitude = "29.987192", Longitude = "31.310051", notes = " " });
            _cairoList.Add(new LocationsDataModel { Id_location = 61, PlaceName = "الوطنية ط السويس ", Latitude = "30.081054", Longitude = "31.409314", notes = " " });
            _cairoList.Add(new LocationsDataModel { Id_location = 62, PlaceName = "مصر للبترول ابوا الفدا ", Latitude = "30.061553", Longitude = "31.218798", notes = " " });
            _cairoList.Add(new LocationsDataModel { Id_location = 63, PlaceName = "موبيل رمسبس  ", Latitude = "30.056425", Longitude = "31.242184", notes = "on the Run " });
            _cairoList.Add(new LocationsDataModel { Id_location = 64, PlaceName = "موبيل التحرير ", Latitude = "30.045356", Longitude = "31.235898", notes = "Mobil shop - Mine Metro " });
            _cairoList.Add(new LocationsDataModel { Id_location = 65, PlaceName = "ExxonMobil ", Latitude = "30.038372", Longitude = "31.230051", notes = " " });
            _cairoList.Add(new LocationsDataModel { Id_location = 66, PlaceName = "موبيل الكورنيش ", Latitude = "30.018531", Longitude = "31.229622", notes = " " });
            _cairoList.Add(new LocationsDataModel { Id_location = 67, PlaceName = "موبيل الدائرى ", Latitude = "29.989125", Longitude = "31.226267", notes = " " });
            _cairoList.Add(new LocationsDataModel { Id_location = 68, PlaceName = "موبيل حدائق المعادى ", Latitude = "29.964088", Longitude = "31.248475", notes = " " });
            _cairoList.Add(new LocationsDataModel { Id_location = 69, PlaceName = "موبيل ثكنات المعادى ", Latitude = "29.960203", Longitude = "31.258818", notes = " " });
            _cairoList.Add(new LocationsDataModel { Id_location = 70, PlaceName = "موبيل المعادى ", Latitude = "29.982237", Longitude = "31.274278", notes = " " });
            _cairoList.Add(new LocationsDataModel { Id_location = 71, PlaceName = "موبيل كورنيش النيل ", Latitude = "29.929892", Longitude = "31.281622", notes = " " });
            _cairoList.Add(new LocationsDataModel { Id_location = 72, PlaceName = "موبيل طره البلد ", Latitude = "29.930211", Longitude = "31.281544", notes = " " });
            _cairoList.Add(new LocationsDataModel { Id_location = 73, PlaceName = "موبيل حلوان ", Latitude = "29.907761", Longitude = "31.287126", notes = " " });
            _cairoList.Add(new LocationsDataModel { Id_location = 74, PlaceName = "موبيل ش العروبة ", Latitude = "30.091959", Longitude = "31.334748", notes = " on the Run " });
            _cairoList.Add(new LocationsDataModel { Id_location = 75, PlaceName = " Oilibya 15 مايو", Latitude = "29.842040", Longitude = "31.375619", notes = " " });
            _cairoList.Add(new LocationsDataModel { Id_location = 76, PlaceName = "موبيل حلوان ", Latitude = "29.881965", Longitude = "31.304575", notes = " " });
            _cairoList.Add(new LocationsDataModel { Id_location = 77, PlaceName = "موبيل اسمنت حلوان ", Latitude = "29.817885", Longitude = "31.307060", notes = " " });
            _cairoList.Add(new LocationsDataModel { Id_location = 78, PlaceName = "موبيل الأزبكية ", Latitude = "30.054225", Longitude = "31.242585", notes = " " });
            _cairoList.Add(new LocationsDataModel { Id_location = 79, PlaceName = "موبيل احمد حلمى ", Latitude = "30.066604", Longitude = "31.247882", notes = " " });
            _cairoList.Add(new LocationsDataModel { Id_location = 80, PlaceName = "موبيل العباسية ", Latitude = "30.063055", Longitude = "31.261060", notes = " " });
            _cairoList.Add(new LocationsDataModel { Id_location = 81, PlaceName = "موبيل حدائق القبة ", Latitude = "30.076337", Longitude = "31.273315", notes = " " });
            _cairoList.Add(new LocationsDataModel { Id_location = 82, PlaceName = "التعاون ش صلاح سالم ", Latitude = "30.076806", Longitude = "31.311762", notes = " " });
            _cairoList.Add(new LocationsDataModel { Id_location = 83, PlaceName = "موبيل ش الميرغنى ", Latitude = "30.084542", Longitude = "31.325615", notes = "On the Run " });
            _cairoList.Add(new LocationsDataModel { Id_location = 84, PlaceName = "موبيل الكورنيش ", Latitude = "30.094431", Longitude = "31.236934", notes = "On the Run - Mobil Market " });
            _cairoList.Add(new LocationsDataModel { Id_location = 85, PlaceName = "الوطنية مدينة نصر ", Latitude = "30.062507", Longitude = "31.299332", notes = " " });
            _cairoList.Add(new LocationsDataModel { Id_location = 86, PlaceName = "موبيل رابعة العدوية ", Latitude = "30.067637", Longitude = "31.320632", notes = " " });
            _cairoList.Add(new LocationsDataModel { Id_location = 87, PlaceName = "موبيل ش الطيران ", Latitude = "30.065024", Longitude = "31.325015", notes = " " });
            _cairoList.Add(new LocationsDataModel { Id_location = 88, PlaceName = "مصر للبترول ش عباس العقاد ", Latitude = "30.067993", Longitude = "31.335886", notes = " " });
            _cairoList.Add(new LocationsDataModel { Id_location = 89, PlaceName = "total ش عباس العقاد ", Latitude = "30.054141", Longitude = "31.337937", notes = "Mine Metro " });
            _cairoList.Add(new LocationsDataModel { Id_location = 90, PlaceName = "موبيل ش مصطفى النحاس ", Latitude = "30.054368", Longitude = "31.341111", notes = "Mobil Market " });
            _cairoList.Add(new LocationsDataModel { Id_location = 91, PlaceName = "الوطنية مدينة نصر ", Latitude = "30.022238", Longitude = "31.343355", notes = " " });
            _cairoList.Add(new LocationsDataModel { Id_location = 92, PlaceName = "امارات مصر الكورنيش ", Latitude = "29.983087", Longitude = "31.230803", notes = " " });
            _cairoList.Add(new LocationsDataModel { Id_location = 93, PlaceName = "امارات مصر البساتين ", Latitude = "29.985875", Longitude = "31.308630", notes = " " });
            _cairoList.Add(new LocationsDataModel { Id_location = 94, PlaceName = "موبيل مدينة نصر ", Latitude = "29.980132", Longitude = "31.360772", notes = " " });
            _cairoList.Add(new LocationsDataModel { Id_location = 95, PlaceName = "Esso القاطمية ", Latitude = "29.972009", Longitude = "31.378132", notes = " " });
            _cairoList.Add(new LocationsDataModel { Id_location = 96, PlaceName = "شيل مدينة نصر ", Latitude = "29.993792", Longitude = "31.387358", notes = " " });
            _cairoList.Add(new LocationsDataModel { Id_location = 97, PlaceName = "موبيل التجمع الخامس ", Latitude = "30.020587", Longitude = "31.431883", notes = " " });
            _cairoList.Add(new LocationsDataModel { Id_location = 98, PlaceName = "امارات مصر التجمع الخامس ", Latitude = "30.007896", Longitude = "31.430338", notes = " " });
            _cairoList.Add(new LocationsDataModel { Id_location = 99, PlaceName = "Npco التجمع الاول ", Latitude = "30.049436", Longitude = "31.441389", notes = " " });
            _cairoList.Add(new LocationsDataModel { Id_location = 100, PlaceName = "مصر للبترول بيجام ", Latitude = "30.119019", Longitude = "31.258190", notes = " " });
            _cairoList.Add(new LocationsDataModel { Id_location = 101, PlaceName = "موبيل الخلفاوى ", Latitude = "30.097394", Longitude = "31.245734", notes = "Mobil Market " });

            #endregion
            _myGovernrateList.Add(new GovernratesDataModel { GovernrateName = "Cairo", LocationList = _cairoList });
            #region Alex
            _Alx.Add(new LocationsDataModel { Id_location = 0, Latitude = "31.312875", Longitude = "30.059624", PlaceName = "السجل المدنى - ابو قير\nطوسون، الاسكندرية ‏\n03 5619600 ‏" });

            _Alx.Add(new LocationsDataModel { Id_location = 1, Latitude = "31.25302", Longitude = "29.980316", PlaceName = "السجل المدنى - المنتزة\nش الجلاء، فيكتوريا، الاسكندرية\n03 5270927 ‏" });

            _Alx.Add(new LocationsDataModel { Id_location = 2, Latitude = "31.21838", Longitude = "29.953537", PlaceName = "السجل المدنى - سموحة\n47، سموحة، الاسكندرية\n03 4296549" });

            _Alx.Add(new LocationsDataModel { Id_location = 3, Latitude = "31.211297", Longitude = "29.930019", PlaceName = "السجل المدنى - الابراهيمية\nمتفرع من طريق الحرية، الاسكندرية ‏" });

            _Alx.Add(new LocationsDataModel { Id_location = 4, Latitude = "31.21126", Longitude = "29.881825", PlaceName = "السجل المدنى - الجمرك\nالانفوشى، الاسكندرية \n03 4802943 ‏" });

            _Alx.Add(new LocationsDataModel { Id_location = 5, Latitude = "31.254487", Longitude = "29.97139", PlaceName = "السجل المدنى - الرمل\nش الفتح، شدس، الاسكندرية\n03 5750600 ‏" });

            _Alx.Add(new LocationsDataModel { Id_location = 6, Latitude = "31.249204", Longitude = "29.96109", PlaceName = "السجل المدنى - الرمل\n فلمينج، الاسكندرية ‏" });

            _Alx.Add(new LocationsDataModel { Id_location = 7, Latitude = "31.245095", Longitude = "29.988556", PlaceName = "السجل المدنى - الرمل\nخلف ش الشركة العربية، السيوف، الاسكندرية ‏" });

            _Alx.Add(new LocationsDataModel { Id_location = 8, Latitude = "31.024694", Longitude = "29.808655", PlaceName = "السجل المدنى - العامرية\nطريق اسكندرية القاهرة الصحراوى، العامرية، الاسكندرية ‏" });

            _Alx.Add(new LocationsDataModel { Id_location = 9, Latitude = "31.202157", Longitude = "29.90118", PlaceName = "السجل المدنى - العطارين\n03 4864975 ‏" });

            _Alx.Add(new LocationsDataModel { Id_location = 10, Latitude = "31.181378", Longitude = "29.880409", PlaceName = "السجل المدنى - المفروزة\nش المكس، المفروزة، الاسكندرية ‏" });

            _Alx.Add(new LocationsDataModel { Id_location = 11, Latitude = "31.19856", Longitude = "29.928818", PlaceName = "السجل المدنى - باب شرق\nش الحضرة القديمة، باب شرق، الاسكندرية " });

            _Alx.Add(new LocationsDataModel { Id_location = 12, Latitude = "31.204726", Longitude = "29.908218", PlaceName = "السجل المدنى - جامعة الاسكندرية\nش السلطان حسين، الازاريطة، الاسكندرية \n03 4871317 ‏" });

            _Alx.Add(new LocationsDataModel { Id_location = 13, Latitude = "31.234858", Longitude = "29.953065", PlaceName = "السجل المدنى - ستانلى \nبجوار التأمين الصحى - ستانلىستانلى, الاسكندرية\n03-5230090" });

            _Alx.Add(new LocationsDataModel { Id_location = 14, Latitude = "31.261531", Longitude = "29.983063", PlaceName = "السجل المدنى - سيدى بشر\nداخل قسم شرطة سيدى بشرسيدى بشر, الاسكندرية\n03 22513912 ‏" });

            _Alx.Add(new LocationsDataModel { Id_location = 15, Latitude = "31.306128", Longitude = "30.060654", PlaceName = "السجل المدنى - طوسون \n	03-5619600" });
            _Alx.Add(new LocationsDataModel { Id_location = 16, Latitude = "31.202818", Longitude = "29.927444", PlaceName = "السجل المدنى - غربال \nامبروزو، الاسكندرية\n03 4294851 ‏" });

            _Alx.Add(new LocationsDataModel { Id_location = 17, Latitude = "31.227482", Longitude = "29.924011", PlaceName = "السجل المدنى - كامب شيزار \nالإبراهيمية بحري وسيدي جا، قسم باب شرقي، الاسكندرية\n03 5911185 ‏" });

            _Alx.Add(new LocationsDataModel { Id_location = 18, Latitude = "31.182773", Longitude = "29.899507", PlaceName = "السجل المدنى - كرموز \nش السوق، كرموز، الاسكندرية ‏\n03 4960175 ‏" });

            _Alx.Add(new LocationsDataModel { Id_location = 19, Latitude = "31.209865", Longitude = "29.926071", PlaceName = "السجل المدنى - محرم بك\nامبروزو، الاسكندرية ‏\n03 4294851 ‏" });

            #endregion
            _myGovernrateList.Add(new GovernratesDataModel { GovernrateName = "Alex", LocationList = _Alx });

        }

    }
}
