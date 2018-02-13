using Paladin.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paladin.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Items Item { get; set; }
        public ItemDetailViewModel(Items item = null)
        {
            Title = item?.Title;
            Item = item;
        }
    }
}
