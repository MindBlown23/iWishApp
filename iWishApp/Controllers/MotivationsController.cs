using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using iWishApp.Data;
using iWishApp.Models;
using iWishApp.ViewModels;
using System.Reflection;

namespace iWishApp.Controllers
{
    public class MotivationsController : Controller
    {
        private ApplicationDbContext context;

        public MotivationsController(ApplicationDbContext dbcontext)
        {
            context = dbcontext;
        }
        // GET: HomeController
        public ActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            List<MotivationsCategory>categories = context.Categories.ToList();
            AddMotivationsViewModel addMotivationsViewModel = new AddMotivationsViewModel(categories);

            return View(addMotivationsViewModel);
        }

        public IActionResult Add(AddMotivationsViewModel addMotivationsViewModel)
        {
            if (ModelState.IsValid)
            {
                MotivationsCategory theCategory = context.Categories.Find(addMotivationsViewModel.CategoryId);
                Motivations newMotivations = new Motivations
                {
                    Title = addMotivationsViewModel.Title,
                    Description = addMotivationsViewModel.Description,
                    Picture = addMotivationsViewModel.Picture,
                    Video = addMotivationsViewModel.Video,
                    Category = theCategory
                };

                context.Motivations.Add(newMotivations);
                context.SaveChanges();

                return Redirect("/Motivations");
            }
                return View(addMotivationsViewModel);
                
        }

            // GET: HomeController/Delete/5
            public IActionResult Delete()
            {
            ViewBag.motivations = context.Motivations.ToList();

                return View();
            }

            // POST: HomeController/Delete/5
            [HttpPost]
            public IActionResult Delete(int[] motivationsIds)
            {
                foreach(int motivationsId in motivationsIds)
                {

                    Motivations theMotivation = context.Motivations.Find(motivationsId);
                    context.Motivations.Remove(theMotivation);
                   
                }

                    context.SaveChanges();

                 return Redirect("/Motivations");
            }
                public IActionResult Details(int id)
                {
                   Motivations theMotivations = context.Motivations
                        .Include(m => m.Category)
                        .Include(m => m.HashTag)
                        .Single(m => m.Id == id);

            MotivationsDetailViewModel viewModel = new MotivationsDetailViewModel(theMotivations);
                        
                    return View(viewModel);
                }
    }
}
