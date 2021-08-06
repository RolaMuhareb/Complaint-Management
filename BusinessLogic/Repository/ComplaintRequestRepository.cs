using DataAccess.Context;
using DataAccess.Genaric;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace BusinessLogic.Repository
{
    public class ComplaintRequestRepository : IComplaintRequestRepository
    {
        IGenaric<ComplaintRequest> genericComplaintRequest = new Genaric<ComplaintRequest>();
        IGenaric<ComplaintDepartments> genericComplaintDepartments = new Genaric<ComplaintDepartments>();
        DBContext con = new DBContext();
        public bool SaveComplaintRequest(ComplaintRequest complaint)
        {
            try
            {
                genericComplaintRequest.Insert(complaint);
                var id = complaint.id;
                foreach (var departmentID in complaint.ComplainIntList)
                {
                    ComplaintDepartments obj = new ComplaintDepartments();
                    obj.ComplaintRequestId = id;
                    obj.DepartmentId = departmentID;
                    obj.CreatedOn = DateTime.Now;
                    obj.IsDeleted = false;
                    genericComplaintDepartments.Insert(obj);
                }
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public List<ComplaintRequest> ComplaintRequestList(int ? createdById)
        {
            var list = con.ComplaintRequestDB.Include(x => x.ComplaintDepartments.Select(y=>y.Department)).Where(x => createdById != null ? x.CreatedById == createdById : true).ToList();
            return list;
        }
    }
}
