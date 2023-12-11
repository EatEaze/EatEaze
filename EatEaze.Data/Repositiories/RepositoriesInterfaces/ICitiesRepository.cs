using EatEaze.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatEaze.Data.Repositiories.RepositoriesInterfaces
{
    public interface ICitiesRepository : IBaseRepository<City>
    {
        Task<City> GetCityByName(string cityName);
    }
}
