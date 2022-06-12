using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Repository.Data;
using Repository.Repositories.Interfaces;
using Service.DTOs;
using Service.DTOs.ControllerPropDTOs.UserDTOs;
using Service.DTOs.ControllerPropDTOs.UserDTOs.GetUser;
using Service.DTOs.EntityDTOs.AccountDTOs;
using Service.Services.Interfaces;
using Service.Utilities.Helpers;
using Service.Utilities.Pagination;
using System.Linq.Expressions;

namespace Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;
        private readonly UserManager<User> _userManager;
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UserService(IMapper mapper,
                              IUserRepo userRepo,
                              UserManager<User> userManager,
                              AppDbContext context)
        {
            _mapper = mapper;
            _userRepo = userRepo;
            _userManager = userManager;
            _context = context;
        }

        //public async Task<List<UserDTO>> GetUsers(Expression<Func<User, bool>> predicate)
        //{
        //    return _mapper.Map<List<UserDTO>>(await _userRepo.FindAllAsync(predicate));
        //}

        //public async Task<UserDTO> GetUser(Expression<Func<User, bool>> predicate)
        //{
        //    return _mapper.Map<UserDTO>(await _userRepo.FindAsync(predicate));
        //}
        public async Task Create(CreateUserDTO createUser)
        {
            var user = _mapper.Map<User>(createUser);
            await _userRepo.CreateAsync(user);
        }

        public async Task<Paginate<GetUsersDTO>> GetAll(int take, int lastPatientId, int page)
        {
            /////Userler uchun pagination i skip take nen yaz

            List<User> patients = await _userRepo.GetAllAsync(take, lastPatientId);
            var patientDTO = _mapper.Map<List<GetUsersDTO>>(patients);

            int totalPage = Helper.GetPageCount(patients.Count(), take);

            Paginate<GetUsersDTO> paginatedUsers = new Paginate<GetUsersDTO>(patientDTO, page, totalPage);

            return paginatedUsers;
        }
    }
}
