using Microsoft.AspNetCore.Mvc;

namespace sqlinj.Controllers
{
    public class BaseController : Controller
    {
        protected void SetMessage(string message, string type)
        {
            TempData["Message"] = message;

            switch (type)
            {
                case "success":
                    TempData["ClassName"] = "alert alert-success";
                    break;
                case "error":
                    TempData["ClassName"] = "alert alert-danger";
                    break;
                default:
                    break;
            }
        }
    }
}