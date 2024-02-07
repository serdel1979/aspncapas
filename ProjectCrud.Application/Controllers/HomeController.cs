using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectCrud.Application.Models;
using ProjectCrud.Application.Models.ViewModel;
using ProjectCrud.BLL.Service;
using ProjectCrud.Models;
using System.Diagnostics;
using System.Globalization;

namespace ProjectCrud.Application.Controllers
{
    public class HomeController : Controller
    {
        private readonly IContactoService _contactoService;

        public HomeController(IContactoService contactoService)
        {
            this._contactoService = contactoService;
        }


        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> List()
        {
            IQueryable<Contacto> query = await _contactoService.GetAll();

            List<VModelContact> contacts = query.Select(c=> new VModelContact()
            {
                IdContacto = c.IdContacto,
                Nombre = c.Nombre,
                Telefono = c.Telefono,
                FechaNacimiento = c.FechaNacimiento.Value.ToString("yyyy-MM-dd"),
            }).ToList();

            return StatusCode(StatusCodes.Status200OK, contacts);
        }



        [HttpPost]
        public async Task<IActionResult> Save([FromBody] VModelContact contact)
        {
            if(ModelState.IsValid)
            {
                return View(contact);
            }

            var contactModel = new Contacto()
            {
                Nombre = contact.Nombre,
                Telefono = contact.Telefono,
                FechaNacimiento = DateOnly.ParseExact(contact.FechaNacimiento, "yyyy-MM-dd", CultureInfo.CreateSpecificCulture("es-AR"))
            };

            bool resp = await _contactoService.Insert(contactModel);

            return StatusCode(StatusCodes.Status200OK, new { valor = resp});
        }



        [HttpPut]
        public async Task<IActionResult> Update([FromBody] VModelContact contact)
        {
            if (ModelState.IsValid)
            {
                return View(contact);
            }

            var contactModel = new Contacto()
            {
                Nombre = contact.Nombre,
                Telefono = contact.Telefono,
                FechaNacimiento = DateOnly.ParseExact(contact.FechaNacimiento, "yyyy-MM-dd", CultureInfo.CreateSpecificCulture("es-AR"))
            };

            bool resp = await _contactoService.Update(contactModel);

            return StatusCode(StatusCodes.Status200OK, new { valor = resp });
        }



        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            
            bool resp = await _contactoService.Delete(Id);

            return StatusCode(StatusCodes.Status200OK, new { valor = resp });
        }






        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
