using System;
namespace TrustFund.Models_
{
    public class UnitTC
    {

        public int id { get; set; }
        public int id_usercreated { get; set; }
        public DateTime created_at { get; set; }
        public string status { get; set; }
        public string desc { get; set; }
        public string plan { get; set; }
        public int amount { get; set; }
        public string img { get; set; }
        public string name { get; set; }

    }
}
