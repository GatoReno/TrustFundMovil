using System;
using Openpay.Xamarin;
using SQLite;
using TrustFund.Classes_;
using TrustFund.Models_;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace TrustFund
{
    public partial class App : Application
    {



        public App()
        {

            InitializeComponent();

            DataInfoUser datainfouser = new DataInfoUser();
            var datauser = datainfouser.GetUserData();

            if (datauser != null)
            {

                MainPage = new NavigationPage(new MainPage());
            }
            else
                {
                MainPage = //
                new Views.SignInPage();
            }



            MainPage = //new NavigationPage(new MainPage());
            new Views.SignInPage();//new Units();
            //new NavigationPage(new SignInPage());



        }

        protected override void OnStart()
        {
            // Handle when your app starts
            base.OnStart();

            // Initialize Openpay
         
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
