using Olympians.Models;
using Olympians.Models.Interfaces;
using Olympians.Services.Interfaces;

namespace Olympians.Services
{
    public class BoxerService : IBoxerService
    {
        readonly IOlympicsDatabase _olympicsDatabase;
        public BoxerService(IOlympicsDatabase olympicsDatabase)
        {
            _olympicsDatabase = olympicsDatabase;
        }
        public List<Boxer> GetAllBoxers()
        {
            return _olympicsDatabase.Boxers.ToList();
        }
        public Boxer Get(string firstName, string lastName)
        {
            return _olympicsDatabase.Boxers
                .FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
        }

        public void Create(Boxer boxer)
        {
            _olympicsDatabase.Boxers.Add(boxer);
        }
        public void Update(Boxer boxerProvided)
        {
            var boxer = _olympicsDatabase.Boxers
                .FirstOrDefault(x => x.FirstName == boxerProvided.FirstName
                                && x.LastName == boxerProvided.LastName);
            if (boxer is null)
            {
                throw new Exception("Boxer does not exist!");
            }

            boxer.BoxingCategory = boxerProvided.BoxingCategory;
            boxer.Country = boxerProvided.Country;
            boxer.Wins = boxerProvided.Wins;
            boxer.Losses = boxerProvided.Losses;
        }

        public bool Delete(Boxer boxerProvided)
        {
            var boxer = _olympicsDatabase.Boxers
                .FirstOrDefault(x => x.FirstName == boxerProvided.FirstName
                                && x.LastName == boxerProvided.LastName);
            if (boxer != null)
            {
                return _olympicsDatabase.Boxers.Remove(boxer);
            }

            return false;
        }
    }
}
