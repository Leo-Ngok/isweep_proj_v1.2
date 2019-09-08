using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace v1_10.Models
{
    class DB_pdata
    {
        [PrimaryKey,AutoIncrement]
        int Id { get; set; }
        public DateTime dob { get; set; }
        public double heig { get; set; }
        public double weig { get; set; }
        public double Sbp { get; set; }
        public double Dbp { get; set; }
        public double Cho { get; set; }
        public double hdll { get; set; }
        public bool genD { get; set; }
        public bool smoK { get; set; }
        public bool diaB { get; set; }
    }
}
