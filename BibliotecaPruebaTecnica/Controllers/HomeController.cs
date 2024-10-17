using System.Diagnostics;
using BibliotecaPruebaTecnica.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaPruebaTecnica.Controllers
{
    public class HomeController : Controller
    {
        private readonly BibliotecaContext _context;

        public HomeController(BibliotecaContext context )
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var libros = _context.Libros.Include(x => x.Autor).ToList();
            
            return View(libros);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            var model = new LibroViewModel
            {
                Autores = _context.Autores
                .Select(a => new SelectListItem
                {
                    Value = a.AutorId.ToString(),
                    Text = a.Nombre
                }).ToList()
            };

            return View(model);
            
        }

        [HttpPost]
        public IActionResult CrearLibro(LibroViewModel model)
        {

            if (ModelState.IsValid)
            {
                var libro = new Libro
                {
                    Titulo = model.Libro.Titulo,
                    AutorId = model.Libro.AutorId
                };

                _context.Libros.Add(libro);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            
            //model.Autores = _context.Autores
            //    .Select(a => new SelectListItem
            //    {
            //        Value = a.AutorId.ToString(),
            //        Text = a.Nombre
            //    }).ToList();

            return View(model);
        }

        public IActionResult Editar(int id)
        {
            var libro = _context.Libros.Find(id);
            if (libro == null)
            {
                return NotFound();
            }

            var model = new LibroViewModel
            {
                Libro = libro,
                Autores = _context.Autores
                    .Select(a => new SelectListItem
                    {
                        Value = a.AutorId.ToString(),
                        Text = a.Nombre
                    }).ToList()
            };

            return View(model);
        }

        public IActionResult Delete(int id) 
        {
            var libro = _context.Libros
            .Include(l => l.Autor)
            .FirstOrDefault(l => l.Id == id);

            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        public IActionResult DeleteConfirmed(int id)
        {
            var libro = _context.Libros.Find(id);
            if (libro == null)
            {
                return NotFound();
            }

            _context.Libros.Remove(libro);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }




    }
}
