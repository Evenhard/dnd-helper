using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using Paladin.Views;
using Paladin.Services;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace Paladin.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<SpellItem> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ICommand PrepareSpellCommand
        {
            get
            {
                return new Command( async (e) =>
                {
                    var spell = (e as SpellItem);

                    var prepare = spell.Prepared ? "убрать из подготовленных" : "подготовить";
                    var answer = await App.Current.MainPage.DisplayAlert(
                        "Внимание", "Вы действительно хотите " + prepare + " заклинание " + spell.Title + "?", "Да", "Нет");
                    if (answer)
                    {
                        spell.Prepared = !spell.Prepared;
                        await App.Database.PrepareSpellAsync(spell);
                    }                    
                });
            }
        }

        public ItemsViewModel()
        {
            Title = "Заклинания";
            Items = new ObservableCollection<SpellItem>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await App.Database.GetSpellsAsync();
                items = items.OrderByDescending(item => item.Prepared).ThenBy(item => item.Level).ThenBy(item => item.Title).ToList();

                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}