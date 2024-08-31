using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Bulky.Models.ViewModels;
using Bulky.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BulkyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = SD.Role_Admin)]
    public class UserController : Controller
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }


        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<ApplicationUser> objUserList = _context.ApplicationUsers.Include(u => u.Company).ToList();
            foreach (var user in objUserList)
            {
                if (user.Company == null)
                {
                    user.Company = new() { Name = "" };
                }
            }
            return Json(new { data = objUserList });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            //var CompanyToBeDeleted = _unitOfWork.Company.Get(u => u.Id == id);
            //if (CompanyToBeDeleted == null)
            //{
            //    return Json(new { success  = false, message = "Error while deleting"});
            //}

            //_unitOfWork.Company.Remove(CompanyToBeDeleted);
            //_unitOfWork.Save();

            return Json(new { success = true, message = "Deleted Successfully!!!" });
        }

        #endregion
    }
}
