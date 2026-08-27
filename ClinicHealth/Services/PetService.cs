using ClinicHealth.Exceptions;
using ClinicHealth.Interfaces;
using ClinicHealth.Models;
using ClinicHealth.Repositories;

namespace ClinicHealth.Services;

public class PetService : IPetService
{
    private readonly IPetRepository _petRepository;
    private readonly IPatientRepository _patientRepository;
    private readonly LoggerService _loggerService;

    public PetService(IPetRepository petRepository, IPatientRepository patientRepository, LoggerService loggerService)
    {
        _petRepository = petRepository;
        _patientRepository = patientRepository;
        _loggerService = loggerService;
    }

    public void Register(Guid ownerId, string name, byte age, PetType type, string symptom, Race race)
    {
        try
        {
            if (!_patientRepository.ExistsId(ownerId))
            {
                throw new PatientNotFoundException(ownerId, "Patient not found. Cannot register pet.");
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be empty.");
            }

            if (age == 0)
            {
                throw new ArgumentException("Age must be greater than 0.");
            }

            var pet = new Pet(name, age, type, symptom, ownerId, race);
            _petRepository.Register(pet);
            
            // Add pet to patient's pet list
            var patient = _patientRepository.GetById(ownerId);
            if (patient != null)
            {
                patient.Pets.Add(pet);
            }
            
            Console.WriteLine("Pet registered successfully.");
        }
        catch (PatientNotFoundException ex)
        {
            _loggerService.LogError(ex, "Register");
            Console.WriteLine(ex.Message);
        }
        catch (Exception e)
        {
            _loggerService.LogError(e, "Register");
            Console.WriteLine($"Error registering pet: {e.Message}");
        }
    }

    public void Delete(Guid id)
    {
        try
        {
            var pet = _petRepository.GetById(id);
            if (pet == null)
            {
                throw new PetNotFoundException(id);
            }

            // Remove from patient's pet list
            var patient = _patientRepository.GetById(pet.PatientId);
            if (patient != null)
            {
                patient.Pets.Remove(pet);
            }

            _petRepository.Delete(id);
            Console.WriteLine("Pet deleted successfully.");
        }
        catch (PetNotFoundException ex)
        {
            _loggerService.LogError(ex, "Delete");
            Console.WriteLine(ex.Message);
        }
        catch (Exception e)
        {
            _loggerService.LogError(e, "Delete");
            Console.WriteLine($"Error deleting pet: {e.Message}");
        }
    }

    public void Update(Guid id, string name, byte age, PetType type, string symptom, Race race)
    {
        try
        {
            var pet = _petRepository.GetById(id);
            if (pet == null)



            {
                throw new PetNotFoundException(id);
            }

            pet.Name = name;
            pet.Age = age;
            pet.Species = type;
            pet.Symptom = symptom;
            pet.Race = race;

            _petRepository.Update(pet);
            Console.WriteLine("Pet updated successfully.");
        }
        catch (PetNotFoundException ex)
        {
            _loggerService.LogError(ex, "Update");
            Console.WriteLine(ex.Message);
        }
        catch (Exception e)
        {
            _loggerService.LogError(e, "Update");
            Console.WriteLine($"Error updating pet: {e.Message}");
        }
    }

    public void List()
    {
        var pets = _petRepository.GetAll();
        foreach (var pet in pets)
        {
            Console.WriteLine($"Id: {pet.Id}, Name: {pet.Name}, Type: {pet.Species}, Symptom: {pet.Symptom}, PatientId: {pet.PatientId}");
        }
    }

    public void ListByOwner(Guid ownerId)
    {
        var pets = _petRepository.FilterByOwner(ownerId);
        foreach (var pet in pets)
        {
            Console.WriteLine($"Id: {pet.Id}, Name: {pet.Name}, Type: {pet.Species}, Symptom: {pet.Symptom}");
        }
    }

    public void TestPolymorphism()
    {
        Console.WriteLine("=== TESTING POLYMORPHISM - ANIMAL SOUNDS ===");

        var pets = _petRepository.GetAll();
        if (pets.Count == 0)
        {
            Console.WriteLine("No pets registered to test polymorphism.");
            return;
        }

        foreach (var pet in pets)
        {
            Console.Write($"{pet.Name} ({pet.Species}): ");
            pet.MakeSound();
        }
    }
}
