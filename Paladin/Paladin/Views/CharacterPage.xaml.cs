using Paladin.Models;
using Paladin.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Paladin.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CharacterPage : ContentPage
	{
        CharacterViewModel viewModel;

        public CharacterPage ()
		{
			InitializeComponent ();
            BindingContext = viewModel = new CharacterViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            //var item = args.SelectedItem as Feat;
            ItemsListView.SelectedItem = null;

            //if (item == null) return;

            //await viewModel.UseFeat(item);
        }

        public void Toolbar1Clicked(object sender, EventArgs args)
        {
            
        }

        public void Toolbar2Clicked(object sender, EventArgs args)
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