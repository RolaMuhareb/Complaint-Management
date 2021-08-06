using ComplaintManagement.Models;
using DataAccess.Enum;
using DataAccess.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;


namespace ComplaintManagement
{
    public static class Mapper
    {
        public static User MappingUser(UserDTO user)
        {
            User newUser = new User();
            newUser.UserName = user.UserName;
            newUser.Email = user.Email;
            newUser.Number = user.Number;
            newUser.Password = EncryptPass(user.Password); ;
            newUser.UserRoleID = Convert.ToInt32(HttpContext.Current.Session["UserRole"]) == (int)UserRole.MxAdmin ? (int)UserRole.Admin : (int)UserRole.Employee;
            newUser.ConfirmPassword = EncryptPass(user.ConfirmPassword);
            return newUser;
        }

        public static List<ComplaintDTO> MappingListComplaintDTO(List<ComplaintRequest> Complaints)
        {
            List<ComplaintDTO> newComplaintList = new List<ComplaintDTO>();
            foreach (var item in Complaints)
            {
                ComplaintDTO obj = new ComplaintDTO();
                obj.id = item.id.Value;
                obj.Description = item.Description;
                obj.Title = item.Title;
                obj.ToManager = item.ToManager;
                obj.ToHr = item.ToHr;
                obj.ToTeamLeader = item.ToTeamLeader;
                obj.Title = item.Title;
                obj.DepartmentList = new List<SelectListItem>();
                if (item.ComplaintDepartments.Count > 0)
                {
                    var count = 1;
                    foreach (var itemminy in item.ComplaintDepartments)
                    {
                        obj.DepartmentList.Add(new SelectListItem
                        {
                            Text = itemminy.Department.Name,
                            Value = count.ToString()
                        });
                        count++;
                    }
                }
                obj.Status = item.StatusId == (int)Status.Pending ? Status.Pending.ToString() : item.StatusId == (int)Status.Resolved ? Status.Resolved.ToString() : item.StatusId == (int)Status.Dismissed ? Status.Dismissed.ToString() : "";
                newComplaintList.Add(obj);
            } 
            return newComplaintList;
        }
        public static ComplaintRequest MappingComplaint(ComplaintDTO complaint)
        {
            ComplaintRequest complaintRequest = new ComplaintRequest();
            complaintRequest.Description = complaint.Description;
            complaintRequest.Title = complaint.Title;
            complaintRequest.StatusId = (int)Status.Pending;
            complaintRequest.ToHr = complaint.ToHr;
            complaintRequest.ToManager = complaint.ToManager;
            complaintRequest.ToTeamLeader = complaint.ToTeamLeader;
            complaintRequest.CreatedOn = DateTime.Now;
            complaintRequest.InCompany = complaint.InCompany;
            complaintRequest.IsDeleted = false;
            complaintRequest.TimeOfComplaint = complaint.TimeOfComplaint;
            complaintRequest.CreatedById = Convert.ToInt32(HttpContext.Current.Session["UserId"]);
            if (complaint.Complain_List != null)
            {
                complaintRequest.ComplainIntList = complaint.Complain_List;
            }
            return complaintRequest;
        }
        public static string EncryptPass(string password)
        {
            string msg = "";
            byte[] encode = new byte[password.Length];
            encode = Encoding.UTF8.GetBytes(password);
            msg = Convert.ToBase64String(encode);
            return msg;
        }
    }
}