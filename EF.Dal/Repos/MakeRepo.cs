using EF.Dal.EfStructures;
using EF.Dal.Repos.Base;
using EF.Dal.Repos.Interfaces;
using EF.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EF.Dal.Repos
{
    public class MakeRepo : BaseRepo<Make>, IMakeRepo
    {
        public MakeRepo(ApplicationDbContext context) : base(context)
        {
        }

        internal MakeRepo(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public override IEnumerable<Make> GetAll()
            => Table.OrderBy(m => m.Name);

        public override IEnumerable<Make> GetAllIgnoreQueryFilters()
            => Table.IgnoreQueryFilters().OrderBy(m => m.Name);
    }
}