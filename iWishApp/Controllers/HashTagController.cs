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
        public IActionResult Add()
        {
            HashTag hashtag = new HashTag();
            return View(hashtag);
        }

        public IActionResult Add(HashTag hashtag)
        {
            if (ModelState.IsValid)
            {
                context.HashTag.Add(hashtag);
                context.SaveChanges();
                return Redirect("/HashTag/");
            }
            return View("Add", hashtag);
        }
            public IActionResult AddMotivations(int id)
        {
            Motivations theMotivations = context.Motivations.Find(id);
            List<HashTag> possibleHashTag = context.HashTag.ToList();

            AddMotivationsHashTagViewModel viewModel = new AddMotivationsHashTagViewModel(theMotivations, possibleHashTag);

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddMotivations(AddMotivationsHashTagViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                int motivationsId = viewModel.MotivationsId;
                int hashtagId = viewModel.HashTagId;

                Motivations theMotivations = context.Motivations.Include(p => p.HashTag).Where(e => e.Id == motivationsId).First();
                HashTag theHashTag = context.HashTag.Where(t => t.Id == hashtagId).First();

                theMotivations.HashTag.Add(theHashTag);

                context.SaveChanges();

                return Redirect("/Motivations/Detail/" + motivationsId);
            }
            return View(viewModel );
        }
        public IActionResult Detail(int id) 
        {
            HashTag theHashTag = context.HashTag.Include(e => e.Motivations).Where(t => t.Id == id).First();

            return View(theHashTag);
        }
    }
}
