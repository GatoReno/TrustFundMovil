using System;
namespace TrustFund.Models_
{

    // esta clase recibe el /m/confirm-pass
    public class ResponceTrustPass
    {
        public Responce responce { get; set; }
    }

    public class User_Info
    {
        public int id { get; set; }
        public string id_client { get; set; }
        public DateTime created_at { get; set; }
        public string username { get; set; }
        public string name { get; set; }
        public string lastnameP { get; set; }
        public string lastnameM { get; set; }
        public string pass { get; set; }
        public string mail { get; set; }
        public object admin { get; set; }
        public int user { get; set; }
        public object owner { get; set; }
        public object gender { get; set; }
        public DateTime datenac { get; set; }
        public string phone { get; set; }
        public string calle { get; set; }
        public string colonia { get; set; }
        public object estado { get; set; }
        public int cp { get; set; }
        public string img { get; set; }
        public int id_usercreated { get; set; }
        public string status { get; set; }
    }

    public class Responce
    {
        public string token { get; set; }
        public User_Info user_info { get; set; }
    }
}
