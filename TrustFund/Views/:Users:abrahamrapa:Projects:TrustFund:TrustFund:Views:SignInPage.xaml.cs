using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using TrustFund.Classes_;
using System.Net.Http;
using TrustFund.Models_;
using Newtonsoft.Json;
using UIKit;
using Xamarin.Forms.Xaml;
using SQLite;
using Plugin.Connectivity;

namespace TrustFund
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignInPage : ContentPage
    {


        public User user;
        public UserDataBase userDataBase;
        public SQLiteConnection conn;


        public SignInPage() 
        {
            InitializeComponent();
            ErrorMsn.IsVisible = false;


      

                TryAccess_token();


        }

        //Diseño


        protected override async void OnAppearing() {

            base.OnAppearing();

           

            InitializeComponent();

            if (!CrossConnectivity.Current.IsConnected)
            {
                await DisplayAlert("Advertencia ! ", "PORFAVOR ACITVE SUS DATOS PARA CONTINUAR ", "Ok");


            }
           
        }




            //Termina diseño


        // BackEnd

        public async void TryAccess_token() {

            userDataBase = new UserDataBase();
            var user_exist = userDataBase.GetMembers();
            int RowCount = 0;
            int usercount = user_exist.Count();
            RowCount = Convert.ToInt32(usercount);

            if (RowCount > 0)
            {



                var userLite = user_exist.First();
                var tokenCheck = userLite.tok;


                HttpClient client = new HttpClient();

         

                var value_check = new Dictionary<string, string>
                         {
                            { "token", tokenCheck}
                         };


                var content = new FormUrlEncodedContent(value_check);
                var response = await client.PostAsync("https://trustfundapp.herokuapp.com/m/ensureToken", content);

                switch (response.StatusCode)
                {
                    case (System.Net.HttpStatusCode.OK):

                        Application.Current.MainPage = new NavigationPage(new MainPage());


                        break;


                    case (System.Net.HttpStatusCode.Forbidden):

                        ErrorMsn.IsVisible = true;ErrorMsn.Text = "Porfavor confirma tus datos de sesión";
                        Cator.IsVisible = false; Cator.IsRunning = false;
                        Username.IsVisible = true; Pass.IsVisible = true;
                        Pass.Focus();

                        SubmitButton.Text = "Volver a Intentar";

                        break;

                }



            }


        }

        void BorrarUsers(object sender, System.EventArgs e)
        {
            userDataBase.DropTbMember();

        }

        public async void  Access_Login(object sender, EventArgs e)
        {
            Cator.IsVisible = true; Cator.IsRunning = true;
            Username.IsVisible = false; Pass.IsVisible = false;
            SubmitButton.Text = "Procesando";

            //paso 1 confirmar contraseña


            HttpClient client = new HttpClient();

            var username = Username.Text;
            var pass = Pass.Text;

            var values = new Dictionary<string, string>
                         {
                            { "username",  "kiko" },
                            { "pass", "12345678" }
                         };

            var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync("https://trustfundapp.herokuapp.com/m/confirm-pass",
                content);



            //if contraseña true

            //paso 2 solicitar token a trustfund

            // paso 3

            switch (response.StatusCode) {
                case (System.Net.HttpStatusCode.OK):




                    string xjson = await response.Content.ReadAsStringAsync();

                  

                    var json_ = JsonConvert.DeserializeObject<ResponceTrustPass>(xjson);


                    try {

                        user = new User();
                        userDataBase = new UserDataBase();

                        //userDataBase.DropTbMember();
                        user.username = json_.responce.user_info.username;
                        user.mail = json_.responce.user_info.mail;
                        user.tok = json_.responce.token;
                        user.id = json_.responce.user_info.id;

                        userDataBase.AddMember(user);

                        await DisplayAlert("error", "yeah", "ok");


                    }
                    catch(Exception err) {

                        var ersr = err;

                        await DisplayAlert("error", "yeah"+err.ToString(), "ok");


                    }

                    Application.Current.MainPage = new NavigationPage(new MainPage());

                    break;


                case (System.Net.HttpStatusCode.Forbidden):
                    //contraseña incorrecta

                    Cator.IsVisible = false; Cator.IsRunning = false;
                    Username.IsVisible = true; Pass.IsVisible = true;
                    Pass.Focus();

                    SubmitButton.Text = "Ingresar";

                    break;

                case (System.Net.HttpStatusCode.MethodNotAllowed):
                    //usuario invalido

                    Cator.IsVisible = false; Cator.IsRunning = false;
                    Username.IsVisible = true; Pass.IsVisible = true;
                    Pass.Focus();

                    SubmitButton.Text = "Ingresar";

                    break;


            }










        }



    }
}
