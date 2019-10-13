using System;
namespace TrustFund.Models_
{
    public class TCInfoPlan
    {
        public int id { get; set; }
        public string id_client { get; set; }
        public object id_project { get; set; }
        public string id_plan { get; set; }
        public string id_charge { get; set; }
        public object lastupdate { get; set; }
        public DateTime created_at { get; set; }
        public object status { get; set; }
        public string descrip { get; set; }
        public int amount { get; set; }
    }
}
