using System;
using System.Collections.Generic;
using System.Linq;
using SQLite;
using TrustFund.Interfaces_;
using TrustFund.Models_;
using Xamarin.Forms;

namespace TrustFund.Classes_
{
    public class UserDataBase
    {
        private SQLiteConnection conn;
        public UserDataBase()
        {
            conn = DependencyService.Get<ISQLite>().GetConnection();
            conn.CreateTable<User>();
        }



        public IEnumerable<User> GetMembers()
        {
            var members = (from mem in conn.Table<User>() select mem);
            return members.ToList();
        }

        public string AddMember(User member)
        {
            try
            {
                conn.Insert(member);
                return "success baby bluye ;*";
            }
            catch (Exception ex)
            {

                return ex.ToString();
            }

        }

        public void DeleteMember(int ID)
        {
            conn.Delete<User>(ID);
        }

        public void DropTbMember()
        {
            conn.DropTable<User>();
        }
    }
}
