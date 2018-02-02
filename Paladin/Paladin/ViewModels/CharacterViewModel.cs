using Paladin.AlertPopup;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
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
        public ICommand InputPopupCommand { get; }

        public CharacterViewModel()
        {
            Title = "Гунтер Громобород";
            ListOfFeats = new List<FeatList>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            InputPopupCommand = new Command(async (e) => 
            {
                var result = await ExecuteInputPopup();
                Debug.WriteLine("**** ****: " + result);
            } );
        }

        private async Task<string> ExecuteInputPopup()
        {
            // create the TextInputView
            var inputView = new TextInputView(
                "Введите значение:", 
                "Введите текст...",
                "Поле ввода не должно быть пустым!",
                "Ок");

            // create the Transparent Popup Page
            // of type string since we need a string return
            var popup = new InputAlertDialogBase<string>(inputView);

            // subscribe to the TextInputView's Button click event
            inputView.CloseButtonEventHandler +=
                (sender, obj) =>
                {
                    if (!string.IsNullOrEmpty(((TextInputView)sender).TextInputResult))
                    {
                        ((TextInputView)sender).IsValidationLabelVisible = false;

                        // update the page completion source
                        popup.PageClosedTaskCompletionSource.SetResult(((TextInputView)sender).TextInputResult);
                    }
                    else
                    {
                        ((TextInputView)sender).IsValidationLabelVisible = true;
                    }
                };

            // Push the page to Navigation Stack
            await PopupNavigation.PushAsync(popup);

            // await for the user to enter the text input
            var result = await popup.PageClosedTask;

            // Pop the page from Navigation Stack
            await PopupNavigation.PopAsync();

            // return user inserted text value
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
