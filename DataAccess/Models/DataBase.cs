using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class DataBase
    {
        [ForeignKey("CreatedBy")]
        public int? CreatedById { get; set; }
        [ForeignKey("CreatedById")]
        public User CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }


        [ForeignKey("ModifiedBy")]
        public int? ModifiedById { get; set; }
        [ForeignKey("ModifiedById")]
        public User ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
