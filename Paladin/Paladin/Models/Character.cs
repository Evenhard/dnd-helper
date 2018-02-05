using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paladin.Models
{
    [Table("Characters")]
    public class Character
    {
        [SQLite.PrimaryKey, SQLite.AutoIncrement, SQLite.Column("_id")]
        public int Id { get; set; }

        public string Name { get; set; }
        public int Level { get; set; }
        public int HP { get; set; }
        public int HitDices { get; set; }
        public Classes Class { get; set; }
        public int Subclass { get; set; }
        public List<Slot> Slots { get; set; }
    }

    public enum Classes
    {
        Barbarian,
        Bard,
        Cleric,
        Druid,
        Warrior,
        Monk,
        Paladin,
        Ranger,
        Rogue,
        Sorcerer,
        Warlock,
        Wizzard
    }

    public enum Barbarian
    {
        Berserk,
        Totem
    }

    public enum Bard
    {
        Lore,
        Valor
    }

    public enum Cleric
    {
        Temperst,
        War,
        Life,
        Knowledge,
        Trickery,
        Nature,
        Light
    }

    public class Slot
    {
        public int Level { get; set; }
        public string Title { get; set; }
        public int Amount { get; set; }
    }

}
