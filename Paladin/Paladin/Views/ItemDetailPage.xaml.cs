using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Paladin.ViewModels;
using Paladin.Services;
using System.Diagnostics;

namespace Paladin.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ItemDetailPage : ContentPage
	{
        public SpellItem item { get; set; }

        ItemDetailViewModel viewModel;

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public ItemDetailPage(SpellItem item)
        {
            InitializeComponent();

            item = new SpellItem
            {
                Title = "ЧТО это?",
                Description = "Описаниеыыы"
            };
            
            BindingContext = viewModel = new ItemDetailViewModel(item);
        }

    }
}