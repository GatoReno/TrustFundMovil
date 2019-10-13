using System;
using SQLite;

namespace TrustFund.Models_
{
    public class User
    {
       
            [PrimaryKey]
            public int id { get; set; }
            public string mail { get; set; }
            public string tok { get; set; }

        public string username { get; set; }

        internal object First()
        {
            throw new NotImplementedException();
        }
    }
}
