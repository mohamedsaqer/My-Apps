using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Map_Sample_Uni.Code
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
        private ObservableCollection<PoliceOfficeModel> AlexPO = new ObservableCollection<PoliceOfficeModel>();
        public void FillingModel()
        {

            #region cairo 1
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 0, OfficeName = "موبيل البطل احمد عبدالعزيز ", Latitude = 30.051598, Longitude = 31.208190,notes = "on the Run" });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 1, OfficeName = "التعاون محى الدين ابو العز", Latitude = 30.048910, Longitude = 31.198309, notes = "اصلاح اطارات" });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 2, OfficeName = " موبيل أطلس ", Latitude = 30.057602, Longitude = 31.206216,notes = "on the Run" });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 3, OfficeName = "التعاون احمد عرابى", Latitude = 30.061725, Longitude = 31.207133, notes = " Car Wash " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 4, OfficeName = "غازتك العجوزة", Latitude = 30.061163, Longitude = 31.211529, notes = " "  });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 5, OfficeName = "التعاون العجوزة", Latitude = 30.061179, Longitude = 31.211395, notes = " " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 6, OfficeName = "موبيل مصدق", Latitude = 30.040523, Longitude = 31.210690, notes = " " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 7, OfficeName = "التعاون الدقى", Latitude = 30.035796, Longitude = 31.211494, notes = " " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 8, OfficeName = "مصر للبترول الدقى", Latitude = 30.040221, Longitude = 31.218838, notes = " " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 9, OfficeName = "موبيل امين الرافعى", Latitude = 30.035266, Longitude = 31.217811, notes = " " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 10, OfficeName = "التعاون ش مراد ", Latitude = 30.017390, Longitude = 31.213817, notes = " " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 11, OfficeName = "موبيل ربيع الجيزى ", Latitude = 30.014619, Longitude = 31.209847, notes = " " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 12, OfficeName = "موبيل ش السودان ", Latitude = 30.064053, Longitude = 31.190208, notes = " " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 13, OfficeName = "موبيل امبابة ", Latitude = 30.071019, Longitude = 31.199878, notes = " " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 14, OfficeName = "كالتكس فيصل ", Latitude = 30.000056, Longitude = 31.164749, notes = " " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 15, OfficeName = "كالتكس الهرم ", Latitude = 29.991570, Longitude = 31.153532, notes = " " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 16, OfficeName = "الهرم ExxonMobil ", Latitude = 29.998174, Longitude = 31.172554, notes = " " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 17, OfficeName = "الهرم total ", Latitude = 30.005955, Longitude = 31.191826, notes = " " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 18, OfficeName = "العمرانية total ", Latitude = 30.008404, Longitude = 31.202308, notes = " " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 19, OfficeName = "التعاون فيصل ", Latitude = 30.000461, Longitude = 31.163929, notes = " " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 20, OfficeName = "المريوطية total ", Latitude = 30.001775, Longitude = 31.139913, notes = " " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 21, OfficeName = "موبيل فيصل ", Latitude = 29.991410, Longitude = 31.140020, notes = " " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 22, OfficeName = "شيل فيصل ", Latitude = 29.991025, Longitude = 31.138137, notes = " " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 23, OfficeName = "فيصل Esso ", Latitude = 30.030520, Longitude = 31.182280, notes = " " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 24, OfficeName = "غازتك ش العشرين ", Latitude = 30.018321, Longitude = 31.184648, notes = " " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 25, OfficeName = "كالتكس ش العشرين ", Latitude = 30.018202, Longitude = 31.184721, notes = " " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 26, OfficeName = "موبيل ش شهاب ", Latitude = 30.054875, Longitude = 31.195410, notes = " " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 27, OfficeName = "موبيل ش المحروقى ", Latitude = 30.058906, Longitude = 31.208178, notes = " " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 28, OfficeName = "موبيل ابوالفدا", Latitude = 30.061153, Longitude = 31.219765, notes = " " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 29, OfficeName = "امارات مصر اسكنراية الصحرواى ", Latitude = 30.061190, Longitude = 31.029328, notes = " " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 30, OfficeName = "موبيل الصحرواى", Latitude = 30.063641, Longitude = 31.025466, notes = " " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 31, OfficeName = "الشيخ زايد total ", Latitude = 30.017073, Longitude = 30.97541, notes = " " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 32, OfficeName = "موبيل مول العرب ", Latitude = 30.006946, Longitude = 30.979718, notes = " " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 33, OfficeName = "موبيل جامعة النيل ", Latitude = 30.013524, Longitude = 30.997056, notes = " " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 34, OfficeName = "كالتكس اكتوبر ", Latitude = 29.995940, Longitude = 30.961342,notes = " مينى مترو - برجر كينج" });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 35, OfficeName = "موبيل اكتوبر", Latitude = 29.974959, Longitude = 30.956635, notes = " " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 36, OfficeName = "موبيل ط الواحات ", Latitude = 29.963369, Longitude = 30.969123, notes = " " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 37, OfficeName = "كالتكس الحصرى ", Latitude = 29.971883, Longitude = 30.944393, notes = " " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 38, OfficeName = "اكتوبر total ", Latitude = 29.950783, Longitude = 30.906842, notes = " " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 39, OfficeName = "التعاون م الجيزة ", Latitude = 29.961398, Longitude = 30.930306, notes = " " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 40, OfficeName = " ط الواحات total ", Latitude = 29.974122, Longitude = 30.989980, notes = " " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 41, OfficeName = "الوطنية ط الواحات ", Latitude = 29.961686, Longitude = 31.041071, notes = " " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 42, OfficeName = "موبيل ط الواحات ", Latitude = 29.956992, Longitude = 31.057615, notes = " " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 43, OfficeName = "الوطنية ط الواحات  ", Latitude = 29.958675, Longitude = 31.063719, notes = " " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 44, OfficeName = "موبيل ناهيا  ", Latitude = 30.041972, Longitude = 31.167971, notes = " " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 45, OfficeName = "الوطنية ش ناهيا  ", Latitude = 30.044517, Longitude = 31.179112, notes = " " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 46, OfficeName = "التعاون سكة الحاج على", Latitude = 30.044438, Longitude = 31.173632, notes = " " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 47, OfficeName = "موبيل ش شهاب ", Latitude = 30.055167, Longitude = 31.194587, notes = " " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 48, OfficeName = "كالتكس الطريق الدائرى ", Latitude = 30.139766, Longitude = 31.204994, notes = " " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 49, OfficeName = "كالتكس القناطر ", Latitude = 30.147323, Longitude = 31.216603, notes = " " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 50, OfficeName = "التعاون قسم شبرا ", Latitude = 30.153214, Longitude = 31.278953, notes = " " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 51, OfficeName = "موبيل الطريق الدائرى ", Latitude = 30.162171, Longitude = 31.288625, notes = " " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 52, OfficeName = "امارات مصر الخانكة ", Latitude = 30.163354, Longitude = 31.34973, notes = " " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 53, OfficeName = "موبيل جسر السويس ", Latitude = 30.147151, Longitude = 31.420617, notes = " " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 54, OfficeName = "موبيل الهايكستب ", Latitude = 30.138449, Longitude = 31.395608, notes = "on the Run " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 55, OfficeName = "التجمع total ", Latitude = 30.073571, Longitude = 31.430772, notes = " " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 56, OfficeName = "موبيل القاهرة الجديدة ", Latitude = 30.071682, Longitude = 31.430884, notes = " " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 57, OfficeName = " القاهرة الجديدةtotal ", Latitude = 30.062991, Longitude = 31.417945, notes = " " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 58, OfficeName = "شيل التجمع ", Latitude = 29.993994, Longitude = 31.387427, notes = " " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 59, OfficeName = "امارات مصر القاهرة الجديدة ", Latitude = 29.986162, Longitude = 31.308565, notes = " " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 60, OfficeName = "الوطنية القاهرة الجديدة ", Latitude = 29.987192, Longitude = 31.310051, notes = " " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 61, OfficeName = "الوطنية ط السويس ", Latitude = 30.081054, Longitude = 31.409314, notes = " " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 62, OfficeName = "مصر للبترول ابوا الفدا ", Latitude = 30.061553, Longitude = 31.218798, notes = " " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 63, OfficeName = "موبيل رمسبس  ", Latitude = 30.056425, Longitude = 31.242184, notes = "on the Run " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 64, OfficeName = "موبيل التحرير ", Latitude = 30.045356, Longitude = 31.235898, notes = "Mobil shop - Mine Metro " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 65, OfficeName = "ExxonMobil ", Latitude = 30.038372, Longitude = 31.230051, notes = " " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 66, OfficeName = "موبيل الكورنيش ", Latitude = 30.018531, Longitude = 31.229622, notes = " " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 67, OfficeName = "موبيل الدائرى ", Latitude = 29.989125, Longitude = 31.226267, notes = " " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 68, OfficeName = "موبيل حدائق المعادى ", Latitude = 29.964088, Longitude = 31.248475, notes = " " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 69, OfficeName = "موبيل ثكنات المعادى ", Latitude = 29.960203, Longitude = 31.258818, notes = " " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 70, OfficeName = "موبيل المعادى ", Latitude = 29.982237, Longitude = 31.274278, notes = " " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 71, OfficeName = "موبيل كورنيش النيل ", Latitude = 29.929892, Longitude = 31.281622, notes = " " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 72, OfficeName = "موبيل طره البلد ", Latitude = 29.930211, Longitude = 31.281544, notes = " " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 73, OfficeName = "موبيل حلوان ", Latitude = 29.907761, Longitude = 31.287126, notes = " " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 74, OfficeName = "موبيل ش العروبة ", Latitude = 30.091959, Longitude = 31.334748, notes = " on the Run " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 75, OfficeName = " Oilibya 15 مايو", Latitude = 29.842040, Longitude = 31.375619, notes = " " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 76, OfficeName = "موبيل حلوان ", Latitude = 29.881965, Longitude = 31.304575, notes = " " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 77, OfficeName = "موبيل اسمنت حلوان ", Latitude = 29.817885, Longitude = 31.307060, notes = " " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 78, OfficeName = "موبيل الأزبكية ", Latitude = 30.054225, Longitude = 31.242585, notes = " " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 79, OfficeName = "موبيل احمد حلمى ", Latitude = 30.066604, Longitude = 31.247882, notes = " " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 80, OfficeName = "موبيل العباسية ", Latitude = 30.063055, Longitude = 31.261060, notes = " " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 81, OfficeName = "موبيل حدائق القبة ", Latitude = 30.076337, Longitude = 31.273315, notes = " " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 82, OfficeName = "التعاون ش صلاح سالم ", Latitude = 30.076806, Longitude = 31.311762, notes = " " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 83, OfficeName = "موبيل ش الميرغنى ", Latitude = 30.084542, Longitude = 31.325615, notes = "On the Run " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 84, OfficeName = "موبيل الكورنيش ", Latitude = 30.094431, Longitude = 31.236934, notes = "On the Run - Mobil Market " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 85, OfficeName = "الوطنية مدينة نصر ", Latitude = 30.062507, Longitude = 31.299332, notes = " " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 86, OfficeName = "موبيل رابعة العدوية ", Latitude = 30.067637, Longitude = 31.320632, notes = " " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 87, OfficeName = "موبيل ش الطيران ", Latitude = 30.065024, Longitude = 31.325015, notes = " " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 88, OfficeName = "مصر للبترول ش عباس العقاد ", Latitude = 30.067993, Longitude = 31.335886, notes = " " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 89, OfficeName = "total ش عباس العقاد ", Latitude = 30.054141, Longitude = 31.337937, notes = "Mine Metro " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 90, OfficeName = "موبيل ش مصطفى النحاس ", Latitude = 30.054368, Longitude = 31.341111, notes = "Mobil Market " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 91, OfficeName = "الوطنية مدينة نصر ", Latitude = 30.022238, Longitude = 31.343355, notes = " " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 92, OfficeName = "امارات مصر الكورنيش ", Latitude = 29.983087, Longitude = 31.230803, notes = " " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 93, OfficeName = "امارات مصر البساتين ", Latitude = 29.985875, Longitude = 31.308630, notes = " " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 94, OfficeName = "موبيل مدينة نصر ", Latitude = 29.980132, Longitude = 31.360772, notes = " " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 95, OfficeName = "Esso القاطمية ", Latitude = 29.972009, Longitude = 31.378132, notes = " " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 96, OfficeName = "شيل مدينة نصر ", Latitude = 29.993792, Longitude = 31.387358, notes = " " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 97, OfficeName = "موبيل التجمع الخامس ", Latitude = 30.020587, Longitude = 31.431883, notes = " " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 98, OfficeName = "امارات مصر التجمع الخامس ", Latitude = 30.007896, Longitude = 31.430338, notes = " " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 99, OfficeName = "Npco التجمع الاول ", Latitude = 30.049436, Longitude = 31.441389, notes = " " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 100, OfficeName = "مصر للبترول بيجام ", Latitude = 30.119019, Longitude = 31.258190, notes = " " });
            CairoPO.Add(new PoliceOfficeModel() { Id_Office = 101, OfficeName = "موبيل الخلفاوى ", Latitude = 30.097394, Longitude = 31.245734, notes = "Mobil Market " });
            _governrateList.Add(new DataModel() { Id_Governrate = 0, GovernrateName = "القاهرة الكبرى", GovernrateImg = "/Assets/Logos/awhite.png", POfficeList = CairoPO });
            #endregion
            #region Alex  2
            AlexPO.Add(new PoliceOfficeModel() { Id_Office = 0, OfficeName = "قسم شرطة الجمرك", Latitude = 31.19883, Longitude = 29.882901 });
            AlexPO.Add(new PoliceOfficeModel() { Id_Office = 1, OfficeName = "قسم شرطة الدخيلة القديم-نقطه شرطه", Latitude = 31.134187, Longitude = 29.820022 });
            AlexPO.Add(new PoliceOfficeModel() { Id_Office = 2, OfficeName = "قسم شرطة الدخيلة", Latitude = 31.124158, Longitude = 29.812286 });
            AlexPO.Add(new PoliceOfficeModel() { Id_Office = 3, OfficeName = "قسم شرطة الرمل اول", Latitude = 31.234543, Longitude = 29.958794 });
            AlexPO.Add(new PoliceOfficeModel() { Id_Office = 4, OfficeName = "قسم شرطة الرمل ثاني", Latitude = 31.229908, Longitude = 29.988319 });
            AlexPO.Add(new PoliceOfficeModel() { Id_Office = 5, OfficeName = "قسم شرطة العامرية اول", Latitude = 31.009173, Longitude = 29.806248 });
            AlexPO.Add(new PoliceOfficeModel() { Id_Office = 6, OfficeName = "قسم شرطة العامرية ثاني", Latitude = 30.98984, Longitude = 29.788031 });
            AlexPO.Add(new PoliceOfficeModel() { Id_Office = 7, OfficeName = "قسم شرطة العطارين", Latitude = 31.194421, Longitude = 29.905463 });
            AlexPO.Add(new PoliceOfficeModel() { Id_Office = 8, OfficeName = "قسم شرطة اللبان", Latitude = 31.190782, Longitude = 29.896078 });
            AlexPO.Add(new PoliceOfficeModel() { Id_Office = 9, OfficeName = "قسم شرطة المنتزة اول", Latitude = 31.246425, Longitude = 29.980678 });
            AlexPO.Add(new PoliceOfficeModel() { Id_Office = 10, OfficeName = "قسم شرطة المنتزة ثانى", Latitude = 31.303369, Longitude = 30.060323 });
            AlexPO.Add(new PoliceOfficeModel() { Id_Office = 11, OfficeName = "قسم شرطة المنشية", Latitude = 31.199858, Longitude = 29.890582 });
            AlexPO.Add(new PoliceOfficeModel() { Id_Office = 12, OfficeName = "قسم شرطة باب شرق", Latitude = 31.202024, Longitude = 29.917321 });
            AlexPO.Add(new PoliceOfficeModel() { Id_Office = 13, OfficeName = "قسم شرطة سيدى جابر", Latitude = 31.215102, Longitude = 29.937264 });
            AlexPO.Add(new PoliceOfficeModel() { Id_Office = 14, OfficeName = "قسم شرطة كرموز", Latitude = 31.182023, Longitude = 29.899364 });
            AlexPO.Add(new PoliceOfficeModel() { Id_Office = 15, OfficeName = "قسم شرطة محرم بك", Latitude = 31.192199, Longitude = 29.918518 });
            AlexPO.Add(new PoliceOfficeModel() { Id_Office = 16, OfficeName = "قسم شرطة مدينة برج العرب الجديدة", Latitude = 30.883268, Longitude = 29.575042 });
            AlexPO.Add(new PoliceOfficeModel() { Id_Office = 17, OfficeName = "قسم شرطة مينا البصل", Latitude = 31.185047, Longitude = 29.888549 });
            AlexPO.Add(new PoliceOfficeModel() { Id_Office = 18, OfficeName = "قسم شرطة ميناء الاسكندرية", Latitude = 31.183349, Longitude = 29.878832 });

            _governrateList.Add(new DataModel() { Id_Governrate = 1, GovernrateName = "الأسكندريه", GovernrateImg = "/Assets/Logos/awhite.png", POfficeList = AlexPO });
            #endregion
           }
    }
    public class PoliceOfficeModel
    {
        public int Id_Office { get; set; }
        public string OfficeName { get; set; }
        public string notes { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
   
}
