using System;
namespace TrustFund.Models_
{

        public class PlanInfo
        {
            public PlanI plan { get; set; }
        }

    public class PlanI
    {
        public string id { get; set; }
        public string name { get; set; }
        public int amount { get; set; }
        public DateTime creation_date { get; set; }
        public int repeat_every { get; set; }
        public string repeat_unit { get; set; }
        public int retry_times { get; set; }
        public string status { get; set; }
        public string status_after_retry { get; set; }
        public int trial_days { get; set; }
        public string currency { get; set; }
    }
}
