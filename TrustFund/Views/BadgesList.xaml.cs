using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using TrustFund.Models_;
using Xamarin.Forms;

namespace TrustFund
{
    public partial class BadgesList : ContentPage
    {
        public BadgesList()
        {
            InitializeComponent();
        }



        protected async override void OnAppearing()
        {

            base.OnAppearing();
            Cator.IsVisible = true;
            Cator.IsRunning = true;
            Console.WriteLine("----------------------------------------------_____:HELP");
            var uri = "https://trustfundapp.herokuapp.com/medallas";

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

                    xlabel.Text = "error 500";
                    Cator.IsVisible = false;
                    break;


                case System.Net.HttpStatusCode.OK:
                    Console.WriteLine("----------------------------------------------_____:Here status 200");

                    ylabel.Text = "Medallas";
                    HttpContent content = response.Content;
                    string xjson = await content.ReadAsStringAsync();



                    var json = JsonConvert.DeserializeObject<List<Badge>>(xjson);


                    try
                    {
                        ListBadges.ItemsSource = json;
                    }
                    catch (Exception ex)
                    {
                        await DisplayAlert("", "" + ex.ToString(), "ok");
                        return;
                    }


                    Cator.IsVisible = false;

                    break;

            }


        }


        public async void OnSelected(object obj, ItemTappedEventArgs args)
        {
            var badge = args.Item as Badge;
            try
            {
                //await DisplayAlert("You selected", orden.orden + " " + orden.idOrden,"ok");
                int ID = badge.id;

                await Navigation.PushAsync(new BadgeInfoPAge(ID));

            }
            catch (Exception ex)
            {
                await DisplayAlert("", ex.ToString(), "");
                return;
            }
        }
    }
}
