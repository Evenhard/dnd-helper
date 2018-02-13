using System;
using Paladin.Models;
using Paladin.Services;

namespace Paladin.ViewModels
{
    public class SpellDetailViewModel : BaseViewModel
    {
        public SpellItem Item { get; set; }
        public SpellDetailViewModel(SpellItem item = null)
        {
            Title = item?.Title;
            Item = item;
        }
    }
}
