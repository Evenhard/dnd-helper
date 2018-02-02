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

            foreach (var item in list)
                await database.InsertAsync(item);
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
