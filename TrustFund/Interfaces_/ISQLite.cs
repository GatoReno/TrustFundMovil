using System;
using System.Collections.Generic;
using System.Text;

namespace TrustFund.Interfaces_
{
    public interface ISQLite
    {
        SQLite.SQLiteConnection GetConnection();
    }
}
