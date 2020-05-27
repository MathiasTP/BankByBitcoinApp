using BankByBitcoinApp.Models;
using BankByBitcoinApp.Services;
using BankByBitcoinApp.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BankByBitcoinApp.Views.MaalPages;
namespace BankByBitcoinApp
{
    public partial class App : Application
    {

        public static UserInfo userinfo;
        public static List<UserInfo> userinfos;
        public static double BitcoinPrice;
        public static double BitcoinChange;

        public static string MaalTitlen;
        public static string MaalAmounten;
        public static string MaalImageUrl;
        public static string MaalBeskrivelse;
        public static Xamarin.Forms.ImageSource imsource;
        public static ServiceManager ServiceManager { get; private set; }
        public App()
        {
            InitializeComponent();
            ServiceManager = new ServiceManager(new RestService());
            
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
