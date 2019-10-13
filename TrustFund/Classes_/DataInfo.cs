using System;

using Xamarin.Forms;

namespace TrustFund.Classes_
{
    public class DataInfo : ContentPage
    {
        public DataInfo()
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

