using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class ComplaintRequest : DataBase
    {
        public int? id { set; get; }
        public int StatusId { set; get; }
        public string Title { set; get; }
        public string Description { set; get; }
        //multi Select
        public List<int> ComplainIntList { set; get; }
        public List<ComplaintDepartments> ComplaintDepartments { set; get; }
        //checkboxes
        public bool ToHr { set; get; }
        public bool ToManager { set; get; }
        public bool ToTeamLeader { set; get; }
        public DateTime TimeOfComplaint { set; get; }
        public string InCompany { get; set; }
    }
}
