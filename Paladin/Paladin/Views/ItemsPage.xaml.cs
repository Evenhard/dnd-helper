using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Paladin.Views;
using Paladin.ViewModels;
using Paladin.Services;
using System.Windows.Input;
using System.Diagnostics;
using Paladin.Models;

namespace Paladin.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ItemsPage : ContentPage
	{
        ItemsViewModel viewModel;        

        public ItemsPage()
        {
            InitializeComponent();

            Search.TextChanged += (sender, e) => {
                viewModel.FilterItems(Search.Text);
            };

            BindingContext = viewModel = new ItemsViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as SpellItem;
            ItemsListView.SelectedItem = null;

            if (item == null) return;

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));
        }

        public void ToolbarClicked(object sender, EventArgs args)
        {
            Search.IsVisible = !Search.IsVisible;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}