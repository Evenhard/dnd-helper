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
        Character character;
        private int BonusMaster { get; } = 3;

        private string atackBonus { get; set; }
        public string AtackBonus
        {
            get { return atackBonus; }
            set { atackBonus = value; base.OnPropertyChanged(); }
        }

        private string damageBonus { get; set; }
        public string DamageBonus
        {
            get { return damageBonus; }
            set { damageBonus = value; base.OnPropertyChanged(); }
        }

        private int spasCon { get; set; }
        public int SpasCon
        {
            get { return spasCon; }
            set { spasCon = value; base.OnPropertyChanged(); }
        }

        private int spasWis { get; set; }
        public int SpasWis
        {
            get { return spasWis; }
            set { spasWis = value; base.OnPropertyChanged(); }
        }

        private int spasCha { get; set; }
        public int SpasCha
        {
            get { return spasCha; }
            set { spasCha = value; base.OnPropertyChanged(); }
        }

        private int skillZapug { get; set; }
        public int SkillZapug
        {
            get { return skillZapug; }
            set { skillZapug = value; base.OnPropertyChanged(); }
        }

        private int skillVnim { get; set; }
        public int SkillVnim
        {
            get { return skillVnim; }
            set { skillVnim = value; base.OnPropertyChanged(); }
        }

        private int skillAtlet { get; set; }
        public int SkillAtlet
        {
            get { return skillAtlet; }
            set { skillAtlet = value; base.OnPropertyChanged(); }
        }

        private int skillUbejd { get; set; }
        public int SkillUbejd
        {
            get { return skillUbejd; }
            set { skillUbejd = value; base.OnPropertyChanged(); }
        }

        private int skillPronic { get; set; }
        public int SkillPronic
        {
            get { return skillPronic; }
            set { skillPronic = value; base.OnPropertyChanged(); }
        }

        private int statStr { get; set; }
        public int StatStr
        {
            get { return statStr; }
            set { statStr = value; base.OnPropertyChanged(); }
        }

        private int statDex { get; set; }
        public int StatDex
        {
            get { return statDex; }
            set { statDex = value; base.OnPropertyChanged(); }
        }

        private int statCon { get; set; }
        public int StatCon
        {
            get { return statCon; }
            set { statCon = value; base.OnPropertyChanged(); }
        }

        private int statInt { get; set; }
        public int StatInt
        {
            get { return statInt; }
            set { statInt = value; base.OnPropertyChanged(); }
        }

        private int statWis { get; set; }
        public int StatWis
        {
            get { return statWis; }
            set { statWis = value; base.OnPropertyChanged(); }
        }

        private int statCha { get; set; }
        public int StatCha
        {
            get { return statCha; }
            set { statCha = value; base.OnPropertyChanged(); }
        }

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

        public ICommand MakeHP { get; }
        public ICommand MakeStr { get; }
        public ICommand MakeDex { get; }
        public ICommand MakeCon { get; }
        public ICommand MakeInt { get; }
        public ICommand MakeWis { get; }
        public ICommand MakeCha { get; }


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

            MakeHP = new Command(async (e) =>
            {
                var newHP = await ExecuteInputPopup("Введите новое значение хитов персонажа");

                currentHP = maxHP = newHP; 
                character.HP = newHP;
                await App.Database.HeroUpdate(character);
            });

            MakeStr = new Command(async (e) =>
            {
                var newStat = await ExecuteInputPopup("Введите новое значение Силы персонажа");

                StatStr = newStat;
                character.StatStr = newStat;
                await App.Database.HeroUpdate(character);
            });

            MakeDex = new Command(async (e) =>
            {
                var newStat = await ExecuteInputPopup("Введите новое значение Ловкости персонажа");

                StatDex = newStat;
                character.StatDex = newStat;
                await App.Database.HeroUpdate(character);
            });

            MakeCon = new Command(async (e) =>
            {
                var newStat = await ExecuteInputPopup("Введите новое значение Выносливости персонажа");

                StatCon = newStat;
                character.StatCon = newStat;
                await App.Database.HeroUpdate(character);
            });

            MakeInt = new Command(async (e) =>
            {
                var newStat = await ExecuteInputPopup("Введите новое значение Интеллекта персонажа");

                StatInt = newStat;
                character.StatInt = newStat;
                await App.Database.HeroUpdate(character);
            });

            MakeWis = new Command(async (e) =>
            {
                var newStat = await ExecuteInputPopup("Введите новое значение Мудрости персонажа");

                StatWis = newStat;
                character.StatWis = newStat;
                await App.Database.HeroUpdate(character);
            });

            MakeCha = new Command(async (e) =>
            {
                var newStat = await ExecuteInputPopup("Введите новое значение Харизмы персонажа");

                StatCha = newStat;
                character.StatCha = newStat;
                await App.Database.HeroUpdate(character);
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
                character = chars[0];

                this.Title = character.Name + ", " + character.Level + " ур.";
                currentHP = maxHP = character.HP;

                StatStr = character.StatStr;
                StatDex = character.StatDex;
                StatCon = character.StatCon;
                StatInt = character.StatInt;
                StatWis = character.StatWis;
                StatCha = character.StatCha;

                SkillAtlet = character.StatStr + BonusMaster;
                SkillVnim = character.StatWis + BonusMaster;
                SkillZapug = character.StatCha + BonusMaster;
                SkillPronic = character.StatWis + BonusMaster;
                SkillUbejd = character.StatCha + BonusMaster;

                SpasCon = character.StatCon + BonusMaster;
                SpasWis = character.StatWis + BonusMaster;
                SpasCha = character.StatCha + BonusMaster;

                AtackBonus = "+" + (StatStr + BonusMaster).ToString();
                DamageBonus = "1к8 + " + (StatStr + 2).ToString();
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
