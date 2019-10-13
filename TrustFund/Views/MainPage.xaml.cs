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

namespace TrustFund
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {


        public UserDataBase userDataBase;

       

        //[Obsolete]
        public MainPage()
        {
            InitializeComponent();

            userDataBase = new UserDataBase();
            var user_exist = userDataBase.GetMembers();
            int RowCount = 0;
            int usercount = user_exist.Count();
            RowCount = Convert.ToInt32(usercount);

            if (RowCount > 0)
            {
                var userLite = user_exist.First();
                var id = userLite.id;
                CallDataTCUser(id);

            }
            else
            {
                Application.Current.MainPage =
                new Views.SignInPage();
            }


            //listMembers.ItemsSource = members;

        }

      
        public object NavigationItem { get; private set; }

        private async void  CallDataTCUser(int id)
        {


            HttpClient client = new HttpClient();

            var response = await client.GetAsync
                ("https://trustfundapp.herokuapp.com/get-user/"+id);

            switch (response.StatusCode) {

                case (System.Net.HttpStatusCode.OK):

                    Msn.Text = "Datos recibidos con éxito";

                    string xjson = await response.Content.ReadAsStringAsync();

                    var json_ = JsonConvert.DeserializeObject<User_Info>(xjson);
                    ImgProfile.Source = json_.img;
                    UserNamelb.Text = json_.username;

                    break;
                default:
                    Msn.Text = "Hudo algun error";
                    break;

            }


        }


        // HAndle Navigation
        public async  void Handle_Clicked_PushMedallas(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new BadgesList());

        }
        public async void Handle_Clicked_PushPlans(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new PlansPage());

        }

        public async void Handle_Clicked_PushNoticias(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new NewsPage());
        }

        public async void Handle_Clicked_PushProjects(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new ProjectsListPage());
        }


        public async void  Handle_Clicked_PushUnidades(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new Units());

        }

        public async void Handle_Clicked_PushConfig(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new ConfigPage());
        }
    }
}
