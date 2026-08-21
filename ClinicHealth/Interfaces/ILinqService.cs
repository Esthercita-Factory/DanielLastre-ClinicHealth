using ClinicHealth.Models;

namespace ClinicHealth.Interfaces;

public interface ILinqService
{
    // Where - Filtrar pacientes por edad
    void FilterPatientsByAge(List<Patient> patients, byte minAge, byte maxAge);
    
    // Where - Filtrar mascotas por especie
    void FilterPetsByType(List<Pet> pets, PetType type);
    
    // Select - Proyectar nombres de pacientes
    void GetPatientNames(List<Patient> patients);
    
    // OrderBy - Ordenar pacientes por nombre
    void OrderPatientsByName(List<Patient> patients);
    
    // OrderByDescending - Ordenar pacientes por edad descendente
    void OrderPatientsByAgeDescending(List<Patient> patients);
    
    // GroupBy - Agrupar pacientes por especie de mascota
    void GroupPatientsByPetType(List<Patient> patients, List<Pet> pets);
    
    // First - Obtener primer paciente
    void GetFirstPatient(List<Patient> patients);
    
    // FirstOrDefault - Obtener primer paciente o default
    void GetFirstPatientOrDefault(List<Patient> patients);
    
    // Any - Verificar si algún paciente cumple condición
    void CheckAnyPatientWithAge(List<Patient> patients, byte age);
    
    // All - Verificar si todos los pacientes cumplen condición
    void CheckAllPatientsWithAge(List<Patient> patients, byte maxAge);
    
    // Count - Contar pacientes
    void CountPatients(List<Patient> patients);
    
    // Count - Contar mascotas por tipo
    void CountPetsByType(List<Pet> pets, PetType type);
    
    // Consulta combinada - Dueños de perros ordenados por edad
    void GetDogOwnersOrderedByAge(List<Patient> patients, List<Pet> pets);

    // Task 5 - Encontrar paciente más joven
    void FindYoungestPatient(List<Patient> patients);

    // Task 5 - Encontrar paciente más viejo
    void FindOldestPatient(List<Patient> patients);

    // Task 5 - Contar mascotas por cada especie
    void CountPetsByEachType(List<Pet> pets);

    // Task 5 - Verificar si existe paciente con mascota sin tipo definido (Other)
    void CheckPatientWithUndefinedPetType(List<Patient> patients, List<Pet> pets);

    // Task 5 - Listar nombres de pacientes en mayúsculas, ordenados alfabéticamente
    void GetPatientNamesUppercaseOrdered(List<Patient> patients);
}
