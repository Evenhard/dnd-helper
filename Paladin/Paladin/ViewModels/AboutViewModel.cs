using Paladin.Services;
using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace Paladin.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public ICommand FillBaseCommand { get; }
        public ICommand DropBaseCommand { get; }

        public AboutViewModel()
        {
            Title = "Настройки";

            FillBaseCommand = new Command(async() => await ClericSpells.FillDataBase());
            DropBaseCommand = new Command(async () => await App.Database.ClearSpellBase());
        }

    }
}