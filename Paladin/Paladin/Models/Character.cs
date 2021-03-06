﻿using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public int Gold { get; set; }

        public int StatStr { get; set; }
        public int StatDex { get; set; }
        public int StatCon { get; set; }
        public int StatInt { get; set; }
        public int StatWis { get; set; }
        public int StatCha { get; set; }
    }

    public class Feat : INotifyPropertyChanged
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public bool TypeTop { get; set; } = false;
        public bool DescriptionVisible { get; set; } = true;
        public string Description
        {
            get { return description; }
            set { description = value; OnPropertyChanged("Description"); }
        }
        private string description { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
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
