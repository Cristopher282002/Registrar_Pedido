using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoPedidos.Datos;
using ProyectoPedidos.Models;


namespace ProyectoPedidos.Controllers
{
    public class PedidosController : Controller
    {
        private readonly ApplicationDbContext _db;
        public PedidosController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Pedidos> lista = _db.Pedidos;
            return View(lista);
        }

        [Authorize]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Pedidos pedidos)
        {
            if (ModelState.IsValid)
            {
                _db.Pedidos.Add(pedidos);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(pedidos);
        }

        [Authorize]
        public IActionResult Editar(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = _db.Pedidos.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        //Post Editar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Pedidos pedidos)
        {
            if (ModelState.IsValid)
            {
                _db.Pedidos.Update(pedidos);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(pedidos);

        }
        [Authorize]
        //Get Eliminar
        public IActionResult Eliminar(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = _db.Pedidos.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        //Post Eliminar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Eliminar(Pedidos pedidos)
        {
            if (pedidos == null)
            {
                return NotFound();
            }
            _db.Pedidos.Remove(pedidos);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
