using System;
using System.Collections.Generic;

namespace TrustFund.Models_
{

    public class BadgeListResp
    {


    public int id { get; set; }
    public int id_usercreated { get; set; }
    public object created_at { get; set; }
    public string name { get; set; }
    public string desc { get; set; }
    public string condition { get; set; }
    public string status { get; set; }
    public string img { get; set; }
    public object id_trigger { get; set; }
}

public class BadgeL
{
    public List<BadgeListResp> badge { get; set; }
}


    }