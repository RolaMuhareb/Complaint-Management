using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;
using DataAccess.Context;
using DataAccess.Genaric;
using DataAccess.Models;

namespace BusinessLogic.Repository
{
    public class UserRepository : IUserRepository
    {
        DBContext con = new DBContext();

        public User getUser(string Email, string Password)
        {
            
            var user = con.userDB.Where(x=>x.Email == Email && x.Password == Password).SingleOrDefault();
            return user != null ? user : new User();
        }
    }
}
