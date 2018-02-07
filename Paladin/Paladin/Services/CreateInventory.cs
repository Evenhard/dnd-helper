using Paladin.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Paladin.Services
{
    public class CreateInventory
    {
        public static async Task NewInventory()
        {
            var items = new List<Items>();

            items.Add(new Items
            {
                Title = "Набор путешественника 1",
                Price = 75,
                Weight = 2,
                Description = "Входит куча всякой бабуйни"
            });

            items.Add(new Items
            {
                Title = "Набор путешественника 2",
                Price = 75,
                Weight = 2,
                Description = "Входит куча всякой бабуйни"
            });

            items.Add(new Items
            {
                Title = "Набор путешественника 3",
                Price = 75,
                Weight = 2,
                Description = "Входит куча всякой бабуйни"
            });

            items.Add(new Items
            {
                Title = "Набор путешественника 4",
                Price = 75,
                Weight = 2,
                Description = "Входит куча всякой бабуйни"
            });

            items.Add(new Items
            {
                Title = "Набор путешественника 5",
                Price = 75,
                Weight = 2,
                Description = "Входит куча всякой бабуйни"
            });

            await App.Database.FillItems(items);
            var answer = await App.Current.MainPage.DisplayAlert("Внимание", "Ваш инвентарь успешно создан", null, "Ок");
        }
    }
}
