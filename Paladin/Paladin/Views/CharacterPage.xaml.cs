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
	public partial class CharacterPage : ContentPage
	{
        CharacterViewModel viewModel;

        public CharacterPage ()
		{
			InitializeComponent ();
            BindingContext = viewModel = new CharacterViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.ListOfFeats.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}