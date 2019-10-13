using System;
using System.Linq;
using TrustFund.Models_;

namespace TrustFund.Classes_
{
    public class DataInfoUser
    {
        private UserDataBase userDataBase;

        public User  GetUserData()
        {

            userDataBase = new UserDataBase();
            var members = userDataBase.GetMembers();
            var countm = members.Count();

            if (countm > 0)
            {
                User user_exist = members.First();


                //User user = new User();
                //user.id = user_exist.id;

                return user_exist;

            }
            else
            {
                return null;
            }
        }
    }
}
