﻿using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Paladin.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AboutPage : ContentPage
	{
		public AboutPage ()
		{
			InitializeComponent ();
		}

        public async void ButtonClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new PickCharacterPage());
        }
    }
}