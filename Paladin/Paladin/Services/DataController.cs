using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Paladin.Services
{
    public interface IFileHelper
    {
        string GetLocalFilePath(string filename);
    }

    [Table("Spells")]
    public class SpellItem
    {
        [SQLite.PrimaryKey, SQLite.AutoIncrement, SQLite.Column("_id")]
        public int Id { get; set; }

        [Column("Prepared")]
        public bool Prepared { get; set; }

        [Column("SpellColor")]
        public int SpellColor { get; set; }

        public string Title { get; set; }
        public int Level { get; set; }
        public string Time { get; set; }
        public string Distance { get; set; }
        public string Components { get; set; }
        public string Duration { get; set; }
        public string Description { get; set; }        
    }

    public class DataController
    {
        private static SQLiteAsyncConnection database = null;
        private static DataController instance = null;

        public static DataController Controller
        {
            get { return (instance = instance ?? new DataController()); }
        }

        private DataController()
        {
            database = new SQLiteAsyncConnection(DependencyService.Get<IFileHelper>().GetLocalFilePath("paladin.db"));

            database.CreateTableAsync<SpellItem>(CreateFlags.ImplicitPK);
        }

        public Task<List<SpellItem>> GetSpellsAsync()
        {
            return database.Table<SpellItem>().ToListAsync();
        }

        public Task<List<SpellItem>> GetPreparedSpellsAsync()
        {
            return database.QueryAsync<SpellItem>("SELECT * FROM [Spells] WHERE [Prepared] = 1");
        }

        public Task<SpellItem> GetSpellAsync(int id)
        {
            return database.Table<SpellItem>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task SaveSpellAsync(SpellItem item)
        {
            if (item.Id != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task PrepareSpellAsync(SpellItem item)
        {
            return database.UpdateAsync(item);
        }

        public Task DeleteSpellAsync(SpellItem item)
        {
            return database.DeleteAsync(item);
        }

        public async Task ClearDataBase()
        {
            await database.DropTableAsync<SpellItem>();
            await database.CreateTableAsync<SpellItem>(CreateFlags.ImplicitPK);
        }


        public async Task FillDataBase()
        {
            var DataInit = new List<SpellItem>
            {
                new SpellItem
                {
                    SpellColor = 1,
                    Prepared = false,
                    Title = "Щит от клинков",
                    Level = 0,
                    Time = "1 действие",
                    Distance = "На себя",
                    Components = "В, C",
                    Duration = "1 раунд",
                    Description ="Вы поднимаете руку и чертите в воздухе защитный символ. До конца вашего следующего хода вы получаете сопротивление к дробящему режущему и колющему урону от оружия."
                },

                new SpellItem
                {
                    SpellColor = 1,
                    Prepared = false,
                    Title = "Фокусы",
                    Level = 0,
                    Time = "1 действие",
                    Distance = "10 футов",
                    Components = "В, C",
                    Duration = "До 1 часа",
                    Description ="Заклинание представляет собой простой магический трюк один из: \n - Вы создаете мгновенный безвредный сенсорный эффект, например дождь искр дуновение ветерка тихую мелодию или странный запах. \n - Вы мгновенно зажигаете или тушите свечу факел или маленький костер. \n - Вы мгновенно очищаете или пачкаете объект объемом не более 1 кубического фута. \n - Вы охлаждаете нагреваете или ароматизируете до 1 кубического фута неживого вещества на 1 час. \n - На выбранном вами объекте или поверхности появляется знак или символ который исчезает через 1 час. \n - Вы создаете немагическую безделушку или иллюзорный образ в вашей руке который существует до конца вашего следующего хода. \n Если вы произнесете это заклинание несколько раз подряд то можете поддерживать до трех не мгновенных эффектов одновременно и можете отменить любой из них в качестве действия."
                },

                new SpellItem
                {
                    SpellColor = 2,
                    Prepared = true,
                    Title = "Защита от Зла и Добра и прочей хурьмы",
                    Level = 1,
                    Time = "1 действие",
                    Distance = "Касание",
                    Components = "В, C, М (святая вода или смесь серебряного и железного порошка, которые расходуются при произношении)",
                    Duration = "10 минут, концентрация",
                    Description ="Пока действует заклинание одно согласное существо, к которому вы прикоснулись получает защиту от определенных типов существ: аберраций, божественных существ, демонов, фей, элементалей и нежити. Защита дает следующие преимущества. Существа этих типов получают помеху на броски атаки против цели. Эти существа не могут очаровать напугать или овладеть целью. Если цель уже очарована напугана или одержима существом такого типа то она получает преимущество на все дальнейшие спасброски против эти эффектов."
                }

            };

            foreach(var item in DataInit)
                await database.InsertAsync(item);
        }

        

        //public async Task CheckTable<T>() where T : new()
        //{
        //    await connection.CreateTableAsync<T>();
        //}

        //public async Task ClearTable<T>() where T : new()
        //{
        //    await connection.DropTableAsync<T>();
        //    await connection.CreateTableAsync<T>();
        //}

        //public async Task<int> ElementsCount<T>() where T : new()
        //{
        //    return await connection.Table<T>().CountAsync();
        //}



    }
}
