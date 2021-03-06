﻿using Paladin.Models;
using Paladin.Services;
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
	public partial class PreparedPage : ContentPage
	{
        PreparedViewModel viewModel;

        public PreparedPage ()
		{
			InitializeComponent ();

            BindingContext = viewModel = new PreparedViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as SpellItem;
            if (item == null)
                return;

            await Navigation.PushAsync(new SpellDetailPage(new SpellDetailViewModel(item)));

            // Manually deselect item
            ItemsListView.SelectedItem = null;
        }

        public async void ToolbarClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new SpellsPage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }

    }
}