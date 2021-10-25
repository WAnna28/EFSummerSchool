using EF.Dal.EfStructures;
using EF.Dal.Repos.Base;
using EF.Dal.Repos.Interfaces;
using EF.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EF.Dal.Repos
{
    public class CustomerRepo : BaseRepo<Customer>, ICustomerRepo
    {
        public CustomerRepo(ApplicationDbContext context) : base(context)
        {
        }

        internal CustomerRepo(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public override IEnumerable<Customer> GetAll()
            => Table.Include(c => c.Orders).OrderBy(o => o.PersonalInformation.LastName);
    }
}