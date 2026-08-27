using ClinicHealth.Data;
using ClinicHealth.Models;
namespace ClinicHealth.Repositories;

public class PatientRepository : IPatientRepository
{
    private readonly AlmacenEnMemoria _almacen;
    public PatientRepository(AlmacenEnMemoria almacen)
    {
        _almacen = almacen;
    }
    public void Register(Patient patient)
    {
        _almacen.Patients.Add(patient);
        _almacen.PatientDictionary[patient.Id] = patient;
    }
    public Patient? GetById(Guid id)
    {
        return _almacen.PatientDictionary.TryGetValue(id, out var patient) ? patient : null;
    }
    public List<Patient> GetAll()
    {
        return new List<Patient>(_almacen.Patients);
    }
    public void Update(Patient patient)
    {
        var existing = GetById(patient.Id);
        if (existing != null)
        {
            _almacen.PatientDictionary[patient.Id] = patient;
        }
    }
    public void Delete(Guid id)
    {
        var patient = GetById(id);
        if (patient != null)
        {
            _almacen.Patients.Remove(patient);
            _almacen.PatientDictionary.Remove(id);
        }
    }
    public bool ExistsId(Guid id)
    {
        return _almacen.PatientDictionary.ContainsKey(id);
    }
    public bool ExistsName(string name)
    {
        return _almacen.Patients.Any(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }
    public int Count()
    {
        return _almacen.Patients.Count;
    }
}

public class PetRepository : IPetRepository
{
    private readonly AlmacenEnMemoria _almacen;
    public PetRepository(AlmacenEnMemoria almacen)
    {
        _almacen = almacen;
    }
    public void Register(Pet pet)
    {
        _almacen.Pets.Add(pet);
    }
    public Pet? GetById(Guid id)
    {
        return _almacen.Pets.FirstOrDefault(p => p.Id == id);
    }
    public List<Pet> GetAll()
    {
        return new List<Pet>(_almacen.Pets);
    }
    public void Update(Pet pet)
    {
        var existing = GetById(pet.Id);
        if (existing != null)
        {
            var index = _almacen.Pets.IndexOf(existing);
            if (index >= 0)
            {
                _almacen.Pets[index] = pet;
            }
        }
    }
    public void Delete(Guid id)
    {
        var pet = GetById(id);
        if (pet != null)
        {
            _almacen.Pets.Remove(pet);
        }
    }
    public List<Pet> FilterByType(PetType type)
    {
        return _almacen.Pets.Where(p => p.Species == type).ToList();
    }
    public List<Pet> FilterByOwner(Guid ownerId)
    {
        return _almacen.Pets.Where(p => p.PatientId == ownerId).ToList();
    }
    public bool ExistsId(Guid id)
    {
        return _almacen.Pets.Any(p => p.Id == id);
    }
    public int Count()
    {
        return _almacen.Pets.Count;
    }
}