using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace gitNastroje.Models
{
    public class Mood
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public MoodEnum EnumMood { get; set; }
        public string ImageSrc {  get; set; }
    }
}
