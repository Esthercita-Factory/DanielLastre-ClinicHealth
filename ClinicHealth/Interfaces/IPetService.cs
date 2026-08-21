using ClinicHealth.Models;

namespace ClinicHealth.Interfaces;

public interface IPetService
{
    void RegisterPet(List<Pet> listPets, Dictionary<Guid, Patient> patientDictionary, Guid patientId);
    void DeletePet(List<Pet> listPets, Guid petId);
    void UpdatePet(List<Pet> listPets, Guid petId);
}
