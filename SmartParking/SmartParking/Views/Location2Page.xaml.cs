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
    }
}