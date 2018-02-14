using Paladin.Services;
using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace Paladin.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public ICommand CreateClericCommand { get; }
        public ICommand CreateInventoryCommand { get; }
        public ICommand DropBaseCommand { get; }

        public ICommand FillBaseCommand { get; }
        public ICommand FillTempestCommand { get; }
        public ICommand FillForgeCommand { get; }

        public ICommand FillPaladinCommand { get; }
        public ICommand FillXGTECommand { get; }

        public AboutViewModel()
        {
            Title = "Настройки";

            FillPaladinCommand = new Command(async () => 
            {
                await PaladinSpells.FillSpells();
                await PaladinSpells.FillVengeanceSpells();
            });
            FillXGTECommand = new Command(async () => await PaladinSpells.FillXGTESpells());

            FillBaseCommand = new Command(async() => await ClericSpells.FillSpells());
            FillForgeCommand = new Command(async () => await ClericSpells.FillForge());
            FillTempestCommand = new Command(async () => await ClericSpells.FillTempest());

            DropBaseCommand = new Command(async () => await App.Database.ClearSpellBase());
            CreateClericCommand = new Command(async () => await CreateCharacter.NewCleric());
            CreateInventoryCommand = new Command(async () => await CreateInventory.NewInventory());
        }

    }
}