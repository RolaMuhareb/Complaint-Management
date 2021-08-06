using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class ComplaintDepartments : DataBase
    {
        [Key]
        public int ComplaintDepartmentsId { get; set; }
        public int? ComplaintRequestId { get; set; }
        [ForeignKey("ComplaintRequestId")]
        public virtual ComplaintRequest ComplaintRequest { get; set; }
        public int? DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }
    }
}
