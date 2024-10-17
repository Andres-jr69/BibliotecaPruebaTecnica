using BibliotecaPruebaTecnica.Models;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaPruebaTecnica.Controllers
{
    public class AutorController : Controller
    {
        private readonly BibliotecaContext _context;

        public AutorController(BibliotecaContext context)
        {
            _context = context;
        }
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult CreateAutor(Autore autor)
        {
            if (ModelState.IsValid)
            {
                _context.Autores.Add(autor);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");  
            }

            return View(autor);
        }
    }
}
