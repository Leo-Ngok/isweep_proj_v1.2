using SQLite;
using System;


namespace v1_10.Models
{
    class weatherDB
    {
        [PrimaryKey,AutoIncrement]
        int id { get; set; }
        public DateTime date { get; set; }
        public double maxtemp { get; set; }
        public double mintemp { get; set; }
        public double maxhum { get; set; }
        public double minhum { get; set; }
    }
}
