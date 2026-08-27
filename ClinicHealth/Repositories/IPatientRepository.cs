using ClinicHealth.Models;

namespace ClinicHealth.Repositories;

public interface IPatientRepository
{
    void Register(Patient patient);
    Patient? GetById(Guid id);
    List<Patient> GetAll();
    void Update(Patient patient);
    void Delete(Guid id);
    bool ExistsId(Guid id);
    bool ExistsName(string name);
    int Count();
}
