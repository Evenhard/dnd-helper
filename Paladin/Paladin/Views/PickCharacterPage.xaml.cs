using Paladin.Models;
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
	public partial class PickCharacterPage : ContentPage
	{
        PickCharacterViewModel viewModel;

        public PickCharacterPage ()
		{
			InitializeComponent ();

            BindingContext = viewModel = new PickCharacterViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Character;
            ItemsListView.SelectedItem = null;

            if (item == null) return;

            //await Navigation.PushAsync(new SpellDetailPage(new SpellDetailViewModel(item)));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }

    }
}