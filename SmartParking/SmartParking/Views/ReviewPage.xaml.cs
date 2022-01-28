﻿using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace SmartParking.Views
{
    /// <summary>
    /// Page to get review from customer
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReviewPage
    {
        public ReviewPage()
        {
            this.InitializeComponent();
            this.ProductImage.Source = App.ImageServerPath + "Image1.png";
            this.dashedBorder.DashArray = new double[2] { 5, 5 };
        }
    }
}