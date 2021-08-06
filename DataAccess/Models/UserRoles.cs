using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class UserRoles
    {
        public int id { set; get; }
        public string Name { set; get; }
        public List<User> UsersList { set; get; }

    }
}
