using System.Collections.Generic;
using EF.Models.Entities;
using EF.Dal.Repos.Base;

namespace EF.Dal.Repos.Interfaces
{
    public interface ICarRepo : IRepo<Car>
    {
        IEnumerable<Car> GetAllBy(int makeId);
        string GetPetName(int id);
    }
}