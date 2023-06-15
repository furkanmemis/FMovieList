using FML.Models;
using Microsoft.AspNetCore.Mvc;

namespace FML.Controllers
{
    public class MovieController : Controller
    {
        private AppDbContext _context;

        public MovieController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var movie = _context.Movies.ToList();
            return View(movie);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddMovie()
        {
            var name = HttpContext.Request.Form["MovieName"].ToString();
            var director = HttpContext.Request.Form["MovieDirector"].ToString();
            var year = HttpContext.Request.Form["MovieYear"].ToString();
            var desc = HttpContext.Request.Form["MovieDesc"].ToString();

            Movie mov = new Movie() { MovieName = name, MovieDirector = director, MovieYear = year, MovieDescription = desc };
            _context.Add(mov);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Remove(int id)
        {
            var movie = _context.Movies.Find(id);
            _context.Movies.Remove(movie);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }



        [HttpGet]
        public  IActionResult Update(int id)
        {
            var movie = _context.Movies.Find(id);
            return View(movie);
        }


        [HttpPost]
        public IActionResult Update(Movie upDMovie)
        {
            _context.Movies.Update(upDMovie);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
