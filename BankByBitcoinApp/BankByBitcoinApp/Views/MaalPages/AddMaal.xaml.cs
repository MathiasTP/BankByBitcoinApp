using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankByBitcoinApp.Views.MaalPages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BankByBitcoinApp.Views.MaalPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddMaal : ContentPage
    {
        public AddMaal()
        {
            NavigationPage.SetHasBackButton(this, false);
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
        }

        private void Next_Clicked(object sender, EventArgs e)
        {
            App.MaalTitlen = MaalTitle.Text;
            App.MaalAmounten = MaalAmount.Text;
            App.MaalBeskrivelse = MaalBeskrivelseEntry.Text;
            
            
            Navigation.PopModalAsync();
            App.Current.MainPage.Navigation.PushModalAsync(new AddPicture());
        }
    }
}