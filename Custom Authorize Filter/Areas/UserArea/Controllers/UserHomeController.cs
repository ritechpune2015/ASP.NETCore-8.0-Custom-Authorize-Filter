using Custom_Authorize_Filter.CustFilter;
using Custom_Authorize_Filter.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Custom_Authorize_Filter.Areas.UserArea.Controllers
{
    [Area("UserArea")]
    [UserAuth]
    public class UserHomeController : Controller
    {
        IProduct repo;
        public UserHomeController(IProduct repo)
        {
            this.repo = repo;
        }
        public async Task<IActionResult> Index()
        {
           
            return View(await this.repo.GetAll());
        }
    }
}
