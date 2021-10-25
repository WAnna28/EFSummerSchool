using EF.Dal.Repos.Base;
using EF.Models.Entities;
using EF.Models.Entities.ViewModels;
using System.Linq;

namespace EF.Dal.Repos.Interfaces
{
    public interface IOrderRepo : IRepo<Order>
    {
        IQueryable<CustomerOrderViewModel> GetOrdersViewModel();
    }
}