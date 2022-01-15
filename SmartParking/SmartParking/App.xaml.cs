using SmartParking.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: ExportFont("Montserrat-Bold.ttf",Alias="Montserrat-Bold")]
     [assembly: ExportFont("Montserrat-Medium.ttf", Alias = "Montserrat-Medium")]
     [assembly: ExportFont("Montserrat-Regular.ttf", Alias = "Montserrat-Regular")]
     [assembly: ExportFont("Montserrat-SemiBold.ttf", Alias = "Montserrat-SemiBold")]
     [assembly: ExportFont("UIFontIcons.ttf", Alias = "FontIcons")]
namespace SmartParking
{
    public partial class App : Application
    {
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NTY1NzAzQDMxMzkyZTM0MmUzMEk3TGVNdTQvb0gvRGpSQlY0dFZaTWJ2VkpNOEZSUzNFWkFnOTlIdkVQeFk9");
            InitializeComponent();            
            //MainPage = new LoginPage();
            MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
