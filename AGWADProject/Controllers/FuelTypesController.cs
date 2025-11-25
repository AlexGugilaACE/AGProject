using AGWADProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace AGWADProject.Controllers
{
    public class FuelTypesController : Controller
    {
        private readonly AGDbContext _dbcontext;
        public FuelTypesController(AGDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public IActionResult Index()
        {
            List<FuelType> FuelList = _dbcontext.FuelTypes.ToList();
            return View(FuelList);
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}
