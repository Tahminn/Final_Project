using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;
using Service.DTOs;
using Service.DTOs.ControllerPropDTOs.UserDTOs;
using Service.DTOs.ControllerPropDTOs.UserDTOs.GetUser;
using Service.DTOs.ControllerPropDTOs.UserDTOs.PutUser;
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
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UserService(IMapper mapper,
                              IUserRepo userRepo,
                              UserManager<User> userManager,
                              AppDbContext context,
                              RoleManager<IdentityRole> roleManager)
        {
            _mapper = mapper;
            _userRepo = userRepo;
            _userManager = userManager;
            _context = context;
            _roleManager = roleManager;
        }

        public async Task Create(CreateUserDTO createUser)
        {
            var user = _mapper.Map<User>(createUser);
            await _userRepo.CreateAsync(user);
        }

        public async Task<Paginate<GetUsersDTO>> GetAll(string roleName, int take, int page)
        {
            if(take == 0) take = 10;

            int skip = (page - 1) * take;

            var user = await _userManager.GetUsersInRoleAsync(roleName);

            var userCount = user.Count();

            user = user.Skip(skip).Take(take).ToList();

            //foreach (var item in user)
            //{
            //    var user1 = _userManager.Users.Include(a => a.Gender).FirstOrDefault(u => u.Id == item.Id);
            //    user.Add(user1);
            //};

            //List<User> user = await entities
            //        .Where(m => m.UserRoles == role)
            //        .Include(m => m.UserRoles)
            //        .Include(p => p.Gender)
            //        .Include(p => p.Department)
            //        .Include(p => p.Occupation)
            //        .OrderByDescending(p => p.Id)
            //        .Skip(skip)
            //        .Take(take)
            //        .ToListAsync();

            //List<User> patients = await _userRepo.GetAllByRoleAsync(roleName, take, skip);

            //var userCount = await _userRepo.GetCountByRoleAsync(roleName);

            var userDTO = _mapper.Map<IList<GetUsersDTO>>(user);

            int totalPage = Helper.GetPageCount(userCount, take);

            Paginate<GetUsersDTO> paginatedUsers = new Paginate<GetUsersDTO>(userDTO, page, totalPage);

            return paginatedUsers;
        }

        public async Task<GetUsersDTO> GetByUserName(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            var userDTO = _mapper.Map<GetUsersDTO>(user);

            return userDTO;
        }
        public async Task Put(PutUserDTO putUserDTO)
        {
            var user = await _userManager.FindByIdAsync(putUserDTO.Id);

            var userMapped = _mapper.Map(putUserDTO, user);

            await _userManager.UpdateAsync(user);

            await _context.SaveChangesAsync();
        }

        public async Task Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            await _userManager.DeleteAsync(user);

            await _context.SaveChangesAsync();
        }
    }
}
