using ClinicHealth.Interfaces;

namespace ClinicHealth.Models;

public class PatientService: IPatientService
{
 

    public void RegisterPatient(List<Patient> List)
    {
        Console.Write("Enter patient name: ");
        string name = Console.ReadLine();
        
        Console.Write("Enter patient age: ");
        byte age = byte.Parse(Console.ReadLine());
        
        Console.Write("Enter patient symptom: ");
        string symptom = Console.ReadLine();

        var patient = new Patient(name, age, symptom);
        
        List.Add(patient);
    }

    public void ListPatient(List<Patient> List)
    {
        
    }

    public void SearchPatientByName(List<Patient> List, string Name)
    {
        
    }
}