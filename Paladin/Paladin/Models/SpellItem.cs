using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paladin.Models
{
    [Table("Spells")]
    public class SpellItem
    {
        [SQLite.PrimaryKey, SQLite.AutoIncrement, SQLite.Column("_id")]
        public int Id { get; set; }

        [Column("Prepared")]
        public bool Prepared { get; set; } = false;

        [Column("ClassSpell")]
        public bool ClassSpell { get; set; } = false;

        [Column("HighSlot")]
        public bool HighSlot { get; set; } = false;

        [Column("Concentration")]
        public bool Concentration { get; set; } = false;

        [Column("Ritual")]
        public bool Ritual { get; set; } = false;

        [Column("SpellColor")]
        public int SpellColor { get; set; } = 3;

        public string Title { get; set; }
        public string School { get; set; }
        public int Level { get; set; }
        public string Time { get; set; }
        public string Distance { get; set; }
        public string Components { get; set; }
        public string Duration { get; set; }
        public string Description { get; set; }
    }
}
