using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paladin.Models
{
    [Table("Items")]
    public class Items
    {
        [SQLite.PrimaryKey, SQLite.AutoIncrement, SQLite.Column("_id")]
        public int ItemId { get; set; }

        public string Title { get; set; }
        public int Price { get; set; }
        public int Weight { get; set; }
        public string Description { get; set; }
    }
}
