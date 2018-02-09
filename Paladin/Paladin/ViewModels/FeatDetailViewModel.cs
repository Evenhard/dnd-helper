using Paladin.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paladin.ViewModels
{
    public class FeatDetailViewModel : BaseViewModel
    {
        public Feat Feat { get; set; }
        public FeatDetailViewModel(Feat feat = null)
        {
            Title = feat?.Title;
            Feat = feat;
        }
    }
}
