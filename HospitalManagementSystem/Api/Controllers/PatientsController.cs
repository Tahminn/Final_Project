using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Service.Services.Interfaces;

namespace Api.Controllers
{
    public class PatientsController : BaseController
    {
        private readonly AppDbContext _context;
        private readonly IPatientService _patientService;
        public PatientsController(AppDbContext context,
                                  IPatientService patientService)
        {
            _context = context;
            _patientService = patientService;
        }

        //GET: api/Patients
        [HttpGet]
        public async Task<IActionResult> GetPatients()
        {
            return Ok(await _patientService.GetPatients());
        }

        //// GET: api/Patients/{id}
        //[HttpGet("{id}")]
        //[Route("GetPatient/{id}")]
        //public async Task<ActionResult<Patient>> GetPatient(int id)
        //{
        //    var patient = await _context.Patients.FindAsync(id);

        //    if (patient == null)
        //    {
        //        return NotFound();
        //    }

        //    return patient;
        //}

        //// PUT: api/Patients/{id}
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutPatient(int id, Patient patient)
        //{
        //    if (id != patient.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(patient).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!PatientExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Patients
        //[HttpPost]
        //public async Task<ActionResult<Patient>> PostPatient(Patient patient)
        //{
        //    _context.Patients.Add(patient);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetPatient", new { id = patient.Id }, patient);
        //}

        //// DELETE: api/Patients/{id}
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeletePatient(int id)
        //{
        //    var patient = await _context.Patients.FindAsync(id);
        //    if (patient == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Patients.Remove(patient);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool PatientExists(int id)
        //{
        //    return _context.Patients.Any(e => e.Id == id);
        //}
    }
}