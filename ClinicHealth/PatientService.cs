using ClinicHealth.Interfaces;

namespace ClinicHealth.Models;

public class PatientService: IPatientService
{
 

    public void RegisterPatient(List<Patient> listPatients)
    {
        Console.Write("Enter patient name: ");
        string? name = Console.ReadLine();
        
        Console.Write("Enter patient age: ");
        byte age = byte.Parse(Console.ReadLine() ?? "");
        
        Console.Write("Enter patient symptom: ");
        string? symptom = Console.ReadLine();

        var patient = new Patient(name, age, symptom);
        
        listPatients.Add(patient);
    }

    public void ListPatient(List<Patient> listPatients)
    {
        foreach (var patient in listPatients)
        {
            Console.WriteLine($"Id: {patient.Id}, Name: {patient.Name}, Age: {patient.Age}, Symptom: {patient.Symptom}");
        }
        
    }

    public void SearchPatientByName(List<Patient> listPatients, string Name)
    {
        foreach (var patient in listPatients)
            if (patient.Name == Name)
        {
            Console.Write(patient.Name);
        }

    }
}