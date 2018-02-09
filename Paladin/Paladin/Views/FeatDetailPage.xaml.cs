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
	public partial class FeatDetailPage : ContentPage
	{
        FeatDetailViewModel viewModel; 

		public FeatDetailPage (FeatDetailViewModel viewModel)
		{
			InitializeComponent ();

            BindingContext = this.viewModel = viewModel;
        }
	}
}