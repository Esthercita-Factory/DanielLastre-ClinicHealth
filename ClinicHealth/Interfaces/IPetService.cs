using ClinicHealth.Models;

namespace ClinicHealth.Interfaces;

public interface IPetService
{
    void Register(Guid ownerId, string name, byte age, PetType type, string symptom, Race race);
    void Update(Guid id, string name, byte age, PetType type, string symptom, Race race);
    void Delete(Guid id);
    void List();
    void ListByOwner(Guid ownerId);
    void TestPolymorphism();
}
