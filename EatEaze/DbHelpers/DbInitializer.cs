using EatEaze.Data.DataContext;
using EatEaze.Data.Entities;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Text.Json;

namespace EatEaze.DbHelpers
{
    /// <summary>
    /// class for initializing database with data
    /// </summary>
    public static class DbInitializer
    {
        private static string[] _opt = { };
        private static EatEazeDataContext _eatEazeDataContext = new EatEazeDataContextDesignTimeFactory().CreateDbContext(_opt);

        /// <summary>
        /// provides DbSets with data from json files.
        /// </summary>
        /// <returns>0 if everything is okay, 1 if some data deserialized wrong</returns>
        public static int InitDatabase()
        {
            if (!_eatEazeDataContext.Categories.Any())
            {
                string path = Path.Combine(@".\DataFiles", "Categories.json");
                string json = File.ReadAllText(path);
                var categories = JsonSerializer.Deserialize<List<Category>>(json);

                if (categories == null)
                {
                    return 1;
                }

                _eatEazeDataContext.Categories.AddRange(categories);
            }

            if (!_eatEazeDataContext.Cities.Any())
            {
                string path = Path.Combine(@".\DataFiles", "Cities.json");
                string json = File.ReadAllText(path);
                var cities = JsonSerializer.Deserialize<List<City>>(json);

                if (cities  == null)
                {
                    return 1;
                }

                _eatEazeDataContext.Cities.AddRange(cities);
            }

            if (!_eatEazeDataContext.Restaraunts.Any())
            {
                string path = Path.Combine(@".\DataFiles", "Restaraunts.json");
                string json = File.ReadAllText(path);
                var restaraunts = JsonSerializer.Deserialize<List<Restaraunt>>(json);

                if (restaraunts == null)
                {
                    return 1;
                }

                _eatEazeDataContext.Restaraunts.AddRange(restaraunts);
            }

            if (!_eatEazeDataContext.RestarauntsInCities.Any())
            {
                string path = Path.Combine(@".\DataFiles", "RestarauntsInCities.json");
                string json = File.ReadAllText(path);
                var restarauntsInCities = JsonSerializer.Deserialize<List<RestarauntInCity>>(json);

                if (restarauntsInCities == null)
                {
                    return 1;
                }

                _eatEazeDataContext.RestarauntsInCities.AddRange(restarauntsInCities);
            }

            return 0;
        }
    }
}
