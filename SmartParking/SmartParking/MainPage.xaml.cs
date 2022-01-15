using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace SmartParking
{
    public partial class MainPage : ContentPage
    {
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public MainPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
        public async void btnLocation_Clicked(object sender, System.EventArgs e)
        {
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();

                if (location != null)
                {
                    Latitud = "Latitude: " + location.Latitude.ToString();
                    Longitud = "Longitude:" + location.Longitude.ToString();
                }

                await DisplayAlert("Alert", "" + Latitud + " - " + Longitud, "Ok");
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                await DisplayAlert("Faild", fnsEx.Message, "OK");
            }
            catch (PermissionException pEx)
            {
                await DisplayAlert("Faild", pEx.Message, "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Faild", ex.Message, "OK");
            }

        }
    }
}
