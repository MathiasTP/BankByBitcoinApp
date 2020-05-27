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
    public partial class FirstPage : ContentPage
    {
        int i;
        public string prevtitle;
        public FirstPage()
        {
            NavigationPage.SetHasBackButton(this, true);
            NavigationPage.SetHasNavigationBar(this, true);
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if(App.imsource != null && App.MaalAmounten!=null & App.MaalTitlen!=null)
            {
                
                ImageButton imageButton = new ImageButton
                {
                    Source = App.imsource,
                    
                    HorizontalOptions = LayoutOptions.Fill,
                    VerticalOptions = LayoutOptions.Fill,
                    CornerRadius = 20,
                    Aspect = Aspect.AspectFill,
                    BackgroundColor = Color.FromHex("#1f2427")
                };

                Label MaalTitel = new Label
                {
                    FontSize = 20,
                    TextColor = Color.White,
                    HorizontalOptions = LayoutOptions.Start,
                    VerticalOptions = LayoutOptions.Center,
                    Margin = new Thickness(15, 0, 0, 0),
                    FontAttributes = FontAttributes.Bold,
                    Text = App.MaalTitlen
                };

                Label MaalAmount = new Label
                {
                    FontSize = 20,
                    TextColor = Color.White,
                    HorizontalOptions = LayoutOptions.Start,
                    VerticalOptions = LayoutOptions.Center,
                    Text = App.MaalAmounten + " kr",
                    Margin = new Thickness(15,55,0,0)
                };

                ProgressBar bar = new ProgressBar
                {
                    ProgressColor = Color.Gold,
                    Progress = 0.50,
                    VerticalOptions = LayoutOptions.End,
                    HorizontalOptions = LayoutOptions.Fill,
                    
                    Margin = new Thickness(15,15,0,0)
                    

                };

                imageButton.Clicked += OpsparingMaalClicked;


                Griddet.Children.Add(imageButton, 0, 2+i);
                Griddet.Children.Add(MaalTitel, 0, 2+i);
                Griddet.Children.Add(MaalAmount, 0, 2+i);
                Griddet.Children.Add(bar, 0, 2+i);

                i++;
                prevtitle = App.MaalTitlen;
            }
            
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