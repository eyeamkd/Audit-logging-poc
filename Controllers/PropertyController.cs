using Microsoft.AspNetCore.Mvc;

namespace AuditLoggerPoc.Controllers
{
    public class PropertyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public PropertyController()
        {

        }

        [HttpGet]
        public IActionResult GetUserProperties() 
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult AddUserProperty()
        {
            throw new NotImplementedException();
        }
      
    }
}
