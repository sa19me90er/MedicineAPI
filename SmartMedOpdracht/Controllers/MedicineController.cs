using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SmartMedOpdracht.Application;
using SmartMedOpdracht.Models;
using SmartMedOpdracht.Services;

namespace SmartMedOpdracht.Controllers
{
    [Route("api/Medicine")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        //private readonly MedicineContext _context;
        private readonly MedicineService _medicineService;

        public MedicineController(MedicineService medicineService)
        {
            _medicineService = medicineService;
        }

        // GET: api/Medicine
        [HttpGet]
        public ActionResult<List<Medicine>> Get() =>
             _medicineService.Get();
  

        [HttpGet("{id:length(24)}", Name = "GetMidicine")]
        public ActionResult<Medicine> Get(string id)
        {
            var medicine = _medicineService.Get(id);

            if (medicine == null)
            {
                return NotFound();
            }

            return medicine;
        }

        [HttpPost]
        public ActionResult<Medicine> Create(MedicineDTO medicineDTO)
        {
            var medicine = new Medicine() {
                name = medicineDTO.name,
                quantity = medicineDTO.quantity,
                creationDate = medicineDTO.creationDate
            };
            _medicineService.Create(medicine);

            return CreatedAtRoute
                ("GetMidicine",
                new { id = medicine.Id },
                medicine);

        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var medicine = _medicineService.Get(id);

            if (medicine == null)
            {
                return NotFound();
            }

            _medicineService.Remove(medicine.Id);

            return NoContent();
        }

    }
}

