using Paladin.AlertPopup;
using Paladin.Models;
using Paladin.Services;
using Rg.Plugins.Popup.Services;
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
    public class CharacterViewModel : BaseViewModel
    {
        private int MaxHP { get; set; }
        public int maxHP
        {
            get { return MaxHP; }
            set { MaxHP = value; base.OnPropertyChanged(); }
        }

        private int CurrentHP { get; set; }
        public int currentHP
        {
            get { return CurrentHP; }
            set { CurrentHP = value; base.OnPropertyChanged(); }
        }

        private int TemporaryHP { get; set; } = 0;
        public int temporaryHP
        {
            get { return TemporaryHP; }
            set { TemporaryHP = value; base.OnPropertyChanged(); }
        }        

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

        public ICommand ShieldCommand { get; }
        public ICommand HealCommand { get; }
        public ICommand DamageCommand { get; }

        public ICommand UseFeatCommand
        {
            get
            {
                return new Command(async (e) =>
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
        }

        public CharacterViewModel()
        {
            ListOfFeats = new ObservableCollection<FeatList>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ShieldCommand = new Command(async (e) => 
            {
                temporaryHP += await ExecuteInputPopup("Получено временных хит поинтов");
            });

            HealCommand = new Command(async (e) =>
            {
                currentHP += await ExecuteInputPopup("Вылечено хит поинтов");
                if (currentHP > maxHP) currentHP = maxHP;
            });

            DamageCommand = new Command(async (e) =>
            {
                var damage = await ExecuteInputPopup("Получено урона");

                if (temporaryHP > 0)
                {
                    if (temporaryHP > damage)
                        temporaryHP -= damage;
                    else
                    {
                        currentHP -= damage - temporaryHP;
                        temporaryHP = 0;
                    }                        
                }
                else
                    currentHP -= damage;
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

        private async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                var chars = await App.Database.GetCharactersList();
                var character = chars[0];

                this.Title = character.Name + ", " + character.Level + " ур.";
                currentHP = maxHP = character.HP;

                //СЛОТЫ
                var slotList = new FeatList();
                var slots = CreateCharacter.GetClericSlots(character.Level);
                foreach (var slot in slots)
                {
                    slotList.Add(new Feat() { Title = slot.Title, Description = slot.Amount + "/" + slot.Amount });
                }                
                slotList.Heading = "Слоты заклинаний:";

                var domainList = new FeatList()
                {
                    new Feat() { Title = "Гнев бури (реакция), спас Ловк. 2к8/пол.", Description = "4/4" },
                    new Feat() { Title = "Удар грома, толчок 10 футов", DescriptionVisible = false }
                };
                domainList.Heading = "Домен бури:";

                var clericList = new FeatList()
                {
                    new Feat() { Title = "Изгнание нежити", TypeTop = true },
                    new Feat() { Title = "Разрушительный гнев", TypeTop = true }
                };
                clericList.Heading = "Божественный канал:";
                clericList.Description = "2/2";

                var healingList = new FeatList()
                {
                    new Feat() { Title = "Использований: ", Description = character.HitDices + "/" + character.HitDices }
                };
                healingList.Heading = "Кубики хитов:";

                var list = new ObservableCollection<FeatList>()
                {
                    slotList,
                    domainList,
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
