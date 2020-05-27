using BankByBitcoinApp.Models;
using BankByBitcoinApp.Services;
using BankByBitcoinApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace BankByBitcoinApp.ViewModels
{
    class LoginPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public string username { get; set; }
        public string password { get; set; }
        bool status;

        public Command OnLoginCommand
        {
            get
            {
                return new Command(() =>
                {
                    OnLoginClicked(username, password);
                   // OnPropertyChanged();
                });
            }
        }

        public async void OnLoginClicked(string navn, string pass)
        {
            List<LoginInfo> currentuserinfo = new List<LoginInfo>();
            currentuserinfo = await App.ServiceManager.GetLoginInfo();
            
            foreach (var p in currentuserinfo)
            {
                
                if(p.userName == username && p.password == password)
                {
                    await App.ServiceManager.GetUserInfo(p.id);
                    await Application.Current.MainPage.DisplayAlert("Login succesfuldt!",
                   "Du er logget ind som: " + username, "OK");
                    status = true;
                   
                    
                    await Application.Current.MainPage.Navigation.PushModalAsync(new InvestmentPage());
                    return;
                }
                else
                {
                    status = false;
                }
            }

            if(status==false)
            {
                await Application.Current.MainPage.DisplayAlert("Bruger findes ikke, prøv igen",
                   "Brugernavn eller password er forkert", "OK");
            }
        }
    }
}
