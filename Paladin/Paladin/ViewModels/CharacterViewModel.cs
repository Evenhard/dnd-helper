using Paladin.AlertPopup;
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

        public class Feat
        {
            public string Title { get; set; }
            public string Decription { get; set; }
        }

        public class FeatList : List<Feat>
        {
            public string Heading { get; set; }
            public List<Feat> Feats => this;
        }

        private List<FeatList> _listOfFeats;
        public List<FeatList> ListOfFeats
        {
            get { return _listOfFeats; }
            set { _listOfFeats = value; base.OnPropertyChanged(); }
        }

        public Command LoadItemsCommand { get; set; }

        public ICommand ShieldCommand { get; }
        public ICommand HealCommand { get; }
        public ICommand DamageCommand { get; }

        public CharacterViewModel()
        {
            Title = "Гунтер Громобород";
            ListOfFeats = new List<FeatList>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ShieldCommand = new Command(async (e) => 
            {
                temporaryHP += await ExecuteInputPopup("Получено временных хит поинтов:");
            });

            HealCommand = new Command(async (e) =>
            {
                currentHP += await ExecuteInputPopup("Вылечено хит поинтов:");
            });

            DamageCommand = new Command(async (e) =>
            {
                var damage = await ExecuteInputPopup("Получено урона:");

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
                    if (((TextInputView)sender).TextInputResult != 0)
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
                //========================================================
                //============Прикрутить=загрузку=из=базы=================
                //========================================================

                try
                {
                    var character = await App.Database.GetClericGunter();
                }
                catch (Exception e) { Debug.WriteLine("==== ==== Создание Гунтера: " + e.Message); }

                currentHP = MaxHP = 75;

                var slotList = new FeatList()
                {
                    new Feat() { Title = "Слоты 1:", Decription = "4/4" },
                    new Feat() { Title = "Слоты 2:", Decription = "3/3" },
                    new Feat() { Title = "Слоты 3:", Decription = "3/3" }
                };
                slotList.Heading = "Слоты заклинаний:";

                var clericList = new FeatList()
                {
                    new Feat() { Title = "Изгнание нежити", Decription = "2/2" },
                    new Feat() { Title = "Разрушительный гнев", Decription = "2/2" }
                };
                clericList.Heading = "Божественный канал:";

                var domainList = new FeatList()
                {
                    new Feat() { Title = "Гнев бури (реакция), спас Ловк. 2к8/пол.", Decription = "Муд." },
                    new Feat() { Title = "Удар грома, толчок 10 футов", Decription = "-" }
                };
                domainList.Heading = "Домен бури:";

                var healingList = new FeatList()
                {
                    new Feat() { Title = "Использований: ", Decription = "6/6" }
                };
                healingList.Heading = "Кубы восстановления:";

                var list = new List<FeatList>()
                {
                    slotList,
                    clericList,
                    domainList,
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
