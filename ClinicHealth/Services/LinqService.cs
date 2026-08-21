using ClinicHealth.Interfaces;
using ClinicHealth.Models;

namespace ClinicHealth.Services;

public class LinqService : ILinqService
{
    // Where - Filtrar pacientes por edad (sintaxis de métodos)
    public void FilterPatientsByAge(List<Patient> patients, byte minAge, byte maxAge)
    {
        Console.WriteLine($"=== PATIENTS BETWEEN {minAge} AND {maxAge} YEARS OLD ===");

        var filteredPatients = patients.Where(p => p.Age >= minAge && p.Age <= maxAge);

        foreach (var patient in filteredPatients)
        {
            Console.WriteLine($"Id: {patient.Id}, Name: {patient.Name}, Age: {patient.Age}, Phone: {patient.Phone}");
        }

        Console.WriteLine($"Total patients found: {filteredPatients.Count()}");
    }
    
    // Where - Filtrar mascotas por especie (sintaxis de métodos)
    public void FilterPetsByType(List<Pet> pets, PetType type)
    {
        Console.WriteLine($"=== PETS OF TYPE: {type} ===");

        var filteredPets = pets.Where(p => p.Type == type);

        foreach (var pet in filteredPets)
        {
            Console.WriteLine($"Id: {pet.Id}, Name: {pet.Name}, Type: {pet.Type}, Symptom: {pet.Symptom}");
        }

        Console.WriteLine($"Total pets found: {filteredPets.Count()}");
    }
    
    // Select - Proyectar nombres de pacientes (sintaxis de métodos)
    public void GetPatientNames(List<Patient> patients)
    {
        Console.WriteLine("=== PATIENT NAMES ===");
        
        var patientNames = patients.Select(p => p.Name);
        
        foreach (var name in patientNames)
        {
            Console.WriteLine($"- {name}");
        }
        
        Console.WriteLine($"Total patients: {patientNames.Count()}");
    }
    
    // OrderBy - Ordenar pacientes por nombre (sintaxis de métodos)
    public void OrderPatientsByName(List<Patient> patients)
    {
        Console.WriteLine("=== PATIENTS ORDERED BY NAME ===");

        var orderedPatients = patients.OrderBy(p => p.Name);

        foreach (var patient in orderedPatients)
        {
            Console.WriteLine($"Id: {patient.Id}, Name: {patient.Name}, Age: {patient.Age}, Phone: {patient.Phone}");
        }
    }
    
    // OrderByDescending - Ordenar pacientes por edad descendente (sintaxis de métodos)
    public void OrderPatientsByAgeDescending(List<Patient> patients)
    {
        Console.WriteLine("=== PATIENTS ORDERED BY AGE (DESCENDING) ===");

        var orderedPatients = patients.OrderByDescending(p => p.Age);

        foreach (var patient in orderedPatients)
        {
            Console.WriteLine($"Id: {patient.Id}, Name: {patient.Name}, Age: {patient.Age}, Phone: {patient.Phone}");
        }
    }
    
    // GroupBy - Agrupar pacientes por especie de mascota (sintaxis de métodos)
    public void GroupPatientsByPetType(List<Patient> patients, List<Pet> pets)
    {
        Console.WriteLine("=== PATIENTS GROUPED BY PET TYPE ===");
        
        var groupedData = patients
            .Join(pets, patient => patient.Id, pet => pet.PatientId, (patient, pet) => new { Patient = patient, Pet = pet })
            .GroupBy(x => x.Pet.Type);
        
        foreach (var group in groupedData)
        {
            Console.WriteLine($"\n--- Pet Type: {group.Key} ---");
            foreach (var item in group)
            {
                Console.WriteLine($"Patient: {item.Patient.Name}, Pet: {item.Pet.Name}");
            }
        }
    }
    
    // First - Obtener primer paciente (sintaxis de métodos)
    public void GetFirstPatient(List<Patient> patients)
    {
        Console.WriteLine("=== FIRST PATIENT ===");

        try
        {
            var firstPatient = patients.First();
            Console.WriteLine($"Id: {firstPatient.Id}, Name: {firstPatient.Name}, Age: {firstPatient.Age}, Phone: {firstPatient.Phone}");
        }
        catch (InvalidOperationException)
        {
            Console.WriteLine("No patients found.");
        }
    }
    
    // FirstOrDefault - Obtener primer paciente o default (sintaxis de métodos)
    public void GetFirstPatientOrDefault(List<Patient> patients)
    {
        Console.WriteLine("=== FIRST PATIENT OR DEFAULT ===");

        var firstPatient = patients.FirstOrDefault();

        if (firstPatient != null)
        {
            Console.WriteLine($"Id: {firstPatient.Id}, Name: {firstPatient.Name}, Age: {firstPatient.Age}, Phone: {firstPatient.Phone}");
        }
        else
        {
            Console.WriteLine("No patients found (returned null).");
        }
    }
    
    // Any - Verificar si algún paciente cumple condición (sintaxis de métodos)
    public void CheckAnyPatientWithAge(List<Patient> patients, byte age)
    {
        Console.WriteLine($"=== CHECKING IF ANY PATIENT IS {age} YEARS OLD ===");
        
        bool hasPatientWithAge = patients.Any(p => p.Age == age);
        
        if (hasPatientWithAge)
        {
            Console.WriteLine($"YES: There is at least one patient who is {age} years old.");
        }
        else
        {
            Console.WriteLine($"NO: There are no patients who are {age} years old.");
        }
    }
    
