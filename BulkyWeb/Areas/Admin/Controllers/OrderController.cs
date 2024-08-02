using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Bulky.Models.ViewModels;
using Bulky.Utility;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Stripe.Climate;

namespace BulkyWeb.Areas.Admin.Controllers
{
    [Area("admin")]
    public class OrderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Details(int orderId)
        {
            OrderVM orderVM = new()
            {
                OrderHeader = _unitOfWork.OrderHeader.Get(u => u.Id == orderId, includeProperties: "ApplicationUser"),
                OrderDetail = _unitOfWork.OrderDetail.GetAll(u => u.OrderHeaderId == orderId, includeProperties: "Product")
            };
            return View(orderVM);
        }

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll(string status)
        {
            IEnumerable<OrderHeader> objorderHeaders = _unitOfWork.OrderHeader.GetAll(includeProperties: "ApplicationUser").ToList();

            switch (status)
            {
                case "pending":
                    objorderHeaders = objorderHeaders.Where(u => u.PaymentStatus == SD.Payment_Status_Delayed_Payment);
                    break;
                case "inprocess":
                    objorderHeaders = objorderHeaders.Where(u => u.OrderStatus == SD.Status_InProcess);
                    break;
                case "approved":
                    objorderHeaders = objorderHeaders.Where(u => u.OrderStatus == SD.Status_Shipped);

                    break;
                case "completed":
                    objorderHeaders = objorderHeaders.Where(u => u.OrderStatus == SD.Status_Approved);
                    break;
                default:
                    //all = "active text-white bg-primary";
                    break;
            }

            return Json(new { data = objorderHeaders });
        }

        

        #endregion
    }
}
