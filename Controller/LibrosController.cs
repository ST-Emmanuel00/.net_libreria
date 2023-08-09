using Libreria.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Libreria.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : ControllerBase
    {

        private readonly AplicationDbContext _context;

        public LibrosController(AplicationDbContext context) { _context = context; }

        public IActionResult Index() { return View(); }



    }
}
