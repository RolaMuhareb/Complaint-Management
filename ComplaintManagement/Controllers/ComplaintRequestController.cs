using BusinessLogic.Repository;
using ComplaintManagement.Models;
using DataAccess.Context;
using DataAccess.Enum;
using DataAccess.Genaric;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ComplaintManagement.Controllers
{
    public class ComplaintRequestController : Controller
    {
        IGenaric<ComplaintRequest> _complaintRequestGenericService = new Genaric<ComplaintRequest>();
        IGenaric<Department> _departmentGenericService = new Genaric<Department>();
        IComplaintRequestRepository _complaintRequestRepository = new ComplaintRequestRepository();

        
        //Create Complaint Request View
        public ActionResult Create()
        {
            try
            {
                ComplaintDTO model = new ComplaintDTO();
                model.DepartmentList = _departmentGenericService.getAll().ConvertAll(a =>
                {
                    return new SelectListItem()
                    {
                        Text = a.Name,
                        Value = a.id.ToString()
                    };
                });
                return View(model);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
        //Add New Complaint Request
        [HttpPost]
        public JsonResult SaveComplaint(ComplaintDTO complaint)
        {
            try
            {

                var newComplaint = Mapper.MappingComplaint(complaint);
                _complaintRequestRepository.SaveComplaintRequest(newComplaint);
                var msg = new { MSG = "success", ID = 0 };
                return Json(msg, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
        //Get All Complaint Request For The User
        public ActionResult ComplaintList()
        {
            try
            {
                var Complaints = new List<ComplaintRequest>();
                if (Convert.ToInt32(Session["UserRole"]) == (int)UserRole.Admin || Convert.ToInt32(Session["UserRole"]) == (int)UserRole.MxAdmin)
                {
                     Complaints = _complaintRequestRepository.ComplaintRequestList(null);
                }
                else
                {
                     Complaints = _complaintRequestRepository.ComplaintRequestList(Convert.ToInt32(Session["UserId"]));
                }
                var ComplaintList = Mapper.MappingListComplaintDTO(Complaints);
                return View(ComplaintList);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
        //Admin Change Status for Complaint Request 
        public ActionResult ChangeStatus(int id , int newStatus)
        {
           var complaintRequest = _complaintRequestGenericService.getEdit(id);
            complaintRequest.StatusId = newStatus;
            _complaintRequestGenericService.update(complaintRequest);
            return RedirectToAction("ComplaintList");
        }
    }
}
