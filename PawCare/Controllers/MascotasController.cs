using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PawCare.Data;
using PawCare.Models;


namespace PawCare.Controllers
{
    public class MascotasController : Controller
    {
        private readonly PawCareContext _context;

        public MascotasController(PawCareContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var mascotas = await _context.Mascotas
                .FromSqlRaw("EXEC spListarMascotas")
                .ToListAsync();

            return View(mascotas);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Mascota mascota)
        {
            if (ModelState.IsValid)
            {
                var parameters = new[]
                {
                    new SqlParameter("@NombreMascota",
                        mascota.NombreMascota ?? (object)DBNull.Value),

                    new SqlParameter("@NombreDueno",
                        mascota.NombreDueno ?? (object)DBNull.Value),

                    new SqlParameter("@Tipo",
                        mascota.Tipo ?? (object)DBNull.Value),

                    new SqlParameter("@Edad",
                        mascota.Edad),

                    new SqlParameter("@Telefono",
                        mascota.Telefono ?? (object)DBNull.Value),

                    new SqlParameter("@Observaciones",
                        mascota.Observaciones ?? (object)DBNull.Value)
                };

                await _context.Database.ExecuteSqlRawAsync(
                    "EXEC spInsertarMascota @NombreMascota, @NombreDueno, @Tipo, @Edad, @Telefono, @Observaciones",
                    parameters
                );

                return RedirectToAction(nameof(Index));
            }

            return View(mascota);
        }
    }
}