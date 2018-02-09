using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Paladin.ViewModels;
using Paladin.Services;
using System.Diagnostics;
using Paladin.Models;

namespace Paladin.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ItemDetailPage : ContentPage
	{
        ItemDetailViewModel viewModel;

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }
    }
}