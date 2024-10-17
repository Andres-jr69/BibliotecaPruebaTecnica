using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaPruebaTecnica.Models;

public class Libro
{
    public int Id { get; set; }
    [Required(ErrorMessage = "El título es obligatorio")]
    public string Titulo { get; set; } = null!;
    [Required(ErrorMessage = "Debe seleccionar un autor")]
    public int? AutorId { get; set; }

    public  Autore? Autor { get; set; }
}
