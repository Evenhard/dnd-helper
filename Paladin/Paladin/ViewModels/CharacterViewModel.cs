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
        
        public Command LoadItemsCommand { get; set; }

        public ICommand ShieldCommand { get; }
        public ICommand HealCommand { get; }
        public ICommand DamageCommand { get; }

        

        public CharacterViewModel()
        {            
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
