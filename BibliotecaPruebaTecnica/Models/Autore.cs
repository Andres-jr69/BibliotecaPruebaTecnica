using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaPruebaTecnica.Models;

public partial class Autore
{
    public int AutorId { get; set; }
    [Required(ErrorMessage = "El autor es requerido")]
    public string Nombre { get; set; } = null!;

    public virtual ICollection<Libro> Libros { get; set; } = new List<Libro>();
}
