using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ComplaintManagement.Models
{
    public class ComplaintDTO
    {
        public int id { set; get; }
        public string Title { set; get; }
        public string Description { set; get; }
        public List<int> Complain_List { set; get; }
        public List<SelectListItem> DepartmentList { set; get; }
        public int StatusID { set; get; }
        public string Status { set; get; }
        public DateTime TimeOfComplaint { set; get; }
        public string InCompany { get; set; }
        //checkboxes
        public bool ToHr { set; get; }
        public bool ToManager { set; get; }
        public bool ToTeamLeader { set; get; }
    }
}
