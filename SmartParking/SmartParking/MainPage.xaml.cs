using System;
using Xamarin.Forms;
using Xamarin.Essentials;
using SmartParking.Model;
using Newtonsoft.Json;
using SmartParking.DataService;
using System.Collections.Generic;
using Xamarin.Forms.OpenWhatsApp;
using SmartParking.Views;

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
        public CentralEmergencia centralEmergencia { get; set; }
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
            
            foreach (var central in centrales)
            {
                if(central.ID == usuario.id_central)
                {
                    Establecimiento = "" + central.NOMBRE;
                    centralEmergencia = central;
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
                    Latitud = location.Latitude.ToString();
                    Longitud = location.Longitude.ToString();
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
                await DisplayAlert("Error", fnsEx.Message, "OK");
            }
            catch (PermissionException pEx)
            {
                await DisplayAlert("Error", "No se tiene permisos para enviar la ubicación", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }

        }
        public async void btnLLamada_Clicked(object sender, System.EventArgs e)
        {
            try
            {
                
                PhoneDialer.Open(centralEmergencia.TELEFONO);
            }catch(Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }
        public async void btnMensaje_Clicked(object sender, System.EventArgs e)
        {
            try
            {
                Chat.Open("+593" + centralEmergencia.WHATSAPP, "Auxilio!!");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }
        public void btnSalir_Clicked(object sender, System.EventArgs e)
        {
            Application.Current.Properties.Clear();
            Application.Current.MainPage = new NavigationPage(new LoginPage());
        }
    }
}
