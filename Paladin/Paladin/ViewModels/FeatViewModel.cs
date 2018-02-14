﻿using Paladin.Models;
using Paladin.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Paladin.ViewModels
{
    public class FeatViewModel : BaseViewModel
    {
        public class FeatList : ObservableCollection<Feat>, INotifyPropertyChanged
        {
            public string Heading { get; set; }
            public string Description
            {
                get { return description; }
                set { description = value; OnPropertyChanged("Description"); }
            }
            private string description { get; set; }
            public ObservableCollection<Feat> Feats => this;

            public event PropertyChangedEventHandler PropertyChanged;

            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private ObservableCollection<FeatList> _listOfFeats;
        public ObservableCollection<FeatList> ListOfFeats
        {
            get { return _listOfFeats; }
            set { _listOfFeats = value; base.OnPropertyChanged(); }
        }

        public Command LoadItemsCommand { get; set; }
        public ICommand UseFeatCommand { get; }

        public FeatViewModel()
        {
            this.Title = "Способности";
            ListOfFeats = new ObservableCollection<FeatList>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            UseFeatCommand = new Command(async (e) =>
            {
                var feat = (e as Feat);
                try
                {
                    if (feat.TypeTop)
                    {
                        var list = ListOfFeats[2];
                        var descr = list.Description;
                        string[] words = descr.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                        var leftNum = Int32.Parse(words[0]);
                        var rightNum = Int32.Parse(words[1]);

                        ListOfFeats[2].Description = leftNum > 0 ? --leftNum + "/" + rightNum : ListOfFeats[2].Description;
                    }
                    else
                    {
                        var descr = feat.Description;
                        string[] words = descr.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                        var leftNum = Int32.Parse(words[0]);
                        var rightNum = Int32.Parse(words[1]);

                        feat.Description = leftNum > 0 ? --leftNum + "/" + rightNum : feat.Description;
                    }
                }
                catch (Exception exc) { Debug.WriteLine("==== ==== UseFeatCommand: " + exc.Message); }
            });
        }

        private async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                var chars = await App.Database.GetCharactersList();
                var character = chars[0];

                //СЛОТЫ
                var slotList = new FeatList();
                var slots = CreateCharacter.GetClericSlots(character.Level);
                foreach (var slot in slots)
                {
                    slotList.Add(new Feat() { Title = slot.Title, Description = slot.Amount + "/" + slot.Amount });
                }
                slotList.Heading = "Слоты заклинаний (ДО):";

                var domainList = new FeatList()
                {
                    new Feat() { Title = "Гнев бури (реакция)", Description = "4/4", Text = "Кроме того, на 1 уровне вы можете громогласно покарать атакующих. Если существо в пределах 5 футов от вас, которое вы можете видеть, успешно попадает по вам атакой, вы можете реакцией заставить существо совершить спасбросок Ловкости.\n" +
                                "Существо получает урона звуком или электричеством (по вашему выбору) 2к8, если провалит спасбросок, и половину этого урона если преуспеет.\n" +
                                "Вы можете использовать это умение количество раз, равное вашему модификатору Мудрости (минимум 1 раз). Вы восстанавливаете все потраченные применения, когда завершаете продолжительный отдых." },
                    new Feat() { Title = "Удар грома (толчок)", DescriptionVisible = false, Text = "На 6 уровне, когда вы причиняете урон электричеством существу с размером Большое или меньше, вы также можете оттолкнуть его на 10 футов от себя." }
                };
                domainList.Heading = "Домен бури:";

                var clericList = new FeatList()
                {
                    new Feat() { Title = "Изгнание нежити", TypeTop = true },
                    new Feat() { Title = "Разрушительный гнев", TypeTop = true, Text = "Начиная со 2 уровня вы можете использовать Божественный канал, чтобы овладеть могуществом бури с необузданной свирепостью.\n" +
                                "Когда вы совершаете бросок урона звуком или электричеством, вы можете использовать Божественный канал, чтобы причинить максимальный урон вместо броска." }
                };
                clericList.Heading = "Божественный канал (КО):";
                clericList.Description = "2/2";

                var systemFeat = new FeatList()
                {
                    new Feat() { Title = "Стихийный адепт", DescriptionVisible = false, Text = "Когда вы получаете эту черту, выберите один из видов урона: звук, кислота, огонь, холод или электричество.\n" +
                                "Накладываемые вами заклинания игнорируют сопротивление к выбранному виду урона. Кроме того, когда вы определяете урон от наложенного вами заклинания, причиняющего урон этого вида, вы можете считать все выпавшие на костях «1» как «2».\n" +
                                "Вы можете брать эту черту несколько раз. Каждый раз, когда вы это делаете, вы выбираете новый вид урона." }
                };
                systemFeat.Heading = "Черты:";

                var healingList = new FeatList()
                {
                    new Feat() { Title = "Использований: ", Description = character.HitDices + "/" + character.HitDices }
                };
                healingList.Heading = "Кубики хитов (ДО):";

                var list = new ObservableCollection<FeatList>()
                {
                    slotList,
                    domainList,
                    clericList,
                    systemFeat,
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
