using Paladin.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Paladin.Services
{
    public class CreateCharacter
    {
        public static async Task NewCleric()
        {
            var character = new Character()
            {
                Name = "Гунтер Громобород",
                Level = 8,
                HP = 86,
                HitDices = 8,
                Class = Classes.Cleric,
                Subclass = (int)Cleric.Temperst,
                Gold = 5127,

                StatStr = 4,
                StatDex = 1,
                StatCon = 4,
                StatInt = 0,
                StatWis = 4,
                StatCha = 1

                //Slots
            };

            await App.Database.FillCharacter(character);
            var answer = await App.Current.MainPage.DisplayAlert("Внимание", "Ваш герой успешно создан", null, "Ок");
        }

        public static List<Slot> GetClericSlots(int level)
        {
            var ListOfSlots = new List<Slot>();

            switch (level)
            {
                default:
                    ListOfSlots.Clear();
                    return ListOfSlots;

                case 1:
                    ListOfSlots.Clear();

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 1 уровня:",
                        Level = 1,
                        Amount = 2
                    });

                    return ListOfSlots;

                case 2:
                    ListOfSlots.Clear();

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 1 уровня:",
                        Level = 1,
                        Amount = 3
                    });

                    return ListOfSlots;

                case 3:
                    ListOfSlots.Clear();

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 1 уровня:",
                        Level = 1,
                        Amount = 4
                    });

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 2 уровня:",
                        Level = 2,
                        Amount = 2
                    });

                    return ListOfSlots;

                case 4:
                    ListOfSlots.Clear();

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 1 уровня:",
                        Level = 1,
                        Amount = 4
                    });

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 2 уровня:",
                        Level = 2,
                        Amount = 3
                    });

                    return ListOfSlots;

                case 5:
                    ListOfSlots.Clear();

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 1 уровня:",
                        Level = 1,
                        Amount = 4
                    });

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 2 уровня:",
                        Level = 2,
                        Amount = 3
                    });

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 3 уровня:",
                        Level = 3,
                        Amount = 2
                    });

                    return ListOfSlots;

                case 6:
                    ListOfSlots.Clear();

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 1 уровня:",
                        Level = 1,
                        Amount = 4
                    });

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 2 уровня:",
                        Level = 2,
                        Amount = 3
                    });

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 3 уровня:",
                        Level = 3,
                        Amount = 3
                    });

                    return ListOfSlots;

                case 7:
                    ListOfSlots.Clear();

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 1 уровня:",
                        Level = 1,
                        Amount = 4
                    });

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 2 уровня:",
                        Level = 2,
                        Amount = 3
                    });

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 3 уровня:",
                        Level = 3,
                        Amount = 3
                    });

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 4 уровня:",
                        Level = 4,
                        Amount = 1
                    });

                    return ListOfSlots;

                case 8:
                    ListOfSlots.Clear();

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 1 уровня:",
                        Level = 1,
                        Amount = 4
                    });

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 2 уровня:",
                        Level = 2,
                        Amount = 3
                    });

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 3 уровня:",
                        Level = 3,
                        Amount = 3
                    });

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 4 уровня:",
                        Level = 4,
                        Amount = 2
                    });

                    return ListOfSlots;

                case 9:
                    ListOfSlots.Clear();

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 1 уровня:",
                        Level = 1,
                        Amount = 4
                    });

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 2 уровня:",
                        Level = 2,
                        Amount = 3
                    });

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 3 уровня:",
                        Level = 3,
                        Amount = 3
                    });

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 4 уровня:",
                        Level = 4,
                        Amount = 3
                    });

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 5 уровня:",
                        Level = 5,
                        Amount = 1
                    });

                    return ListOfSlots;

                case 10:
                    ListOfSlots.Clear();

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 1 уровня:",
                        Level = 1,
                        Amount = 4
                    });

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 2 уровня:",
                        Level = 2,
                        Amount = 3
                    });

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 3 уровня:",
                        Level = 3,
                        Amount = 3
                    });

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 4 уровня:",
                        Level = 4,
                        Amount = 3
                    });

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 5 уровня:",
                        Level = 5,
                        Amount = 2
                    });

                    return ListOfSlots;

                case 11:
                    ListOfSlots.Clear();

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 1 уровня:",
                        Level = 1,
                        Amount = 4
                    });

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 2 уровня:",
                        Level = 2,
                        Amount = 3
                    });

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 3 уровня:",
                        Level = 3,
                        Amount = 3
                    });

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 4 уровня:",
                        Level = 4,
                        Amount = 3
                    });

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 5 уровня:",
                        Level = 5,
                        Amount = 2
                    });

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 6 уровня:",
                        Level = 6,
                        Amount = 1
                    });

                    return ListOfSlots;

                case 12:
                    ListOfSlots.Clear();

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 1 уровня:",
                        Level = 1,
                        Amount = 4
                    });

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 2 уровня:",
                        Level = 2,
                        Amount = 3
                    });

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 3 уровня:",
                        Level = 3,
                        Amount = 3
                    });

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 4 уровня:",
                        Level = 4,
                        Amount = 3
                    });

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 5 уровня:",
                        Level = 5,
                        Amount = 2
                    });

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 6 уровня:",
                        Level = 6,
                        Amount = 1
                    });

                    return ListOfSlots;

                case 13:
                    ListOfSlots.Clear();

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 1 уровня:",
                        Level = 1,
                        Amount = 4
                    });

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 2 уровня:",
                        Level = 2,
                        Amount = 3
                    });

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 3 уровня:",
                        Level = 3,
                        Amount = 3
                    });

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 4 уровня:",
                        Level = 4,
                        Amount = 3
                    });

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 5 уровня:",
                        Level = 5,
                        Amount = 2
                    });

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 6 уровня:",
                        Level = 6,
                        Amount = 1
                    });

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 7 уровня:",
                        Level = 7,
                        Amount = 1
                    });

                    return ListOfSlots;

                case 14:
                    ListOfSlots.Clear();

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 1 уровня:",
                        Level = 1,
                        Amount = 4
                    });

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 2 уровня:",
                        Level = 2,
                        Amount = 3
                    });

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 3 уровня:",
                        Level = 3,
                        Amount = 3
                    });

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 4 уровня:",
                        Level = 4,
                        Amount = 3
                    });

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 5 уровня:",
                        Level = 5,
                        Amount = 2
                    });

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 6 уровня:",
                        Level = 6,
                        Amount = 1
                    });

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 7 уровня:",
                        Level = 7,
                        Amount = 1
                    });

                    return ListOfSlots;

                case 15:
                    ListOfSlots.Clear();

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 1 уровня:",
                        Level = 1,
                        Amount = 4
                    });

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 2 уровня:",
                        Level = 2,
                        Amount = 3
                    });

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 3 уровня:",
                        Level = 3,
                        Amount = 3
                    });

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 4 уровня:",
                        Level = 4,
                        Amount = 3
                    });

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 5 уровня:",
                        Level = 5,
                        Amount = 2
                    });

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 6 уровня:",
                        Level = 6,
                        Amount = 1
                    });

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 7 уровня:",
                        Level = 7,
                        Amount = 1
                    });

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 8 уровня:",
                        Level = 8,
                        Amount = 1
                    });

                    return ListOfSlots;

                case 16:
                    ListOfSlots.Clear();

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 1 уровня:",
                        Level = 1,
                        Amount = 4
                    });

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 2 уровня:",
                        Level = 2,
                        Amount = 3
                    });

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 3 уровня:",
                        Level = 3,
                        Amount = 3
                    });

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 4 уровня:",
                        Level = 4,
                        Amount = 3
                    });

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 5 уровня:",
                        Level = 5,
                        Amount = 2
                    });

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 6 уровня:",
                        Level = 6,
                        Amount = 1
                    });

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 7 уровня:",
                        Level = 7,
                        Amount = 1
                    });

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 8 уровня:",
                        Level = 8,
                        Amount = 1
                    });

                    return ListOfSlots;

                case 17:
                    ListOfSlots.Clear();

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 1 уровня:",
                        Level = 1,
                        Amount = 4
                    });

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 2 уровня:",
                        Level = 2,
                        Amount = 3
                    });

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 3 уровня:",
                        Level = 3,
                        Amount = 3
                    });

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 4 уровня:",
                        Level = 4,
                        Amount = 3
                    });

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 5 уровня:",
                        Level = 5,
                        Amount = 2
                    });

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 6 уровня:",
                        Level = 6,
                        Amount = 1
                    });

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 7 уровня:",
                        Level = 7,
                        Amount = 1
                    });

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 8 уровня:",
                        Level = 8,
                        Amount = 1
                    });

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 9 уровня:",
                        Level = 9,
                        Amount = 1
                    });

                    return ListOfSlots;

                case 18:
                    ListOfSlots.Clear();

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 1 уровня:",
                        Level = 1,
                        Amount = 4
                    });

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 2 уровня:",
                        Level = 2,
                        Amount = 3
                    });

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 3 уровня:",
                        Level = 3,
                        Amount = 3
                    });

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 4 уровня:",
                        Level = 4,
                        Amount = 3
                    });

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 5 уровня:",
                        Level = 5,
                        Amount = 3
                    });

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 6 уровня:",
                        Level = 6,
                        Amount = 1
                    });

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 7 уровня:",
                        Level = 7,
                        Amount = 1
                    });

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 8 уровня:",
                        Level = 8,
                        Amount = 1
                    });

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 9 уровня:",
                        Level = 9,
                        Amount = 1
                    });

                    return ListOfSlots;

                case 19:
                    ListOfSlots.Clear();

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 1 уровня:",
                        Level = 1,
                        Amount = 4
                    });

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 2 уровня:",
                        Level = 2,
                        Amount = 3
                    });

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 3 уровня:",
                        Level = 3,
                        Amount = 3
                    });

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 4 уровня:",
                        Level = 4,
                        Amount = 3
                    });

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 5 уровня:",
                        Level = 5,
                        Amount = 3
                    });

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 6 уровня:",
                        Level = 6,
                        Amount = 2
                    });

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 7 уровня:",
                        Level = 7,
                        Amount = 1
                    });

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 8 уровня:",
                        Level = 8,
                        Amount = 1
                    });

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 9 уровня:",
                        Level = 9,
                        Amount = 1
                    });

                    return ListOfSlots;

                case 20:
                    ListOfSlots.Clear();

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 1 уровня:",
                        Level = 1,
                        Amount = 4
                    });

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 2 уровня:",
                        Level = 2,
                        Amount = 3
                    });

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 3 уровня:",
                        Level = 3,
                        Amount = 3
                    });

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 4 уровня:",
                        Level = 4,
                        Amount = 3
                    });

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 5 уровня:",
                        Level = 5,
                        Amount = 3
                    });

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 6 уровня:",
                        Level = 6,
                        Amount = 2
                    });

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 7 уровня:",
                        Level = 7,
                        Amount = 2
                    });

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 8 уровня:",
                        Level = 8,
                        Amount = 1
                    });

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 9 уровня:",
                        Level = 9,
                        Amount = 1
                    });

                    return ListOfSlots;
            }
        }
    }
}
