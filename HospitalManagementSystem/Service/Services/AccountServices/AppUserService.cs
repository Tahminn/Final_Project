using AutoMapper;
using Domain.Entities;
using Repository.Repositories.Interfaces;
using Service.DTOs;
using Service.Services.Interfaces;
using System.Linq.Expressions;

namespace Service.Services
{
    public class AppUserService : IAppUserService
    {
        private readonly IAppUserRepo _appUserRepo;
        private readonly IMapper _mapper;

        public AppUserService(IMapper mapper,
                              IAppUserRepo appUserRepo)
        {
            _mapper = mapper;
            _appUserRepo = appUserRepo;
        }

        public async Task<List<UserDTO>> GetUsers(Expression<Func<AppUser, bool>> predicate)
        {
            return _mapper.Map<List<UserDTO>>(await _appUserRepo.FindAllAsync(predicate));
        }

        public async Task<UserDTO> GetUser(Expression<Func<AppUser, bool>> predicate)
        {
            return _mapper.Map<UserDTO>(await _appUserRepo.FindAsync(predicate));
        }
    }
}
