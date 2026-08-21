using ClinicHealth.Interfaces;
using ClinicHealth.Models;

namespace ClinicHealth.Services;

public class PatientService: IPatientService
{
 

    public void RegisterPatient(List<Patient> listPatients)
    {
        Console.Write("Enter patient name: ");
        string? name = Console.ReadLine();

        while (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Name cannot be empty.");
            Console.Write("Enter patient name: ");
            name = Console.ReadLine();
        }

        byte age = 0;
        bool validAge = false;
        while (!validAge)
        {
            Console.Write("Enter patient age: ");
            string? input = Console.ReadLine();

            try
            {
                age = byte.Parse(input ?? "");
                validAge = true;
            }
            catch (FormatException e)
            {
                Console.WriteLine($"Error: Please enter a valid number.{e.Message}");
            }
            catch (OverflowException e)
            {
                Console.WriteLine($"Error: Age must be between 0 and 255.{e.Message}");
            }
        }

        Console.Write("Enter patient phone: ");
        string? phone = Console.ReadLine();

        var patient = new Patient(name!, age, phone);

        listPatients.Add(patient);

    }

    public void ListPatient(List<Patient> listPatients)
    {
        foreach (var patient in listPatients)
        {
            Console.WriteLine($"Id: {patient.Id}, Name: {patient.Name}, Age: {patient.Age}");
        }
        
    }

    public void SearchPatientByName(List<Patient> listPatients, string name)
    {
        bool found = false;
        
        foreach (var patient in listPatients)
        {
            if (patient.Name == name.ToLower())
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

    public void DeletePatient(List<Patient> listPatients, Dictionary<Guid, Patient> patientDictionary, Guid patientId)
    {
        try
        {
            Patient? patientToDelete = null;
            
            foreach (var patient in listPatients)
            {
                if (patient.Id == patientId)
                {
                    patientToDelete = patient;
                    break;
                }
            }
            
            if (patientToDelete != null)
            {
                listPatients.Remove(patientToDelete);
                patientDictionary.Remove(patientId);
                Console.WriteLine("Patient deleted successfully.");
            }
            else
            {
                Console.WriteLine("Patient not found.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error deleting patient: {e.Message}");
        }
    }

    public void UpdatePatient(List<Patient> listPatients, Dictionary<Guid, Patient> patientDictionary, Guid patientId)
    {
        try
        {
            Patient? patientToUpdate = null;

            foreach (var patient in listPatients)
            {
                if (patient.Id == patientId)
                {
                    patientToUpdate = patient;
                    break;
                }
            }

            if (patientToUpdate != null)
            {
                Console.Write("Enter new patient name: ");
                string? name = Console.ReadLine();

                while (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Name cannot be empty.");
                    Console.Write("Enter new patient name: ");
                    name = Console.ReadLine();
                }

                byte age = 0;
                bool validAge = false;
                while (!validAge)
                {
                    Console.Write("Enter new patient age: ");
                    string? input = Console.ReadLine();

                    try
                    {
                        age = byte.Parse(input ?? "");
                        validAge = true;
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine($"Error: Please enter a valid number.{e.Message}");
                    }
                    catch (OverflowException e)
                    {
                        Console.WriteLine($"Error: Age must be between 0 and 255.{e.Message}");
                    }
                }

                Console.Write("Enter new patient phone: ");
                string? phone = Console.ReadLine();

                patientToUpdate.Name = name!.Trim().ToLower();
                patientToUpdate.Age = age;
                patientToUpdate.Phone = phone?.Trim() ?? "";

                patientDictionary[patientId] = patientToUpdate;
                Console.WriteLine("Patient updated successfully.");
            }
            else
            {
                Console.WriteLine("Patient not found.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error updating patient: {e.Message}");
        }
    }
}
