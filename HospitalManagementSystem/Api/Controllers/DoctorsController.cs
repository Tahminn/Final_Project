using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Repository.Data;
using Service.Constants;
using Service.DTOs.ControllerPropDTOs.UserDTOs;
using Service.DTOs.ControllerPropDTOs.UserDTOs.GetUser;
using Service.Services.Interfaces;

namespace Api.Controllers
{
    public class DoctorsController : BaseController
    {
        private readonly AppDbContext _context;
        private readonly IPatientService _patientService;
        private readonly IUserService _userService;
        private readonly IAccountService _accountService;
        private readonly UserManager<User> _userManager;

        public DoctorsController(AppDbContext context,
                                  IPatientService patientService,
                                  UserManager<User> userManager,
                                  IUserService userService,
                                  IAccountService accountService)
        {
            _context = context;
            _patientService = patientService;
            _userManager = userManager;
            _userService = userService;
            _accountService = accountService;
        }

        [Route("create")]
        [HttpPost]
        //[Authorize(Policy = PolicyTypes.Doctors.Create)]
        public async Task<IActionResult> Create([FromBody] CreateUserDTO createUser)
        {
            await _userService.Create(createUser);
            return Ok();
        }

        [Route("get-all")]
        [HttpPost]
        //[Authorize(Policy = PolicyTypes.Doctors.View)]
        public async Task<IActionResult> GetUsers([FromBody] GetPageUserDTO getPageUserDTO)
        {
            var paginatedUsers = await _userService.GetAll(getPageUserDTO.Take, getPageUserDTO.LastPatientId, getPageUserDTO.Page);

            if (paginatedUsers == null) return NotFound();

            return Ok(paginatedUsers);
        }

        //[Route("get/{id}")]
        //[HttpPost]
        //[Authorize(Policy = PolicyTypes.Patients.View)]
        //public async Task<IActionResult> GetPatientById(int id)
        //{
        //    var patient = await _patientService.GetById(id);

        //    if (patient == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(patient);
        //}

        //[HttpPut]
        //[Route("put")]
        ////[Authorize(Policy = PolicyTypes.Patients.Edit)]
        //public async Task<IActionResult> Put([FromBody] PutPatientsDTO putPatientsDTO)
        //{

        //    if (putPatientsDTO == null)
        //    {
        //        return NotFound();
        //    }

        //    await _patientService.Put(putPatientsDTO);

        //    return Ok();
        //}

        //[HttpDelete]
        //[Route("delete/{id}")]
        //[Authorize(Policy = PolicyTypes.Patients.Delete)]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    if (id == 0) return BadRequest();

        //    await _patientService.Delete(id);

        //    return Ok();
        //}
    }
}
