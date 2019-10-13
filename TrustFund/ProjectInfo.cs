using System;

using Xamarin.Forms;

namespace TrustFund
{
    public class ProjectInfo : ContentPage
    {
        public ProjectInfo()
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

