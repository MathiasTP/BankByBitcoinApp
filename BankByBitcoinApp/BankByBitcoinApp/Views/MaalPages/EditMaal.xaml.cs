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
    public partial class EditMaal : ContentPage
    {
        public EditMaal()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (App.MaalAmounten != null & App.MaalTitlen != null)
            {
                MaalTitle.Text = App.MaalTitlen;
                MaalBeskrivelseEntry.Text = App.MaalBeskrivelse;
                MaalAmount.Text = App.MaalAmounten;
            }

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            App.MaalTitlen = MaalTitle.Text;
            App.MaalBeskrivelse = MaalBeskrivelseEntry.Text;
            App.MaalAmounten = MaalAmount.Text;
            
            Navigation.PopModalAsync();
        }
    }
}