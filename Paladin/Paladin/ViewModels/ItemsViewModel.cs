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
using Paladin.Models;

namespace Paladin.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public Command LoadItemsCommand { get; set; }

        private List<SpellItem> keepItems = new List<SpellItem>();

        private ObservableCollection<SpellItem> _items = new ObservableCollection<SpellItem>();
        public ObservableCollection<SpellItem> Items
        {
            get { return _items; }
            set { _items = value; OnPropertyChanged("Items"); }
        }

        public ICommand PrepareSpellCommand
        {
            get
            {
                return new Command( async (e) =>
                {
                    var spell = (e as SpellItem);
                    var index = Items.IndexOf(spell);
                    spell.Prepared = !spell.Prepared;

                    //=================ТУПЫЕ ГРАБЛИ====================
                    Items.RemoveAt(index);
                    await Task.Delay(1);
                    Items.Insert(index, spell);
                    //=================================================

                    await App.Database.PrepareSpell(spell);

                    //var prepare = spell.Prepared ? "убрать из подготовленных" : "подготовить";
                    //var answer = await App.Current.MainPage.DisplayAlert(
                    //    "Внимание", "Вы действительно хотите " + prepare + " заклинание " + spell.Title + "?", "Да", "Нет");
                    //if (answer)
                    //{
                    //    spell.Prepared = !spell.Prepared;
                    //    await App.Database.PrepareSpell(spell);
                    //}
                });
            }
        }

        public ItemsViewModel()
        {
            Title = "Все заклинания";
            Items = new ObservableCollection<SpellItem>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        private async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await App.Database.GetSpellsList();
                items = keepItems = items.OrderBy(item => item.Level).ThenBy(item => item.Title).ToList();

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

        public void FilterItems(string text)
        {
            Items.Clear();
            keepItems.Where(t => t.Title.ToLower().Contains(text.ToLower())).ToList().ForEach(t => Items.Add(t));
        }
    }
}