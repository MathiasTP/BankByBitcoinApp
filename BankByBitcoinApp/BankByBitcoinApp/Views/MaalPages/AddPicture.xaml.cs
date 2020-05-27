using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BankByBitcoinApp.Views.MaalPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddPicture : ContentPage
    {
        public AddPicture()
        {
            InitializeComponent();
        }

        public void Done_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
            
           
        }

        public void Image1_Clicked(object sender, EventArgs e)
        {

            Image1.ScaleTo(0.8);
            Image1.BorderWidth = 5;
            Image1.BorderColor = Xamarin.Forms.Color.Red;
            App.imsource = Image1.Source;
            
        }
        public void Image2_Clicked(object sender, EventArgs e)
        {
            Image2.ScaleTo(0.8);
            Image2.BorderWidth = 5;
            Image2.BorderColor = Xamarin.Forms.Color.Red;
            App.imsource = Image2.Source;
        }
        public void Image3_Clicked(object sender, EventArgs e)
        {
            Image3.ScaleTo(0.8);
            Image3.BorderWidth = 5;
            Image3.BorderColor = Xamarin.Forms.Color.Red;
            App.imsource = Image3.Source;
        }
        public void Image4_Clicked(object sender, EventArgs e)
        {
            Image4.ScaleTo(0.8);
            Image4.BorderWidth = 5;
            Image4.BorderColor = Xamarin.Forms.Color.Red;
            App.imsource = Image4.Source;
        }
        public void Image5_Clicked(object sender, EventArgs e)
        {
            Image5.ScaleTo(0.8);
            Image5.BorderWidth = 5;
            Image5.BorderColor = Xamarin.Forms.Color.Red;
            App.imsource = Image5.Source;
        }
        public void Image6_Clicked(object sender, EventArgs e)
        {
            Image6.ScaleTo(0.8);
            Image6.BorderWidth = 5;
            Image6.BorderColor = Xamarin.Forms.Color.Red;
            App.imsource = Image6.Source;

        }
    }
}