using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Service.Constants;
using Service.DTOs.ControllerPropDTOs.PatientDTOs;
using Service.DTOs.ControllerPropDTOs.PatientDTOs.CreatePatients;
using Service.DTOs.ControllerPropDTOs.PatientDTOs.PutPatients;
using Service.DTOs.EntityDTOs.AccountDTOs;
using Service.DTOs.EntityDTOs.PatientDTOs;
using Service.Services.Interfaces;
using Service.Utilities.Pagination;

namespace Api.Controllers
{
    public class PatientsController : BaseController
    {
        private readonly AppDbContext _context;
        private readonly IPatientService _patientService;
        private readonly UserManager<User> _userManager;

        public PatientsController(AppDbContext context,
                                  IPatientService patientService,
                                  UserManager<User> userManager)
        {
            _context = context;
            _patientService = patientService;
            _userManager = userManager;
        }

        [Route("create")]
        [HttpPost]
        //[Authorize(Policy = PolicyTypes.Patients.Create)]
        public async Task<IActionResult> Create([FromBody]CreatePatientsDTO createPatients)
        {
            if (createPatients == null)
            {
                return NotFound();
            }

            await _patientService.Create(createPatients);

            return Ok();
        }

        [Route("get-all")]
        [HttpPost]
        //[Authorize(Policy = PolicyTypes.Patients.View)]
        public async Task<IActionResult> GetAll([FromBody] GetPatientsDTO patientsDTO)
        {
            if(patientsDTO.UserId != null)
            {
                Paginate<UserPatientDTO> paginatedPatients = await _patientService.GetAllFromUserPatient(patientsDTO.UserId, patientsDTO.Take, patientsDTO.LastPatientId, patientsDTO.Page);
                return Ok(paginatedPatients);
            }
            else
            {
                Paginate<PatientDTO> paginatedPatients = await _patientService.GetAll(patientsDTO.Take, patientsDTO.LastPatientId, patientsDTO.Page);
                return Ok(paginatedPatients);
            }
        }

        [Route("get/{id}")]
        [HttpPost]
        //[Authorize(Policy = PolicyTypes.Patients.View)]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            var patient = await _patientService.GetById(id);

            if (patient == null)
            {
                return NotFound();
            }

            return Ok(patient);
        }

        [HttpPut]
        [Route("put/{id}")]
        //[Authorize(Policy = PolicyTypes.Patients.Edit)]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] PutPatientsDTO putPatientsDTO)
        {

            if (putPatientsDTO == null)
            {
                return NotFound();
            }

            await _patientService.Put(id,putPatientsDTO);

            return Ok();
        }

        [HttpDelete]
        [Route("delete/{id}")]
        //[Authorize(Policy = PolicyTypes.Patients.Delete)]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            if (id == 0) return BadRequest();

            await _patientService.Delete(id);

            return Ok();
        }
    }
}