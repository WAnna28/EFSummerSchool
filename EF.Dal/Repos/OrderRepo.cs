using EF.Dal.EfStructures;
using EF.Dal.Repos.Base;
using EF.Dal.Repos.Interfaces;
using EF.Models.Entities;
using EF.Models.Entities.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EF.Dal.Repos
{
    public class OrderRepo : BaseRepo<Order>, IOrderRepo
    {
        public OrderRepo(ApplicationDbContext context) : base(context)
        {
        }

        internal OrderRepo(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public IQueryable<CustomerOrderViewModel> GetOrdersViewModel()
        {
            return Context.CustomerOrderViewModels!.AsQueryable();
        }
    }
}