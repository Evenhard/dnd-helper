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
	public partial class SpellDetailPage : ContentPage
	{
        SpellDetailViewModel viewModel;

        public SpellDetailPage(SpellDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }
    }
}