using BankByBitcoinApp.Views.MaalPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BankByBitcoinApp.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Maal : ContentView
    {
        public Maal()
        {
            InitializeComponent();
        }

        private async void Private_Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AddMaal());
        }

        private void Familie_Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
            App.Current.MainPage.Navigation.PushModalAsync(new AddMaal());
        }

        private void OpsparingMaalClicked(object sender, EventArgs e)
        {
           // Private1Image.Scale = 1.3;
            Navigation.PushModalAsync(new EditMaal());
        }
    }
}