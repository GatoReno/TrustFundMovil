using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using TrustFund.Models_;
using Xamarin.Forms;

namespace TrustFund
{
    public partial class PlanInfo : ContentPage
    {
        public PlanInfo(string ID)
        {
            InitializeComponent();
            CallDataProject(ID);
        }


        private async void CallDataProject(string id) {

        HttpClient client = new HttpClient();

        var response = await client.GetAsync
            ("https://trustfundapp.herokuapp.com/plan-json/" + id);

            switch (response.StatusCode)
            {

                case (System.Net.HttpStatusCode.OK):

                    // Msn.Text = "Datos recibidos con éxito";


                    string xjson = await response.Content.ReadAsStringAsync();
                    //<List<ProjectInfoJson>>
                    var json_ = JsonConvert.DeserializeObject<PlanInfo>(xjson);


                    // Lx1.Text = json_.

                    // Lx2.Text = "$ "+ json_.amount + " "+json_.currency;

                    //Lx3.Text = "Al finalaziar : "+json_.status_after_retry;   
                    //Lx4.Text = ""+json_.repeat_every+ "" +json_.repeat_unit;
                    //ImgProfile.Source = json_.img;
                    // UserNamelb.Text = json_.username;

                    break;
                default:
                   // Msn.Text = "Hudo algun error";
                    break;

            }





}

    }
}
