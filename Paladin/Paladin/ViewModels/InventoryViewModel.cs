using Paladin.AlertPopup;
using Paladin.Models;
using Paladin.Services;
using Paladin.Views;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Paladin.ViewModels
{
    public class InventoryViewModel : BaseViewModel
    {
        Character character;

        private int gold { get; set; }
        public int Gold
        {
            get { return gold; }
            set { gold = value; OnPropertyChanged("Gold"); }
        }

        public ObservableCollection<Items> Items { get; set; }
        public Command LoadItemsCommand { get; set; }
        public ICommand GoldAddCommand { get; }
        public ICommand GoldRemoveCommand { get; }

        public InventoryViewModel()
        {
            Title = "Инвентарь";

            Items = new ObservableCollection<Items>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            GoldAddCommand = new Command(async (e) =>
            {
                var value = await ExecuteInputPopup("Получено золота");
                Gold += value;
                character.Gold += value;
                await App.Database.GoldUpdate(character);
            });

            GoldRemoveCommand = new Command(async (e) =>
            {
                var value = await ExecuteInputPopup("Потрачено золота");
                Gold -= value;
                character.Gold -= value;
                await App.Database.GoldUpdate(character);
            });

            MessagingCenter.Subscribe<ItemDetailPage>(this, "DeleteItem", async obj =>
            {
                await ExecuteLoadItemsCommand();
            });

            MessagingCenter.Subscribe<ItemAddPage>(this, "AddItem", async obj =>
            {
                await ExecuteLoadItemsCommand();
            });
        }

        private async Task<int> ExecuteInputPopup(string Title)
        {
            var inputView = new TextInputView(Title);
            var popup = new InputAlertDialogBase<int>(inputView);

            inputView.CloseButtonEventHandler +=
                (sender, obj) =>
                {
                    if (((TextInputView)sender).TextInputResult >= 0)
                    {
                        ((TextInputView)sender).IsValidationLabelVisible = false;
                        popup.PageClosedTaskCompletionSource.SetResult(((TextInputView)sender).TextInputResult);
                    }
                    else
                    {
                        ((TextInputView)sender).IsValidationLabelVisible = true;
                    }
                };

            await PopupNavigation.PushAsync(popup);
            var result = await popup.PageClosedTask;
            await PopupNavigation.PopAsync();

            return result;
        }

        async Task ExecuteLoadItemsCommand()
        {
            try
            {
                Items.Clear();
                var items = await App.Database.GetInventoryesList();

                items = items.OrderBy(item => item.Title).ToList();

                foreach (var item in items)
                    Items.Add(item);

                var chars = await App.Database.GetCharactersList();
                character = chars[0];

                Gold = character.Gold;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
