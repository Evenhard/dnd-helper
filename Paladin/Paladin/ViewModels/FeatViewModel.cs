using Paladin.Models;
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
                //var slots = CreateCharacter.GetClericSlots(character.Level);
                var slots = CreateCharacter.GetPaladinSlots();
                foreach (var slot in slots)
                {
                    slotList.Add(new Feat() { Title = slot.Title, Description = slot.Amount + "/" + slot.Amount });
                }
                slotList.Heading = "Слоты заклинаний:";

                var domainList = new FeatList()
                {
                    new Feat() { Title = "Наложение рук", Description = character.Level * 5 + "/" + character.Level * 5, Text = "Ваше благословенное касание может лечить раны. У вас есть запас целительной силы, который восстанавливается после продолжительного отдыха. При помощи этого запаса вы можете восстанавливать количество хитов, равное уровню паладина, умноженному на 5.\n" +
                                "Вы можете действием коснуться существа и, зачерпнув силу из запаса, восстановить количество хитов этого существа на любое число, вплоть до максимума, оставшегося в вашем запасе.\n" +
                                "В качестве альтернативы, вы можете потрать 5 хитов из вашего запаса хитов для излечения цели от одной болезни или одного действующего на неё яда. Вы можете устранить несколько эффектов болезни и ядов одним использованием Наложения рук, тратя хиты отдельно для каждого эффекта.\n" +
                                "Это умение не оказывает никакого эффекта на нежить и конструктов." },
                    new Feat() { Title = "Божественная кара", DescriptionVisible = false, Text = "Начиная со 2 уровня, если вы попадаете по существу атакой рукопашным оружием, вы можете потратить одну ячейку заклинания любого своего класса для причинения цели урона излучением, который добавится к урону от оружия. Дополнительный урон равен 2к8 за ячейку 1 уровня, плюс 1к8 за каждый уровень ячейки выше первого, до максимума 5к8. Урон увеличивается на 1к8, если цель — нежить или исчадие." },
                    new Feat() { Title = "Божественное здоровье", DescriptionVisible = false, Text = "Начиная с 3 уровня божественная магия, текущая через вас, даёт вам иммунитет к болезням." },
                    new Feat() { Title = "Аура защиты", DescriptionVisible = false, Text = "Начиная с 6 уровня, если вы или дружественное существо в пределах 10 футов от вас должны совершить спасбросок, это существо получает бонус к спасброску, равный модификатору вашей Харизмы (минимальный бонус +1). Вы должны находиться в сознании, чтобы предоставлять этот бонус. На 18 уровне дистанция этой ауры увеличивается до 30 футов." }
                };
                domainList.Heading = "Паладин:";

                var clericList = new FeatList()
                {
                    new Feat() { Title = "Обет вражды", TypeTop = true, Text = "Вы можете бонусным действием произнести слова обета вражды по отношению к существу, которое вы можете видеть, и которое находится в пределах 10 футов от вас, используя Божественный канал. В течение 1 минуты, пока его хиты не опускаются до 0, или оно не потеряет сознание, вы совершаете броски атаки по нему с превосходством." },
                    new Feat() { Title = "Порицание врага", TypeTop = true, Text = "Вы действием демонстрируете свой священный символ и произносите обличающую молитву, используя Божественный канал. Выберите одно существо в пределах 60 футов, которое можете видеть. Это существо должно совершить спасбросок Мудрости, если не обладает иммунитетом к испугу. Исчадия и нежить совершают этот спасбросок с помехой. Если спасбросок провален, существо становится испуганным на 1 минуту, или пока не получит урон. Пока существо испугано, его скорость равна 0, и оно не получает никаких бонусов к скорости. Если спасбросок был успешен, скорость существа на 1 минуту, или пока оно не получает урон, уменьшается вдвое." }
                };
                clericList.Heading = "Божественный канал(КО):";
                clericList.Description = "1/1";

                var raceList = new FeatList()
                {
                    new Feat() { Title = "Непоколебимая стойкость", Description = "1/1", Text = "Если ваши хиты опустились до нуля, но вы при этом не убиты, ваши хиты вместо этого опускаются до 1. Вы не можете использовать эту способность снова, пока не завершите длительный отдых." },
                    new Feat() { Title = "Свирепые атаки", DescriptionVisible = false, Text = "Если вы совершили критическое попадание рукопашной атакой оружием, вы можете добавить к урону ещё одну кость урона оружия." },
                    new Feat() { Title = "Тёмное зрение", DescriptionVisible = false, Text = "Благодаря орочьей крови, вы обладаете превосходным зрением в темноте и при тусклом освещении. На расстоянии в 60 футов вы при тусклом освещении можете видеть так, как будто это яркое освещение, и в темноте так, как будто это тусклое освещение. В темноте вы не можете различать цвета, только оттенки серого." }
                };
                raceList.Heading = "Расовые черты:";

                var systemFeat = new FeatList()
                {
                    new Feat() { Title = "Мастер щитов", DescriptionVisible = false, Text = "Вы используете щиты не только для обороны, но и для нападения. Вы получаете следующие преимущества, когда используете щит:\n" +
                                "• Если вы в свой ход совершаете действие Атака, вы можете бонусным действием попытаться оттолкнуть щитом существо, находящееся в пределах 5 футов от вас.\n" +
                                "• Если вы не выведены из строя, вы можете добавлять бонус к КД от щита ко всем спасброскам Ловкости, совершённым от заклинаний и прочих вредоносных эффектов, нацеленных только на вас.\n" +
                                "• Если вы подвергаетесь действию эффекта, позволяющего совершить спасбросок Ловкости для получения половины урона, вы можете реакцией вообще не получить урон в случае успешного спасброска, выставив щит между собой и источником эффекта." },
                    new Feat() { Title = "Устойчивый (Вын.)", DescriptionVisible = false, Text = "Выберите одну характеристику. Вы получаете следующие преимущества:\n" +
                                "• Увеличьте значение выбранной характеристики на 1, при максимуме 20.\n" +
                                "• Вы получаете владение спасбросками этой характеристики." }
                };
                systemFeat.Heading = "Черты:";

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
                    raceList,
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
