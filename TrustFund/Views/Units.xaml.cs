using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using TrustFund.Classes_;
using TrustFund.Models_;
using Xamarin.Forms;

namespace TrustFund
{
    public partial class Units : TabbedPage
    {

        public UserDataBase userDataBase;

        public Units()
            {
                InitializeComponent();
                NavigationPage.SetHasBackButton(this, true);
            }


        protected async override void OnAppearing() {


            base.OnAppearing();
            BuyUnitsIndiCator.IsVisible = true;
            BuyUnitsIndiCator.IsRunning = true;
            Console.WriteLine("----------------------------------------------_____:HELP");
            var id_client =""; 



            var uri = "https://trustfundapp.herokuapp.com/tc-list";

            var request = new HttpRequestMessage();
            request.RequestUri = new Uri(uri);

            request.Method = HttpMethod.Get;

            var client = new HttpClient();
            // client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(tok_ty, acc_tok);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.SendAsync(request);




            switch (response.StatusCode)
            {
                case System.Net.HttpStatusCode.InternalServerError:
                    Console.WriteLine("----------------------------------------------_____:Here status 500");

                    LabelMsn.Text = "error 500";
                    BuyUnitsIndiCator.IsVisible = false;
                    break;


                case System.Net.HttpStatusCode.OK:
                    Console.WriteLine("----------------------------------------------_____:Here status 200");

                    LabelMsn.Text = "Unidades Disponibles";
                    HttpContent content = response.Content;
                    string xjson = await content.ReadAsStringAsync();



                    var json = JsonConvert.DeserializeObject<List<UnitTC>>(xjson);
                    // xlabel.Text = myobject.ToString();


                    try
                    {
                        ListTc.ItemsSource = json;
                    }
                    catch (Exception ex)
                    {
                        await DisplayAlert("", "" + ex.ToString(), "ok");
                        return;
                    }


                    BuyUnitsIndiCator.IsVisible = false;



                    break;

            }


            //call user data



            userDataBase = new UserDataBase();
            var user_exist = userDataBase.GetMembers();
            int RowCount = 0;
            int usercount = user_exist.Count();
            RowCount = Convert.ToInt32(usercount);

            if (RowCount > 0)
            {
                var userLite = user_exist.First();
                var id = userLite.id;



                var response_user = await client.GetAsync
                    ("https://trustfundapp.herokuapp.com/get-user/" + id);

                switch (response.StatusCode)
                {

                    case (System.Net.HttpStatusCode.OK):


                        string xjson = await response_user.Content.ReadAsStringAsync();

                        var json_user = JsonConvert.DeserializeObject<User_Info>(xjson);

                        id_client = json_user.id_client;
                        break;
                    default:
                        LabelMsn.Text = "Hudo algun error con los datos de usuario";
                        break;

                }
            }
            else
            {
                Application.Current.MainPage = new Views.SignInPage();
            }

            //call user units


            var uriUnits = "https://trustfundapp.herokuapp.com/tc-info-client/" + id_client;
            var respStatusUnits = await client.GetAsync(uriUnits);

            string xjson_unitsStatus = await respStatusUnits.Content.ReadAsStringAsync();

            var json_ = JsonConvert.DeserializeObject<List<Tc_info_client>>(xjson_unitsStatus);

            var UnitsStatus = json_.First();

            StatusUnits.Text = "Stats: "+ UnitsStatus.descrip;
            TotalUnits.Text = "Unidades Disponibles:"+ UnitsStatus.total_units;
            TotalAmount.Text = "Credito:" + UnitsStatus.total;


            //tc_info_client


        }



        async void OnSelected(object obj, ItemTappedEventArgs args)
        {
            var plan_ = args.Item as Plan;
            string ID = plan_.id;

            try
            {
                //await DisplayAlert("You selected", orden.orden + " " + orden.idOrden,"ok");
                ;

                await Navigation.PushAsync(new PlanInfo(ID));

            }
            catch (Exception ex)
            {
                await DisplayAlert("", ex.ToString(), "");
                return;
            }

        }



        public async void OnSelected_buyUnit(object obj, ItemTappedEventArgs args)
        {
            var unit = args.Item as UnitTC;
            try
            {
                //await DisplayAlert("You selected", orden.orden + " " + orden.idOrden,"ok");
                    int ID = unit.id;

                    await Navigation.PushAsync(new BuyUnitPage(ID));

            }
            catch (Exception ex)
            {
                await DisplayAlert("", ex.ToString(), "");
                return;
            }
        }


    }
}
