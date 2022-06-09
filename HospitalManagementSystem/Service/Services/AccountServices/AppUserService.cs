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
        private readonly IAppUserRepo _AppUserRepo;
        private readonly IMapper _mapper;

        public AppUserService(IMapper mapper,
                              IAppUserRepo AppUserRepo)
        {
            _mapper = mapper;
            _AppUserRepo = AppUserRepo;
        }

        public async Task<List<UserDTO>> GetUsers(Expression<Func<AppUser, bool>> predicate)
        {
            return _mapper.Map<List<UserDTO>>(await _AppUserRepo.FindAllAsync(predicate));
        }

        public async Task<UserDTO> GetUser(Expression<Func<AppUser, bool>> predicate)
        {
            return _mapper.Map<UserDTO>(await _AppUserRepo.FindAsync(predicate));
        }
    }
}
