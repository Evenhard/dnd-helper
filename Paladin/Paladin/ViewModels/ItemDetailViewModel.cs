using System;
using Paladin.Models;
using Paladin.Services;

namespace Paladin.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public SpellItem Item { get; set; }
        public ItemDetailViewModel(SpellItem item = null)
        {
            Title = item?.Title;
            Item = item;
        }
    }
}
