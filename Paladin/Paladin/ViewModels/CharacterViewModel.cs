using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Paladin.ViewModels
{
    public class CharacterViewModel : BaseViewModel
    {
        public class Feat
        {
            public string Title { get; set; }
            public string Decription { get; set; }
        }

        public class FeatList : List<Feat>
        {
            public string Heading { get; set; }
            public List<Feat> Persons => this;
        }

        private List<FeatList> _listOfFeats;
        public List<FeatList> ListOfFeats
        {
            get { return _listOfFeats; }
            set { _listOfFeats = value; base.OnPropertyChanged(); }
        }

        public Command LoadItemsCommand { get; set; }

        public CharacterViewModel()
        {
            Title = "Гунтер Громобород";
            ListOfFeats = new List<FeatList>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        private async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                //========================================================
                //============Прикрутить=загрузку=из=базы=================
                //========================================================

                var slotList = new FeatList()
                {
                    new Feat() { Title = "Слоты 1:", Decription = "4/4" },
                    new Feat() { Title = "Слоты 2:", Decription = "3/3" },
                    new Feat() { Title = "Слоты 3:", Decription = "3/3" }
                };
                slotList.Heading = "Слоты заклинаний:";

                var clericList = new FeatList()
                {
                    new Feat() { Title = "Канал света", Decription = "2/2" }
                };
                clericList.Heading = "Классовые способности:";

                var healingList = new FeatList()
                {
                    new Feat() { Title = "Использований: ", Decription = "6/6" }
                };
                healingList.Heading = "Кубы восстановления:";

                var list = new List<FeatList>()
                {
                    slotList,
                    clericList,
                    healingList
                };

                ListOfFeats = list;
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
