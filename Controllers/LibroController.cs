using Libreria.Data;
using Libreria.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Libreria.Controllers
{
    public class LibroController : Controller
    {

        private readonly AplicationDbContext _context;


        public LibroController(AplicationDbContext context)
        {

            _context = context;


        }
        public async Task<IActionResult> Index(String buscar)
        {
            var libro = from Libro in _context.libro select Libro;

            if (!String.IsNullOrEmpty(buscar))
            {

                libro = libro.Where(s => s.titulo!.Contains(buscar));

            }



            return View(await libro.ToListAsync());
        }

        public IActionResult CrearLibro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CrearLibro(Libro libro)
        {

            if (ModelState.IsValid)
            {
                _context.libro.Add(libro);
                _context.SaveChanges();

                TempData["mensaje"] = $"Se agrego {libro.titulo} exitosamente";

                return RedirectToAction("Index");

            }

            return View();
        }

        public IActionResult EditarLibro(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound(); //Cuando no encuentra la pagina o error 404
            }

            var libro = _context.libro.Find(id);

            if (libro == null)

            {
                return NotFound(); //Cuando no encuentra la pagina o error 404
            }

            return View(libro); //Para que muestre el formulario
        }

        [HttpPost]

        public IActionResult EditarLibro(Libro libro)
        {
            //Validar el modelo libro
            if (ModelState.IsValid) //Condición para validar el modelo
            {
                _context.libro.Update(libro); //Si el modelo es valido para agregar un libro
                _context.SaveChanges(); //Se guardan los cambios

                TempData["mensaje"] = $"Se modifico {libro.titulo} exitosamente";

                return RedirectToAction("Index");
            }
            return View();
        }


        public IActionResult EliminarLibro(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound(); //Cuando no encuentra la pagina o error 404
            }

            var libro = _context.libro.Find(id);

            if (libro == null)

            {
                return NotFound(); //Cuando no encuentra la pagina o error 404
            }

            TempData["Mensaje"] = $"Vas a eliminar {libro.titulo} escrito por {libro.autor}";


            return View(libro);


        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.libro == null)
            {
                return Problem("Entity set 'ApplicationDbContext.libro'  is null.");
            }
            var libro = await _context.libro.FindAsync(id);
            if (libro != null)
            {
                _context.libro.Remove(libro);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LibroExists(int id)
        {
            return (_context.libro?.Any(e => e.id == id)).GetValueOrDefault();
        }

    }
}
