using Paladin.ViewModels;
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
	public partial class ItemDetailPage : ContentPage
	{
        ItemDetailViewModel viewModel;

        public ItemDetailPage (ItemDetailViewModel viewModel)
		{
			InitializeComponent ();

            BindingContext = this.viewModel = viewModel;
        }

        async void OnClick(object sender, EventArgs e)
        {
            DeleteButton.IsEnabled = false;
            var item = viewModel.Item;
            if (item == null) return;

            await App.Database.DeleteItem(item);
            MessagingCenter.Send(this, "DeleteItem");
            await Navigation.PopAsync();
        }
    }
}