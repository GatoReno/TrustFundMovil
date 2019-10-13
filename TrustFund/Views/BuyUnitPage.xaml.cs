using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using Openpay.Xamarin;
using TrustFund.Models_;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace TrustFund
{
    public partial class BuyUnitPage : ContentPage
    {
        public BuyUnitPage(int id)
        {
            InitializeComponent();
            GetUnitData(id);

        }

        private async void GetUnitData(int id) {



            HttpClient client = new HttpClient();

            var response = await client.GetAsync
                ("https://trustfundapp.herokuapp.com/tc-info/" + id);

            switch (response.StatusCode) {

                case (System.Net.HttpStatusCode.OK):

                    // Msn.Text = "Datos recibidos con éxito";

                    string xjson = await response.Content.ReadAsStringAsync();
                    //<List<ProjectInfoJson>>
                    var json_ = JsonConvert.DeserializeObject<List<UnitTC>>(xjson);

                    Imgx1.Source = json_[0].img;
                    lbx1.Text = json_[0].name;
                    lbx2.Text = json_[0].desc;
                    lbx3.Text = "$ "+json_[0].amount+" MX";

                    BuyUnitsIndiCator.IsRunning = false;
                    BuyUnitsIndiCator.IsVisible = false;

                    break;

            }

            lbl1.Text = "hubo un error";

        }


        async void Handle_Clicked_BuyUnit(object sender, System.EventArgs e)
        {
            //var id = xId.Text;
            var uri = "https://trustfundapp.herokuapp.com/api/login/";


            var forminfo = "";
            HttpClient client = new HttpClient();

            var response = await client.PostAsync(uri, null);

            switch (response.StatusCode)
            {

                case (System.Net.HttpStatusCode.OK):

                    // Msn.Text = "Datos recibidos con éxito";

                    string xjson = await response.Content.ReadAsStringAsync();
                    //<List<ProjectInfoJson>>
                    var json_ = JsonConvert.DeserializeObject<TokenSecret>(xjson);


                    var urix = "https://trustfundapp.herokuapp.com/api/login/"+json_.token;
                    await Browser.OpenAsync(urix, BrowserLaunchMode.SystemPreferred);

                    break;

                case (System.Net.HttpStatusCode.InternalServerError):

                    break;

            }

            //



        }

    }
}
