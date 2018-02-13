using Paladin.Models;
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
            database.CreateTableAsync<Character>(CreateFlags.ImplicitPK);
            database.CreateTableAsync<Items>(CreateFlags.ImplicitPK);
        }

        public Task<List<SpellItem>> GetSpellsList()
        {
            return database.Table<SpellItem>().ToListAsync();
        }

        public Task<List<SpellItem>> GetPreparedSpellsList()
        {
            return database.QueryAsync<SpellItem>("SELECT * FROM [Spells] WHERE [Prepared] = 1 OR [ClassSpell] = 1");
        }

        public Task<SpellItem> GetSpell(int id)
        {
            return database.Table<SpellItem>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task PrepareSpell(SpellItem item)
        {
            return database.UpdateAsync(item);
        }

        public async Task ClearSpellBase()
        {
            await database.DropTableAsync<SpellItem>();
        }

        public async Task FillSpellBase (List<SpellItem> list)
        {
            await database.CreateTableAsync<SpellItem>(CreateFlags.ImplicitPK);

            await database.InsertAllAsync(list);
            //foreach (var item in list)
            //    await database.InsertAsync(item);
        }

        public async Task FillCharacter (Character hero)
        {
            await database.CreateTableAsync<Character>(CreateFlags.ImplicitPK);
            await database.InsertAsync(hero);
        }

        public Task<List<Character>> GetCharactersList()
        {
            return database.Table<Character>().ToListAsync();
        }

        public Task<Character> GetClericGunter(int id)
        {
            return database.Table<Character>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task FillItems(List<Items> items)
        {
            await database.CreateTableAsync<Items>(CreateFlags.ImplicitPK);

            foreach (var item in items)
                await database.InsertAsync(item);
        }

        public Task<List<Items>> GetInventoryesList()
        {
            return database.Table<Items>().ToListAsync();
        }

        public Task GoldUpdate(Character hero)
        {
            return database.UpdateAsync(hero);
        }

        public async Task AddItem(Items item)
        {
            await database.CreateTableAsync<Items>(CreateFlags.ImplicitPK);
            await database.InsertAsync(item);
        }

        public Task DeleteItem(Items item)
        {
            return database.DeleteAsync(item);
        }

        //public Task SaveSpellAsync(SpellItem item)
        //{
        //    if (item.Id != 0)
        //    {
        //        return database.UpdateAsync(item);
        //    }
        //    else
        //    {
        //        return database.InsertAsync(item);
        //    }
        //}

        //public Task DeleteSpellAsync(SpellItem item)
        //{
        //    return database.DeleteAsync(item);
        //}

        //public async Task<int> ElementsCount<T>() where T : new()
        //{
        //    return await connection.Table<T>().CountAsync();
        //}

    }
}
