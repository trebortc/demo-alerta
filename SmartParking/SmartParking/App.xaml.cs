using Newtonsoft.Json;
using SmartParking.Model;
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
        public static string ImageServerPath { get; } = "https://cdn.syncfusion.com/essential-ui-kit-for-xamarin.forms/common/uikitimages/";
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NTY1NzAzQDMxMzkyZTM0MmUzMEk3TGVNdTQvb0gvRGpSQlY0dFZaTWJ2VkpNOEZSUzNFWkFnOTlIdkVQeFk9");
            InitializeComponent();
            //MainPage = new LoginPage();
            if (App.Current.Properties.ContainsKey("usuario"))
            {
                Usuario usuario = JsonConvert.DeserializeObject<Usuario>((string)App.Current.Properties["usuario"]);
                if (usuario != null)
                {
                    MainPage = new NavigationPage(new MainPage());
                }
                else
                {
                    MainPage = new NavigationPage(new LoginPage());
                }
            }            
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
