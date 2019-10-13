using System;

using Xamarin.Forms;

namespace TrustFund
{
    public class BuyUnitsPage : ContentPage
    {
        public BuyUnitsPage()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

