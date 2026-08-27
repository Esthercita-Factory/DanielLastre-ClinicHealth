using ClinicHealth.Exceptions;
using ClinicHealth.Interfaces;
using ClinicHealth.Models;
using ClinicHealth.Repositories;

namespace ClinicHealth.Services;

public class PatientService: IPatientService
{
    private readonly IPatientRepository _patientRepository;
    private readonly IPetRepository _petRepository;
    private readonly LoggerService _loggerService;

    public PatientService(IPatientRepository patientRepository, IPetRepository petRepository, LoggerService loggerService)
    {
        _patientRepository = patientRepository;
        _petRepository = petRepository;
        _loggerService = loggerService;
    }

    public void DebugDivisionByZero()
    {
        int dividend = 100;
        int divisor = 0;
        
        int result = dividend / divisor;
        
        Console.WriteLine($"Result: {result}");
    }

    public void DebugVariableInspection()
    {
        var patients = _patientRepository.GetAll();
        int patientCount = patients.Count;
        string firstPatientName = "";
        
        if (patientCount > 0)
        {
            firstPatientName = patients[0].Name;
        }
        
        Console.WriteLine($"Total patients: {patientCount}");
        Console.WriteLine($"First patient: {firstPatientName}");
    }

    public void Register(string name, byte age, string address, string phone)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Name cannot be empty.");
        }

        var patient = new Patient(name, age, address, phone);
        _patientRepository.Register(patient);
        
        patient.Register();
        patient.EnviarNotificacion();
    }

    public void List()
    {
        var patients = _patientRepository.GetAll();
        foreach (var patient in patients)
        {
            Console.WriteLine($"Id: {patient.Id}, Name: {patient.Name}, Age: {patient.Age}");
        }
    }

    public void SearchByName(string name)
    {
        var patients = _patientRepository.GetAll();
        bool found = false;
        
        foreach (var patient in patients)
        {
            if (patient.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"Id: {patient.Id}, Name: {patient.Name}, Age: {patient.Age}");
                found = true;
            }
        }
        
        if (!found)
        {
            Console.WriteLine("Patient not found.");
        }
    }

    public void Delete(Guid id)
    {
        try
        {
            // First, remove all pets associated with this patient
            var pets = _petRepository.FilterByOwner(id);
            foreach (var pet in pets)
            {
                _petRepository.Delete(pet.Id);
            }

            // Then remove the patient
            _patientRepository.Delete(id);
            Console.WriteLine("Patient deleted successfully.");
        }
        catch (Exception e)
        {
            _loggerService.LogError(e, "Delete");
            Console.WriteLine($"Error deleting patient: {e.Message}");
        }
    }

    public void Update(Guid id, string name, byte age, string address, string phone)
    {
        try
        {
            var patient = _patientRepository.GetById(id);
            if (patient == null)
            {
                throw new PatientNotFoundException(id);
            }

            patient.Name = name;
            patient.Age = age;
            patient.Address = address;
            patient.Phone = phone;

            _patientRepository.Update(patient);
            Console.WriteLine("Patient updated successfully.");
        }
        catch (PatientNotFoundException ex)
        {
            _loggerService.LogError(ex, "Update");
            Console.WriteLine(ex.Message);
        }
        catch (Exception e)
        {
            _loggerService.LogError(e, "Update");
            Console.WriteLine($"Error updating patient: {e.Message}");
        }
    }
}
