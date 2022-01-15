using Android.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Application = Android.App.Application;

[assembly: ExportRenderer(typeof(SmartParking.Controls.BorderlessEntry), typeof(SmartParking.Droid.BorderlessEntryRenderer))]

namespace SmartParking.Droid
{
    public class BorderlessEntryRenderer : EntryRenderer
    {
        public BorderlessEntryRenderer()
            : base(Application.Context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (this.Control != null)
            {
                this.Control.SetBackground(null);
                this.Control.Gravity = GravityFlags.CenterVertical;
                this.Control.SetPadding(0, 0, 0, 0);
            }
        }
    }
}