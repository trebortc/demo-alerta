using SmartParking.ViewModels;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace SmartParking.Views
{
    /// <summary>
    /// Page to show the location denied
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LocationPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LocationPage" /> class.
        /// </summary>
        public LocationPage()
        {
            this.InitializeComponent();
            this.BindingContext = LocationPageViewModel.BindingContext;
        }
    }
}