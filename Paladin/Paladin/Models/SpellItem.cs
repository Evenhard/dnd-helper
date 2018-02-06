using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Paladin.Models
{
    [Table("Spells")]
    public class SpellItem : INotifyPropertyChanged
    {
        [SQLite.PrimaryKey, SQLite.AutoIncrement, SQLite.Column("_id")]
        public int Id { get; set; }

        [Column("Prepared")]
        public bool Prepared
        {
            get { return prepared; }
            set { prepared = value; OnPropertyChanged("Prepared"); }
        }
        private bool prepared { get; set; } = false;

        [Column("ClassSpell")]
        public bool ClassSpell { get; set; } = false;

        [Column("HighSlot")]
        public bool HighSlot { get; set; } = false;

        [Column("Concentration")]
        public bool Concentration { get; set; } = false;

        [Column("Ritual")]
        public bool Ritual { get; set; } = false;

        [Column("SpellColor")]
        public SpellColor SpellColor { get; set; } = SpellColor.Bad;

        public string Title { get; set; }
        public string School { get; set; }
        public int Level { get; set; }
        public string Time { get; set; }
        public string Distance { get; set; }
        public string Components { get; set; }
        public string Duration { get; set; }
        public string Description { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public enum SpellColor
    {
        Best = 1,
        Usefull = 2,
        Bad = 3
    }
}
