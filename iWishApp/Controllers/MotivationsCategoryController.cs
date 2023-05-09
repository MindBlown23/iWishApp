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
            List<AffirmationsCategory> categories = context.Affirmations.ToList();
            return View(categories);
        }

        // GET: AffirmationsController/Add
        public IActionResult Create()
        {
            AddAffirmationsCategoryViewModel addAffirmationsCategoryViewModel = addAffirmationsCategoryViewModel();

            return View(addAffirmationsCategoryViewModel);
        }
        [HttpPost]
        // GET: HomeController/Create
        public IActionResult ProcessCreateAffirmationsCategoryForm(AddAffirmationsCategoryViewModel addAffirmationsCategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                AffirmationsCategory newCategory = new AffirmationsCategory
                {
                    Name = addAffirmationsCategoryViewModel.Name,
                };

                context.Categories.Add(newCategory);
                context.SaveChanges();

                return Redirect("/AffirmationsCategory");
            }
            return View("Create", addAffirmationsCategoryViewModel);
        }
    }
}
