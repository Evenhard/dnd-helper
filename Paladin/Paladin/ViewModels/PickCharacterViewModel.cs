using Paladin.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Paladin.ViewModels
{
    public class PickCharacterViewModel : BaseViewModel
    {
        public Command LoadItemsCommand { get; set; }

        private ObservableCollection<Character> _items = new ObservableCollection<Character>();
        public ObservableCollection<Character> Items
        {
            get { return _items; }
            set { _items = value; OnPropertyChanged("Items"); }
        }

        public PickCharacterViewModel()
        {
            Title = "Выбор персонажа";
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
                var items = await App.Database.GetCharactersList();

                foreach (var item in items)
                    Items.Add(item);
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
