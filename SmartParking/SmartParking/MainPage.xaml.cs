using System;
using Xamarin.Forms;
using Xamarin.Essentials;
using SmartParking.Model;
using Newtonsoft.Json;
using SmartParking.DataService;
using System.Collections.Generic;

namespace SmartParking
{
    public partial class MainPage : ContentPage
    {
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        private string establecimiento { get; set; }
        public string Establecimiento
        {
            get { return establecimiento; }
            set
            {
                establecimiento = value;
                OnPropertyChanged(nameof(Establecimiento));
            }
        }
        public Usuario usuario { get; set; }
        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
        }
        protected override void OnAppearing()
        {
            if (App.Current.Properties.ContainsKey("usuario"))
            {
                usuario = JsonConvert.DeserializeObject<Usuario>((string)App.Current.Properties["usuario"]);
            }

            List<CentralEmergencia> centrales = ApiService.Instance.GetCentralesEmergencia().Result;
            CentralEmergencia centralEmergencia = new CentralEmergencia();
            foreach (var central in centrales)
            {
                if(central.ID == usuario.id_central)
                {
                    Establecimiento = "" + central.NOMBRE;
                }
            }

            base.OnAppearing();
        }
        public async void btnLocation_Clicked(object sender, System.EventArgs e)
        {           
            Alerta alerta = new Alerta();
            alerta.clienteId = usuario.id_cliente;

            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();

                if (location != null)
                {
                    Latitud = "Latitude: " + location.Latitude.ToString();
                    Longitud = "Longitude:" + location.Longitude.ToString();
                }

                alerta.latitud = Latitud;
                alerta.longitud = Longitud;

                
                bool respuestaAlerta = ApiService.Instance.PostAlerta(alerta).Result;
                
                if (respuestaAlerta)
                {
                    await DisplayAlert("Alerta", "Alerta notificada", "Ok");
                }
                else
                {
                    await DisplayAlert("Alerta", "No se pudo notificar, intente nuevamente", "Ok");
                }
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
