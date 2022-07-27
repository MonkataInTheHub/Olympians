using Olympians.Models;

namespace Olympians.Services.Interfaces
{
    public interface ISprinterService
    {
        void Create(Sprinter sprinter);
        bool Delete(Sprinter sprinterProvided);
        List<Sprinter> GetAllSprinters();
        Sprinter Get(string firstName, string lastName);
        void Update(Sprinter sprinterProvided);
    }
}