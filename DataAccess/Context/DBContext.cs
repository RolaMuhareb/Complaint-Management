using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public class DBContext : DbContext
    {
        public DBContext() : base("name=ComplaintManagement")
        {

        }
        public virtual DbSet<UserRoles> userRolesDB { set; get; }
        public virtual DbSet<User> userDB { set; get; }
        public virtual DbSet<ComplaintRequest> ComplaintRequestDB { set; get; }
        public virtual DbSet<ComplaintDepartments> ComplaintDepartmentsDB { set; get; }
    }

}
