using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace LoginFacebookV2
{
    public partial class Profile : ContentPage
    {
        public Profile(string message)
        {
            InitializeComponent();
            this.lblMessage.Text = message;
        }
    }
}
