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
            var ListOfSlots = new List<Slot>();

            var character = new Character()
            {
                Name = "Вася",
                Level = 7,
                HP = 99,
                HitDices = 6,
                Class = Classes.Cleric,
                Subclass = (int)Cleric.Temperst
                //Slots
            };

            switch (character.Level)
            {
                case 1:
                    ListOfSlots.Clear();

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 1 уровня:",
                        Level = 1,
                        Amount = 2
                    });

                    character.Slots = ListOfSlots;
                    break;

                case 2:
                    ListOfSlots.Clear();

                    ListOfSlots.Add(new Slot()
                    {
                        Title = "Слоты 1 уровня:",
                        Level = 1,
                        Amount = 3
                    });

                    character.Slots = ListOfSlots;
                    break;

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

                    character.Slots = ListOfSlots;
                    break;

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

                    character.Slots = ListOfSlots;
                    break;

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

                    character.Slots = ListOfSlots;
                    break;

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

                    character.Slots = ListOfSlots;
                    break;

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

                    character.Slots = ListOfSlots;
                    break;

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

                    character.Slots = ListOfSlots;
                    break;

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

                    character.Slots = ListOfSlots;
                    break;

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

                    character.Slots = ListOfSlots;
                    break;

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

                    character.Slots = ListOfSlots;
                    break;

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

                    character.Slots = ListOfSlots;
                    break;

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

                    character.Slots = ListOfSlots;
                    break;

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

                    character.Slots = ListOfSlots;
                    break;

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

                    character.Slots = ListOfSlots;
                    break;

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

                    character.Slots = ListOfSlots;
                    break;

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

                    character.Slots = ListOfSlots;
                    break;

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

                    character.Slots = ListOfSlots;
                    break;

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

                    character.Slots = ListOfSlots;
                    break;

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

                    character.Slots = ListOfSlots;
                    break;
            }

            await App.Database.FillCharacter(character);
            var answer = await App.Current.MainPage.DisplayAlert("Внимание", "Ваш герой успешно создан", null, "Ок");
        }
    }
}
