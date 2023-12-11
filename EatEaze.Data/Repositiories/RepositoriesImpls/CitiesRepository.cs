using EatEaze.Data.DataContext;
using EatEaze.Data.Entities;
using EatEaze.Data.Repositiories.RepositoriesInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace EatEaze.Data.Repositiories.RepositoriesImpls
{
    public class CitiesRepository : ICitiesRepository
    {
        private EatEazeDataContext _eatEazeDataContext;

        public CitiesRepository(EatEazeDataContext eatEazeDataContext)
        {
            _eatEazeDataContext = eatEazeDataContext;
        }

        public Task AddItem(City item)
        {
            throw new NotImplementedException();
        }

        public Task AddItem(IEnumerable<City> items)
        {
            throw new NotImplementedException();
        }

        public Task DeleteItem(City item)
        {
            throw new NotImplementedException();
        }

        public Task DeleteItem(IEnumerable<City> items)
        {
            throw new NotImplementedException();
        }

        public async Task<City> GetCityByName(string cityName)
        {
            var result = await _eatEazeDataContext.Cities.FirstOrDefaultAsync(c => c.CityName == cityName);
            if (result == null) throw new Exception();
            return result;
        }

        public async Task<IEnumerable<City>> GetListOfItem()
        {
            return await _eatEazeDataContext.Cities.ToListAsync();
        }

        public Task UpdateItem(City item)
        {
            throw new NotImplementedException();
        }
    }
}
