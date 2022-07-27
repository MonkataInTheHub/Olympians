using Olympians.Models;

namespace Olympians.Services.Interfaces
{
    public interface IBoxerService
    {
        void Create(Boxer boxer);
        bool Delete(Boxer boxerProvided);
        List<Boxer> GetAllBoxers();
        Boxer Get(string firstName, string lastName);
        void Update(Boxer boxerProvided);
    }
}