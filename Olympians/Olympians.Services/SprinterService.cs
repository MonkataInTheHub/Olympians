using Olympians.Models;
using Olympians.Models.Interfaces;
using Olympians.Services.Interfaces;

namespace Olympians.Services
{
    public class SprinterService : ISprinterService
    {
        readonly IOlympicsDatabase _olympicsDatabase;
        public SprinterService(IOlympicsDatabase olympicsDatabase)
        {
            _olympicsDatabase = olympicsDatabase;
        }
        public List<Sprinter> GetAllSprinters()
        {
            return _olympicsDatabase.Sprinters.ToList();
        }
        public Sprinter Get(string firstName, string lastName)
        {
            return _olympicsDatabase.Sprinters
                .FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
        }

        public void Create(Sprinter sprinter)
        {
            _olympicsDatabase.Sprinters.Add(sprinter);
        }
        public void Update(Sprinter sprinterProvided)
        {
            var sprinter = _olympicsDatabase.Sprinters
                .FirstOrDefault(x => x.FirstName == sprinterProvided.FirstName
                                && x.LastName == sprinterProvided.LastName);
            if (sprinter is null)
            {
                throw new Exception("Sprinter does not exist!");
            }

            sprinter.Country = sprinterProvided.Country;
            sprinter.PersonalRecords = sprinterProvided.PersonalRecords;
        }

        public bool Delete(Sprinter sprinterProvided)
        {
            var sprinter = _olympicsDatabase.Sprinters
                .FirstOrDefault(x => x.FirstName == sprinterProvided.FirstName
                                && x.LastName == sprinterProvided.LastName);
            if (sprinter != null)
            {
                return _olympicsDatabase.Sprinters.Remove(sprinter);
            }

            return false;
        }
    }
}
