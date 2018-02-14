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
	public partial class FeatPage : ContentPage
	{
        FeatViewModel viewModel;

        public FeatPage ()
		{
			InitializeComponent ();
            BindingContext = viewModel = new FeatViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Feat;
            ItemsListView.SelectedItem = null;

            if (item == null) return;

            if (!string.IsNullOrEmpty(item.Text))
                await Navigation.PushAsync(new FeatDetailPage(new FeatDetailViewModel(item)));
        }

        public void ToolbarClicked(object sender, EventArgs args)
        {
            viewModel.LoadItemsCommand.Execute(null);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.ListOfFeats.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }

    }
}