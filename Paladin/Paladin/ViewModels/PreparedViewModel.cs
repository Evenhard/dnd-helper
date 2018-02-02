using Paladin.Models;
using Paladin.Services;
using Paladin.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Paladin.ViewModels
{
    public class PreparedViewModel : BaseViewModel
    {
        public ObservableCollection<SpellItem> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public PreparedViewModel()
        {
            Title = "Подготовленные заклинания";
            Items = new ObservableCollection<SpellItem>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            //MessagingCenter.Subscribe<ItemDetailPage, SpellItem>(this, "Подготовить", (obj, item) =>
            //{
            //    var _item = item as SpellItem;
            //    Items.Add(_item);
            //});
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await App.Database.GetPreparedSpellsList();
                items = items.OrderBy(item => item.Level).ThenBy(item => item.Title).ToList();

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
