using iWishApp.Models;
using Microsoft.AspNetCore.Mvc;
using iWishApp.Data;
using iWishApp.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace iWishApp.Controllers
{
    public class MotivationsCategoryController : Controller
    {
        public ApplicationDbContext context;

        public MotivationsCategoryController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }
        public ActionResult Index()
        {
            List<MotivationsCategory> categories = context.Categories.ToList();
            return View(categories);
        }

        // GET: AffirmationsController/Add
        public IActionResult Create()
        {
            AddMotivationsCategoryViewModel addMotivationsCategoryViewModel = addMotivationsCategoryViewModel();

            return View(addMotivationsCategoryViewModel);
        }
        [HttpPost]
        // GET: HomeController/Create
        public IActionResult ProcessCreateMotivationsCategoryForm(AddMotivationsCategoryViewModel addMotivationsCategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                MotivationsCategory newCategory = new MotivationsCategory
                {
                    Title = addMotivationsCategoryViewModel.Title,
                };

                context.Categories.Add(newCategory);
                context.SaveChanges();

                return Redirect("/MotivationsCategory");
            }
            return View("Create", addMotivationsCategoryViewModel);
        }
    }
}
