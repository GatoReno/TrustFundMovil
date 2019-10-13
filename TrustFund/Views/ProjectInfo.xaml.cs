using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using TrustFund.Models_;
using Xamarin.Essentials;
using Xamarin.Forms;


namespace TrustFund
{
    public partial class ProjectInfo : ContentPage
    {
        public ProjectInfo(int ID)
        {
            InitializeComponent();

            CallDataProject(ID);

                        
        }



    private async void CallDataProject(int id) {

            HttpClient client = new HttpClient();

            var response = await client.GetAsync
                ("https://trustfundapp.herokuapp.com/projects/get/"+id);

            switch (response.StatusCode)
            {

                case (System.Net.HttpStatusCode.OK):

                   // Msn.Text = "Datos recibidos con éxito";

                    string xjson = await response.Content.ReadAsStringAsync();

                    var json_ = JsonConvert.DeserializeObject<List<ProjectInfoJson>>(xjson);

                    ImgProject.Source = json_[0].img;
                    xTitle.Text = json_[0].title;
                    xDescription.Text = json_[0].description;
                    var stringId = json_[0].id;
                    var idproject = stringId.ToString();
                    xId.Text = idproject;

                   //ImgProfile.Source = json_.img;
                   // UserNamelb.Text = json_.username;

                    break;
                default:
                   // Msn.Text = "Hudo algun error";
                    break;

            }



           

        }

        async void Handle_Clicked_OpenUrl(object sender, System.EventArgs e)
        {
            var id = xId.Text;
            var uri = "https://trustfundapp.herokuapp.com/projects/get-project/" + id;
            await Browser.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
        }

    }
}
