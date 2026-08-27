using ClinicHealth.Models;

namespace ClinicHealth.Repositories;

public interface IPetRepository
{
    void Register(Pet pet);
    Pet? GetById(Guid id);
    List<Pet> GetAll();
    void Update(Pet pet);
    void Delete(Guid id);
    List<Pet> FilterByType(PetType type);
    List<Pet> FilterByOwner(Guid ownerId);
    bool ExistsId(Guid id);
    int Count();
}
