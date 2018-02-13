using Paladin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Paladin.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ItemAddPage : ContentPage
	{
		public ItemAddPage ()
		{
			InitializeComponent ();
		}

        async void OnClick(object sender, EventArgs e)
        {
            SaveButton.IsEnabled = false;

            Int32.TryParse(PriceEntry.Text, out var price);
            Int32.TryParse(WeightEntry.Text, out var weight);

            var item = new Items
            {
                Title = NameEntry.Text,
                Price = price,
                Weight = weight,
                Description = DescriptionEditor.Text
            };

            await App.Database.AddItem(item);
            MessagingCenter.Send(this, "AddItem");
            await Navigation.PopAsync();
        }
    }
}