    // All - Verificar si todos los pacientes cumplen condición (sintaxis de métodos)
    public void CheckAllPatientsWithAge(List<Patient> patients, byte maxAge)
    {
        Console.WriteLine($"=== CHECKING IF ALL PATIENTS ARE UNDER {maxAge} YEARS OLD ===");
        
        bool allPatientsUnderAge = patients.All(p => p.Age <= maxAge);
        
        if (allPatientsUnderAge)
        {
            Console.WriteLine($"YES: All patients are under {maxAge} years old.");
        }
        else
        {
            Console.WriteLine($"NO: Not all patients are under {maxAge} years old.");
        }
    }
    
    // Count - Contar pacientes (sintaxis de métodos)
    public void CountPatients(List<Patient> patients)
    {
        Console.WriteLine("=== TOTAL PATIENTS ===");
        
        int totalPatients = patients.Count();
        
        Console.WriteLine($"Total patients: {totalPatients}");
    }
    
    // Count - Contar mascotas por tipo (sintaxis de métodos)
    public void CountPetsByType(List<Pet> pets, PetType type)
    {
        Console.WriteLine($"=== COUNTING PETS OF TYPE: {type} ===");

        int count = pets.Count(p => p.Type == type);

        Console.WriteLine($"Total {type} pets: {count}");
    }

    // Consulta combinada - Dueños de perros ordenados por edad
    public void GetDogOwnersOrderedByAge(List<Patient> patients, List<Pet> pets)
    {
        Console.WriteLine("=== DOG OWNERS ORDERED BY AGE ===");

        var result = patients
            .Join(pets,
                  patient => patient.Id,
                  pet => pet.PatientId,
                  (patient, pet) => new { Patient = patient, Pet = pet })
            .Where(x => x.Pet.Type == PetType.Dog)
            .OrderBy(x => x.Patient.Age)
            .Select(x => new {
                Name = x.Patient.Name,
                Phone = x.Patient.Phone,
                Age = x.Patient.Age
            });

        foreach (var item in result)
        {
            Console.WriteLine($"Name: {item.Name}, Phone: {item.Phone}, Age: {item.Age}");
        }

        Console.WriteLine($"Total dog owners: {result.Count()}");
    }

    //  - Encontrar paciente más joven
    public void FindYoungestPatient(List<Patient> patients)
    {
        Console.WriteLine("=== YOUNGEST PATIENT ===");

        try
        {
            var youngestPatient = patients.OrderBy(p => p.Age).First();
            Console.WriteLine($"Id: {youngestPatient.Id}, Name: {youngestPatient.Name}, Age: {youngestPatient.Age}, Phone: {youngestPatient.Phone}");
        }
        catch (InvalidOperationException)
        {
            Console.WriteLine("No patients found.");
        }
    }

    // - Encontrar paciente más viejo
    public void FindOldestPatient(List<Patient> patients)
    {
        Console.WriteLine("=== OLDEST PATIENT ===");

        try
        {
            var oldestPatient = patients.OrderByDescending(p => p.Age).First();
            Console.WriteLine($"Id: {oldestPatient.Id}, Name: {oldestPatient.Name}, Age: {oldestPatient.Age}, Phone: {oldestPatient.Phone}");
        }
        catch (InvalidOperationException)
        {
            Console.WriteLine("No patients found.");
        }
    }

    //  - Contar mascotas por cada especie
    public void CountPetsByEachType(List<Pet> pets)
    {
        Console.WriteLine("=== PETS COUNT BY TYPE ===");

        var petCounts = pets.GroupBy(p => p.Type)
                           .Select(g => new { Type = g.Key, Count = g.Count() });

        foreach (var item in petCounts)
        {
            Console.WriteLine($"{item.Type}: {item.Count}");
        }
    }

    //  - Verificar si existe paciente con mascota sin tipo definido (Other)
    public void CheckPatientWithUndefinedPetType(List<Patient> patients, List<Pet> pets)
    {
        Console.WriteLine("=== CHECKING FOR PATIENTS WITH UNDEFINED PET TYPE (Other) ===");

        var hasUndefinedPet = patients
            .Join(pets, patient => patient.Id, pet => pet.PatientId, (patient, pet) => new { Patient = patient, Pet = pet })
            .Any(x => x.Pet.Type == PetType.Other);

        if (hasUndefinedPet)
        {
            Console.WriteLine("YES: There is at least one patient with a pet of type 'Other'.");

            var patientsWithUndefined = patients
                .Join(pets, patient => patient.Id, pet => pet.PatientId, (patient, pet) => new { Patient = patient, Pet = pet })
                .Where(x => x.Pet.Type == PetType.Other);

            Console.WriteLine("Patients with undefined pet type:");
            foreach (var item in patientsWithUndefined)
            {
                Console.WriteLine($"- Patient: {item.Patient.Name}, Pet: {item.Pet.Name}");
            }
        }
        else
        {
            Console.WriteLine("NO: No patients have a pet of type 'Other'.");
        }
    }

    // Listar nombres de pacientes en mayúsculas, ordenados alfabéticamente
    public void GetPatientNamesUppercaseOrdered(List<Patient> patients)
    {
        Console.WriteLine("=== PATIENT NAMES IN UPPERCASE (ALPHABETICAL) ===");

        var namesUppercase = patients.OrderBy(p => p.Name)
                                      .Select(p => p.Name.ToUpper());

        foreach (var name in namesUppercase)
        {
            Console.WriteLine($"- {name}");
        }

        Console.WriteLine($"Total patients: {namesUppercase.Count()}");
    }
}
