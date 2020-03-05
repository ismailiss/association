using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using association.Models;
using association.Services;
using Microsoft.AspNetCore.Authorization;
using association.Models.asso_config;
using Microsoft.AspNetCore.Identity;



namespace association.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ChartInMVCRuntimeController : Controller
    {
        public IActionResult Index()
        {

           return View("ChartInMVC");
        }
    }
}