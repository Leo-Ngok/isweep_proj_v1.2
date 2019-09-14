using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace v1_10.Models
{
    class settingsdata
    {
        [PrimaryKey]
        int id { get; set; }
        public weight weight { get; set; }
        public height height { get; set; }
        public bp bp { get; set; }
        public temp _temp { get; set; }
        public TimeSpan alerttime { get; set; }
        public bool walert { get; set; }
        public bool oalert { get; set; }
        public Language language { get; set; }

    }
    public enum weight
    {
        Kilogram,
        Pounds,
        None
    }
    public enum height { Meter,Feet,None}
    public enum bp { mmHg, kPa, None }
    public enum temp { Celsius, Fahrenheit, None }
    public enum Language { English,trad_chi,simp_chi}
}
