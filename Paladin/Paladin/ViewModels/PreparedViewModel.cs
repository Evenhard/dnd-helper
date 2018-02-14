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
        
        private int Prepared { get; set; }
        private int PreparedMax { get; set; }

        private string preparedStr { get; set; }
        public string PreparedStr
        {
            get { return preparedStr; }
            set { preparedStr = value; base.OnPropertyChanged(); }
        }

        public PreparedViewModel()
        {
            Title = "Заклинания";
            Items = new ObservableCollection<SpellItem>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<SpellsViewModel>(this, "PrepareSpell", (sender) => {
                LoadItemsCommand.Execute(null);
            });
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
                    if (item.Level <= 2)
                    Items.Add(item);
                }

                if (Items.Count > 0)
                    CountPreparedSpells(Items);
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

        public async void CountPreparedSpells(ObservableCollection<SpellItem> Items)
        {
            var chars = await App.Database.GetCharactersList();
            var character = chars[0];

            Prepared = 0;
            PreparedMax = character.Level + character.StatWis;

            foreach (var item in Items)
                if (item.Prepared && !item.ClassSpell && item.Level > 0) Prepared++;

            PreparedStr = Prepared + "/" + PreparedMax;
        }
    }
}
