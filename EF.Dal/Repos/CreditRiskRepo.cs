using EF.Dal.EfStructures;
using EF.Dal.Repos.Base;
using EF.Dal.Repos.Interfaces;
using EF.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EF.Dal.Repos
{
    public class CreditRiskRepo : BaseRepo<CreditRisk>, ICreditRiskRepo
    {
        public CreditRiskRepo(ApplicationDbContext context) : base(context)
        {
        }

        internal CreditRiskRepo(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}