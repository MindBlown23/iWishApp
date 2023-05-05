using Microsoft.AspNetCore.Mvc;
using iWishApp.Models;
using iWishApp.Data;
using iWishApp.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace iWishApp.Controllers
{
    public class HashTagController : Controller
    {
        private ApplicationDbContext context;

        public HashTagController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }
        public IActionResult Index()
        {
            List<HashTag> hashtag = context.HashTag.ToList();
            return View(hashtag);
        }

        [HttpPost]
        public IActionResult Add(HashTag hashtag)
        {
            if (ModelState.IsValid)
            {
                context.HashTag.Add(hashtag);
                context.SaveChanges();
                return Redirect("/HashTag");
            }
            return View("Add", hashtag);
        }
        public IActionResult AddAffirmations(int id)
        {
            Affirmations theAffirmations = context.Affirmations.Find(id);
            List<HashTag> possibleHashTag = context.HashTag.ToList();

            AddAffirmationHashTagViewModel viewModel = new AddAffirmationHashTagViewModel(theAffirmations, possibleHashTag);

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddAffirmations(AddAffirmationHashTagViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                int affirmationsId = viewModel.AffirmationsId;
                int hashtagId = viewModel.HashTagId;

                Affirmations theAffirmation = context.Affirmations.Include(p => p.HashTag).Where(e => e.Id == affirmationsId).First();
                HashTag theHashTag = context.HashTag.Where(t => t.Id == hashtagId).First();

                theAffirmations.HashTag.Add(theHashTag);

                context.SaveChanges();

                return Redirect("/Affirmation/Detail/" + affirmationsId);
            }
            return View(viewModel );
        }
        public IActionResult Detail(int id) 
        {
            HashTag theHashTag = context.HashTag.Include(e => e.Affirmations).Where(t => t.Id == id).First();

            return View(theHashTag);
        }
    }
}
