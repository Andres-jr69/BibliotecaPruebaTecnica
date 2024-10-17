using Microsoft.AspNetCore.Mvc.Rendering;

namespace BibliotecaPruebaTecnica.Models
{
    public class LibroViewModel
    {
        public Libro Libro { get; set; }
        public IEnumerable<SelectListItem> Autores { get; set; }
    }
}
