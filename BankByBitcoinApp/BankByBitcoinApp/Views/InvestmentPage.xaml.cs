using BankByBitcoinApp.Models;
using BankByBitcoinApp.Views.MaalPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BankByBitcoinApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InvestmentPage : ContentPage
    {
       
        public InvestmentPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            BTC btc = await App.ServiceManager.GetBitcoinPrice();
            
            NavnEntry.Text = App.userinfo.navn;
            InvestmentAmount.Text = App.userinfo.InitialInvestment.ToString() + " DKK";
            BitcoinChangePrice.Text = DayChange().ToString("F") + " kr." + " ("+ App.BitcoinChange.ToString("F") + "%)";
            CurrentValueLabel.Text = CurrentValue().ToString("F") + " DKK";
            Refresh.IsRefreshing = false;
        }

        public double CurrentValue()
        {
            double btcprice = App.BitcoinPrice;
            double btcpriceAtInvest = App.userinfo.BTCPriceAtInvest;
            double investamount = App.userinfo.InitialInvestment / 6.86;

            double BtcAmountAtInvest = investamount / btcpriceAtInvest;

            double CurrentInvestValue = BtcAmountAtInvest * btcprice * 6.86;
            return CurrentInvestValue;
        }

        public double DayChange()
        {
            double btcprice = App.BitcoinPrice;
            double changed = App.BitcoinChange / 100;
            double amountchanged = CurrentValue() * changed;
            if(amountchanged<0)
            {
                BitcoinChangePrice.TextColor = Color.Red;
            }
            else
            {
                BitcoinChangePrice.TextColor = Color.Green;
            }
            return amountchanged;
        }

        private void RefreshView_Refreshing(object sender, EventArgs e)
        {
            OnAppearing();
        }

        private void Close_Clicked(object sender, EventArgs e)
        {
            OpsparingFrame.IsVisible = false;
            CloseButton.IsVisible = false;
        }

        private void Opret_Maal_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushModalAsync(new FirstPage());
        }
    }
}