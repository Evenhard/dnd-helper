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
        public ICommand CreateClericCommand { get; }

        public AboutViewModel()
        {
            Title = "Настройки";

            FillBaseCommand = new Command(async() => await ClericSpells.FillDataBase());
            DropBaseCommand = new Command(async () => await App.Database.ClearSpellBase());
            CreateClericCommand = new Command(async () => await CreateCharacter.NewCleric());
        }

    }
}