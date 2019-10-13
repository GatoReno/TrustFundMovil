using System;

using Xamarin.Forms;

namespace TrustFund
{
    public class CardInfoPage : ContentPage
    {
        public CardInfoPage()
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

