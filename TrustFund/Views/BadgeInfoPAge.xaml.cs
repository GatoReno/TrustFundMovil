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
    public partial class BadgeInfoPAge : ContentPage
    {
        public BadgeInfoPAge(int id)
        {
            InitializeComponent();
            CallDataBadge(id);
        }

        private async void CallDataBadge(int id)
        {

            HttpClient client = new HttpClient();

            var response = await client.GetAsync
                ("https://trustfundapp.herokuapp.com/badgeJson/" + id);

            switch (response.StatusCode)
            {

                case (System.Net.HttpStatusCode.OK):

                    // Msn.Text = "Datos recibidos con éxito";

                    string xjson = await response.Content.ReadAsStringAsync();

                    var json_ = JsonConvert.DeserializeObject<BadgeL>(xjson);

                    var x = json_;

                    Imgx1.Source = x.badge[0].img;
                    Lx1.Text = x.badge[0].desc;
                    Lx2.Text = ""+x.badge[0].id;
                    Lx3.Text = ""+x.badge[0].created_at;
                    
                    // UserNamelb.Text = json_.username;

                    break;
                default:
                    // Msn.Text = "Hudo algun error";
                    break;

            }





        }
    }
}
