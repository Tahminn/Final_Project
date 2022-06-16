using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Repository.Data;
using Service.Constants;
using Service.DTOs.ControllerPropDTOs.UserDTOs;
using Service.DTOs.ControllerPropDTOs.UserDTOs.PutUser;
using Service.Services.Interfaces;

namespace Api.Controllers
{
    public class NursesController : BaseController
    {

        private readonly AppDbContext _context;
        private readonly IPatientService _patientService;
        private readonly IUserService _userService;
        private readonly IAccountService _accountService;
        private readonly UserManager<User> _userManager;
        private string roleName = "Nurse";

        public NursesController(AppDbContext context,
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
        //[Authorize(Policy = PolicyTypes.Nurses.Create)]
        public async Task<IActionResult> Create([FromBody] CreateUserDTO createUser)
        {
            await _userService.Create(createUser);
            return Ok();
        }

        [Route("get-all")]
        [HttpPost]
        //[Authorize(Policy = PolicyTypes.Nurses.View)]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAll(roleName);

            if (users == null) return NotFound();

            return Ok(users);
        }

        [Route("get/{id}")]
        [HttpPost]
        [Authorize(Policy = PolicyTypes.Nurses.View)]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            var user = await _userService.GetByUserName(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPut]
        [Route("put/{id}")]
        [Authorize(Policy = PolicyTypes.Nurses.Edit)]
        public async Task<IActionResult> Put([FromRoute] string id, [FromBody] PutUserDTO putUserDTO)
        {

            if (putUserDTO == null)
            {
                return NotFound();
            }

            putUserDTO.Id = id;

            await _userService.Put(putUserDTO);

            return Ok();
        }

        [HttpDelete]
        [Route("delete/{id}")]
        [Authorize(Policy = PolicyTypes.Patients.Delete)]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null) return BadRequest();

            await _userService.Delete(id);

            return Ok();
        }
    }
}
