using Libreria.Data;
using Libreria.Models;
using Microsoft.AspNetCore.Mvc;

namespace Libreria.Controllers
{
    public class LibroController : Controller
    {

        private readonly AplicationDbContext _context;
        

        public LibroController(AplicationDbContext context)
        {

            _context = context;

           
        }
        public IActionResult Index()
        {
            IEnumerable<Libro> ListaLibros = _context.libro;
            return View(ListaLibros);
        }

        public IActionResult CrearLibro()
        {
            return View();
        }

    }
}
