using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace SmartParking.Views
{
    /// <summary>
    /// Page to display on-boarding gradient with animation
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Location2Page
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Location2Page" /> class.
        /// </summary>
        public Location2Page()
        {
            this.InitializeComponent();
            //ValidarPermisoDeGPS();
        }
        private async void ValidarPermisoDeGPS()
        {
            var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
            if (status == PermissionStatus.Granted)
            {
                
            }
            else
            {                
                    //await Application.Current.MainPage.DisplayAlert("Advertencia", "Smart Parking recopila datos de ubicación para permitir " +
                    //                                                            "el seguimiento de su ubicación en la emision de alertas " +
                    //                                                            "de emergencia incluso cuando la aplicación está cerrada " +
                    //                                                            "o no está en uso.", "Aceptar");   
                //Ask for the permission
                status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();

                if (status == PermissionStatus.Granted)
                {
                    
                }
                else
                {
                    ValidarPermisoDeGPS();
                }
            }
        }
    }
}