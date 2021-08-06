using BusinessLogic.Repository;
using ComplaintManagement.Models;
using DataAccess.Enum;
using DataAccess.Genaric;
using DataAccess.Models;
using System;
using System.Web.Mvc;

namespace ComplaintManagement.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        IGenaric<User> genericUser = new Genaric<User>();
        IUserRepository userRepository = new UserRepository();

        //Login Page
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        //Login Action and check user

        [AllowAnonymous]
        [MultiSelect(Name = "Login")]
        [HttpPost]
        public ActionResult Login(UserDTO user)
        {
            var pass = Mapper.EncryptPass(user.Password);
            var isUser = userRepository.getUser(user.Email, pass);
            if (isUser.id != 0)
            {
                Session["isUser"] = isUser;
                Session["Email"] = isUser.Email;
                Session["UserId"] = isUser.id;
                Session["Name"] = isUser.UserName;
                Session["UserRole"] = isUser.UserRoleID;
                return RedirectToAction("ComplaintList", "ComplaintRequest");
            }
            else
            {
                ViewData["Message"] = "UserName or password is wrong";
                return View("Login");
            }
        }

        //Register Page
        [AllowAnonymous]
        [MultiSelect(Name = "Register")]
        public ActionResult Register()
        {
            return View("Register");
        }

        //ADD New User
        [HttpPost]
        [AllowAnonymous]
        public ActionResult SaveUser(UserDTO user)
        {
            try
            {
                var newUser = Mapper.MappingUser(user);
                genericUser.Insert(newUser);
                return RedirectToAction("Login", "User");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Login", "User");
            }
        }
        [AllowAnonymous]
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login", "User");
        }
        [AuthorizeCustom]
        public ActionResult AdminRegister()
        {
            return View("AdminRegister");
        }
    }
}
