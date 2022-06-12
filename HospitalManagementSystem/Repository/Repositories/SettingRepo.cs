using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class SettingRepo : Repo<Setting>, ISettingRepo
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Setting> entities;
        public SettingRepo(AppDbContext context) : base(context)
        {
            _context = context;
            entities = _context.Set<Setting>();
        }
    }
}
