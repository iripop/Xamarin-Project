using BloodForLifeXamarin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BloodForLifeXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            Init();
        }

        void Init()
        {
            BackgroundColor = Constants.BackgroundColor;
            Lbl_Username.TextColor = Constants.MainTextColor;
            Lbl_Password.TextColor = Constants.MainTextColor;
            ASpinner.IsVisible = false;
            LoginIcon.HeightRequest = Constants.LoginIconHeight;

            Entry_Username.Completed += (s, e) => Entry_Password.Focus();
            Entry_Password.Completed += (s, e) => SignInProcedure(s, e);
        }

        async void SignInProcedure(object sender, EventArgs e)
        {
            Donor donor = new Donor(Entry_Username.Text, Entry_Password.Text);
            if (donor.CheckLoginInfo())
            {
                DisplayAlert("Login", "Login Success", "Ok");
                var result = await App.RestService.Login(donor);
                if (result.access_token != null)
                {
                    App.DonorDatabase.SaveDonor(donor);
                }
                
            }
            else
            {
                DisplayAlert("Login", "Login Not Correct, empty username or password", "Ok");
            }
        }
    }
}