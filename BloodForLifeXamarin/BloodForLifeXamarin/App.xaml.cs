using BloodForLifeXamarin.Data;
using BloodForLifeXamarin.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace BloodForLifeXamarin
{
    public partial class App : Application
    {
        static TokenDatabaseController tokenDatabase;
        static DonorDatabaseController donorDatabase;
        static RestService restService;

        public App()
        {
            InitializeComponent();

            MainPage = new LoginPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }


        public static DonorDatabaseController DonorDatabase
        {
            get
            {
                if (donorDatabase == null)
                {
                    donorDatabase = new DonorDatabaseController();
                }
                return donorDatabase;
            }
        }

        public static TokenDatabaseController TokenDatabase
        {
            get
            {
                if (tokenDatabase == null)
                {
                    tokenDatabase = new TokenDatabaseController();
                }
                return tokenDatabase;
            }
        }

        public static RestService RestService
        {
            get
            {
                if (restService == null)
                {
                    restService = new RestService();
                }
                return restService;
            }
        }
    }
}
