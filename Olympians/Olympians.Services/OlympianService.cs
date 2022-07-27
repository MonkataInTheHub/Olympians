using Olympians.Models;
using Olympians.Models.Interfaces;
using Olympians.Services.Interfaces;


namespace Olympians.Services
{
    public class OlympianService : IOlympianService
    {
        readonly IOlympicsDatabase _olympicsDatabase;
        public OlympianService(IOlympicsDatabase olympicsDatabase)
        {
            _olympicsDatabase = olympicsDatabase;
        }
        public List<IOlympian> ListOlympians()
        {
            var olympians = new List<IOlympian>();
            foreach (var boxer in _olympicsDatabase.Boxers)
            {
                olympians.Add(boxer);
            }
            foreach (var sprinter in _olympicsDatabase.Sprinters)
            {
                olympians.Add(sprinter);
            }
            return olympians;
        }
    }
}
