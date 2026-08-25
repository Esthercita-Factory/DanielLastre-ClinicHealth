using ClinicHealth.Interfaces;
using ClinicHealth.Models;
using ClinicHealth.Services;

namespace ClinicHealth.UI;

public class ManagerClinic
{
    private PatientService _patientService;
    private PetService _petService;
    private LinqService _linqService;
    private LoggerService _loggerService;
    private List<Patient> _listPatients;
    private List<Pet> _listPets;
    private Dictionary<Guid, Patient> _patientDictionary;

    public ManagerClinic(PatientService patientService, PetService petService, LinqService linqService, LoggerService loggerService, List<Patient> listPatients, List<Pet> listPets, Dictionary<Guid, Patient> patientDictionary)
    {
        _patientService = patientService;
        _petService = petService;
        _linqService = linqService;
        _loggerService = loggerService;
        _listPatients = listPatients;
        _listPets = listPets;
        _patientDictionary = patientDictionary;
    }



    public void ShowMainMenu()
    {
        bool mainMenu = true;

        while (mainMenu)
        {

            Console.WriteLine("=== HEALTH MAIN MENU ===");
            Console.WriteLine("=== PATIENTS ===");
            Console.WriteLine("1. Register Patient");
            Console.WriteLine("2. List Patients");
            Console.WriteLine("3. Search Patient");
            Console.WriteLine("4. Delete Patient");
            Console.WriteLine("5. Update Patient");
            Console.WriteLine("=== PETS ===");
            Console.WriteLine("6. Register Pet");
            Console.WriteLine("7. List Pets");
            Console.WriteLine("8. Delete Pet");
            Console.WriteLine("9. Update Pet");
            Console.WriteLine("10. Show Patient's Pets");
            Console.WriteLine("11. Test Polymorphism (Animal Sounds)");
            Console.WriteLine("=== LINQ QUERIES ===");
            Console.WriteLine("12. Filter Patients by Age (Where)");
            Console.WriteLine("13. Filter Pets by Type (Where)");
            Console.WriteLine("14. Get Patient Names (Select)");
            Console.WriteLine("15. Order Patients by Name (OrderBy)");
            Console.WriteLine("16. Order Patients by Age Descending (OrderByDescending)");
            Console.WriteLine("17. Group Patients by Pet Type (GroupBy)");
            Console.WriteLine("18. Get First Patient (First)");
            Console.WriteLine("19. Get First Patient or Default (FirstOrDefault)");
            Console.WriteLine("20. Check Any Patient with Age (Any)");
            Console.WriteLine("21. Check All Patients with Age (All)");
            Console.WriteLine("22. Count Patients (Count)");
            Console.WriteLine("23. Count Pets by Type (Count)");
            Console.WriteLine("24. Combined Query - Dog Owners Ordered by Age (Where + OrderBy + Select)");
            Console.WriteLine("=== PRACTICAL PROBLEMS ===");
            Console.WriteLine("25. Find Youngest Patient (OrderBy + First)");
            Console.WriteLine("26. Find Oldest Patient (OrderByDescending + First)");
            Console.WriteLine("27. Count Pets by Each Type (GroupBy + Select)");
            Console.WriteLine("28. Check Patient with Undefined Pet Type (Join + Any)");
            Console.WriteLine("29. Get Patient Names in Uppercase Ordered (OrderBy + Select + ToUpper)");
            Console.WriteLine("=== DEBUGGING ===");
            Console.WriteLine("31. Test Multiple Interfaces (Patient: IRegistrable + INotificable)");
            Console.WriteLine("32. Debug: Division by Zero Error");
            Console.WriteLine("33. Debug: Variable Inspection");
            Console.WriteLine("=== EXIT ===");
            Console.WriteLine("34. Exit");
            Console.Write("Choose an option: ");

            string? option = Console.ReadLine();

            switch (option)
            {
                case "1":
                {
                    try
                    {
                        _patientService.RegisterPatient(_listPatients);
                    }
                    catch (Exception ex)
                    {
                        _loggerService.LogError(ex, "RegisterPatient");
                        Console.WriteLine($"Error registering patient: {ex.Message}");
                    }
                    break;
                }
                case "2":
                {
                    try
                    {
                        _patientService.ListPatient(_listPatients);
                    }
                    catch (Exception ex)
                    {
                        _loggerService.LogError(ex, "ListPatient");
                        Console.WriteLine($"Error listing patients: {ex.Message}");
                    }
                    break;
                }
                case "3":
                {
                    try
                    {
                        Console.Write("Enter patient name to search: ");
                        string? name = Console.ReadLine();
                        _patientService.SearchPatientByName(_listPatients, name);
                    }
                    catch (Exception ex)
                    {
                        _loggerService.LogError(ex, "SearchPatientByName");
                        Console.WriteLine($"Error searching patient: {ex.Message}");
                    }
                    break;
                }
                case "4":
                {
                    try
                    {
                        Console.Write("Enter patient ID to delete: ");
                        string? idInput = Console.ReadLine();
                        if (Guid.TryParse(idInput, out Guid patientId))
                        {
                            _patientService.DeletePatient(_listPatients, _patientDictionary, patientId);
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID format.");
                        }
                    }
                    catch (Exception ex)
                    {
                        _loggerService.LogError(ex, "DeletePatient");
                        Console.WriteLine($"Error deleting patient: {ex.Message}");
                    }
                    break;
                }
                case "5":
                {
                    try
                    {
                        Console.Write("Enter patient ID to update: ");
                        string? idInput = Console.ReadLine();
                        if (Guid.TryParse(idInput, out Guid patientId))
                        {
                            _patientService.UpdatePatient(_listPatients, _patientDictionary, patientId);
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID format.");
                        }
                    }
                    catch (Exception ex)
                    {
                        _loggerService.LogError(ex, "UpdatePatient");
                        Console.WriteLine($"Error updating patient: {ex.Message}");
                    }
                    break;
                }
                case "6":
                {
                    try
                    {
                        Console.Write("Enter patient ID to register pet: ");
                        string? idInput = Console.ReadLine();
                        if (Guid.TryParse(idInput, out Guid patientId))
                        {
                            _petService.RegisterPet(_listPets, _patientDictionary, patientId);
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID format.");
                        }
                    }
                    catch (Exception ex)
                    {
                        _loggerService.LogError(ex, "RegisterPet");
                        Console.WriteLine($"Error registering pet: {ex.Message}");
                    }
                    break;
                }
                case "7":
                {
                    try
                    {
                        Console.WriteLine("=== PETS LIST ===");
                        foreach (var pet in _listPets)
                        {
                            Console.WriteLine($"Id: {pet.Id}, Name: {pet.Name}, Type: {pet.Species}, Symptom: {pet.Symptom}, PatientId: {pet.PatientId}");
                        }
                    }
                    catch (Exception ex)
                    {
                        _loggerService.LogError(ex, "ListPets");
                        Console.WriteLine($"Error listing pets: {ex.Message}");
                    }
                    break;
                }
                case "8":
                {
                    try
                    {
                        Console.Write("Enter pet ID to delete: ");
                        string? idInput = Console.ReadLine();
                        if (Guid.TryParse(idInput, out Guid petId))
                        {
                            _petService.DeletePet(_listPets, _patientDictionary, petId);
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID format.");
                        }
                    }
                    catch (Exception ex)
                    {
                        _loggerService.LogError(ex, "DeletePet");
                        Console.WriteLine($"Error deleting pet: {ex.Message}");
                    }
                    break;
                }
                case "9":
                {
                    try
                    {
                        Console.Write("Enter pet ID to update: ");
                        string? idInput = Console.ReadLine();
                        if (Guid.TryParse(idInput, out Guid petId))
                        {
                            _petService.UpdatePet(_listPets, _patientDictionary, petId);
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID format.");
                        }
                    }
                    catch (Exception ex)
                    {
                        _loggerService.LogError(ex, "UpdatePet");
                        Console.WriteLine($"Error updating pet: {ex.Message}");
                    }
                    break;
                }
                case "10":
                {
                    try
                    {
                        Console.Write("Enter patient ID to show pets: ");
                        string? idInput = Console.ReadLine();
                        if (Guid.TryParse(idInput, out Guid patientId))
                        {
                            if (_patientDictionary.ContainsKey(patientId))
                            {
                                _patientDictionary[patientId].ShowPets();
                            }
                            else
                            {
                                Console.WriteLine("Patient not found.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID format.");
                        }
                    }
                    catch (Exception ex)
                    {
                        _loggerService.LogError(ex, "ShowPatientPets");
                        Console.WriteLine($"Error showing patient pets: {ex.Message}");
                    }
                    break;
                }
                case "11":
                {
                    try
                    {
                        _petService.TestPolymorphism(_listPets);
                    }
                    catch (Exception ex)
                    {
                        _loggerService.LogError(ex, "TestPolymorphism");
                        Console.WriteLine($"Error testing polymorphism: {ex.Message}");
                    }
                    break;
                }
                case "12":
                {
                    try
                    {
                        Console.Write("Enter minimum age: ");
                        string? minAgeInput = Console.ReadLine();
                        Console.Write("Enter maximum age: ");
                        string? maxAgeInput = Console.ReadLine();
                        if (byte.TryParse(minAgeInput, out byte minAge) && byte.TryParse(maxAgeInput, out byte maxAge))
                        {
                            _linqService.FilterPatientsByAge(_listPatients, minAge, maxAge);
                        }
                        else
                        {
                            Console.WriteLine("Invalid age format.");
                        }
                    }
                    catch (Exception ex)
                    {
                        _loggerService.LogError(ex, "FilterPatientsByAge");
                        Console.WriteLine($"Error filtering patients by age: {ex.Message}");
                    }
                    break;
                }
                case "13":
                {
                    try
                    {
                        Console.WriteLine("Available pet types:");
                        Console.WriteLine("0 - Dog");
                        Console.WriteLine("1 - Cat");
                        Console.WriteLine("2 - Bird");
                        Console.WriteLine("3 - Hamster");
                        Console.WriteLine("4 - Rabbit");
                        Console.WriteLine("5 - Other");
                        Console.Write("Enter pet type number: ");
                        string? typeInput = Console.ReadLine();
                        if (int.TryParse(typeInput, out int typeNumber) && typeNumber >= 0 && typeNumber <= 5)
                        {
                            PetType type = (PetType)typeNumber;
                            _linqService.FilterPetsByType(_listPets, type);
                        }
                        else
                        {
                            Console.WriteLine("Invalid type number.");
                        }
                    }
                    catch (Exception ex)
                    {
                        _loggerService.LogError(ex, "FilterPetsByType");
                        Console.WriteLine($"Error filtering pets by type: {ex.Message}");
                    }
                    break;
                }
                case "14":
                {
                    try
                    {
                        _linqService.GetPatientNames(_listPatients);
                    }
                    catch (Exception ex)
                    {
                        _loggerService.LogError(ex, "GetPatientNames");
                        Console.WriteLine($"Error getting patient names: {ex.Message}");
                    }
                    break;
                }
                case "15":
                {
                    try
                    {
                        _linqService.OrderPatientsByName(_listPatients);
                    }
                    catch (Exception ex)
                    {
                        _loggerService.LogError(ex, "OrderPatientsByName");
                        Console.WriteLine($"Error ordering patients by name: {ex.Message}");
                    }
                    break;
                }
                case "16":
                {
                    try
                    {
                        _linqService.OrderPatientsByAgeDescending(_listPatients);
                    }
                    catch (Exception ex)
                    {
                        _loggerService.LogError(ex, "OrderPatientsByAgeDescending");
                        Console.WriteLine($"Error ordering patients by age: {ex.Message}");
                    }
                    break;
                }
                case "17":
                {
                    try
                    {
                        _linqService.GroupPatientsByPetType(_listPatients, _listPets);
                    }
                    catch (Exception ex)
                    {
                        _loggerService.LogError(ex, "GroupPatientsByPetType");
                        Console.WriteLine($"Error grouping patients by pet type: {ex.Message}");
                    }
                    break;
                }
                case "18":
                {
                    try
                    {
                        _linqService.GetFirstPatient(_listPatients);
                    }
                    catch (Exception ex)
                    {
                        _loggerService.LogError(ex, "GetFirstPatient");
                        Console.WriteLine($"Error getting first patient: {ex.Message}");
                    }
                    break;
                }
                case "19":
                {
                    try
                    {
                        _linqService.GetFirstPatientOrDefault(_listPatients);
                    }
                    catch (Exception ex)
                    {
                        _loggerService.LogError(ex, "GetFirstPatientOrDefault");
                        Console.WriteLine($"Error getting first patient or default: {ex.Message}");
                    }
                    break;
                }
                case "20":
                {
                    try
                    {
                        Console.Write("Enter age to check: ");
                        string? ageInput = Console.ReadLine();
                        if (byte.TryParse(ageInput, out byte age))
                        {
                            _linqService.CheckAnyPatientWithAge(_listPatients, age);
                        }
                        else
                        {
                            Console.WriteLine("Invalid age format.");
                        }
                    }
                    catch (Exception ex)
                    {
                        _loggerService.LogError(ex, "CheckAnyPatientWithAge");
                        Console.WriteLine($"Error checking patient age: {ex.Message}");
                    }
                    break;
                }
                case "21":
                {
                    try
                    {
                        Console.Write("Enter maximum age to check: ");
                        string? maxAgeInput = Console.ReadLine();
                        if (byte.TryParse(maxAgeInput, out byte maxAge))
                        {
                            _linqService.CheckAllPatientsWithAge(_listPatients, maxAge);
                        }
                        else
                        {
                            Console.WriteLine("Invalid age format.");
                        }
                    }
                    catch (Exception ex)
                    {
                        _loggerService.LogError(ex, "CheckAllPatientsWithAge");
                        Console.WriteLine($"Error checking all patients age: {ex.Message}");
                    }
                    break;
                }
                case "22":
                {
                    try
                    {
                        _linqService.CountPatients(_listPatients);
                    }
                    catch (Exception ex)
                    {
                        _loggerService.LogError(ex, "CountPatients");
                        Console.WriteLine($"Error counting patients: {ex.Message}");
                    }
                    break;
                }
                case "23":
                {
                    try
                    {
                        Console.WriteLine("Available pet types:");
                        Console.WriteLine("0 - Dog");
                        Console.WriteLine("1 - Cat");
                        Console.WriteLine("2 - Bird");
                        Console.WriteLine("3 - Hamster");
                        Console.WriteLine("4 - Rabbit");
                        Console.WriteLine("5 - Other");
                        Console.Write("Enter pet type number: ");
                        string? typeInput = Console.ReadLine();
                        if (int.TryParse(typeInput, out int typeNumber) && typeNumber >= 0 && typeNumber <= 5)
                        {
                            PetType type = (PetType)typeNumber;
                            _linqService.CountPetsByType(_listPets, type);
                        }
                        else
                        {
                            Console.WriteLine("Invalid type number.");
                        }
                    }
                    catch (Exception ex)
                    {
                        _loggerService.LogError(ex, "CountPetsByType");
                        Console.WriteLine($"Error counting pets by type: {ex.Message}");
                    }
                    break;
                }
                case "24":
                {
                    try
                    {
                        _linqService.GetDogOwnersOrderedByAge(_listPatients, _listPets);
                    }
                    catch (Exception ex)
                    {
                        _loggerService.LogError(ex, "GetDogOwnersOrderedByAge");
                        Console.WriteLine($"Error getting dog owners: {ex.Message}");
                    }
                    break;
                }
                case "25":
                {
                    try
                    {
                        _linqService.FindYoungestPatient(_listPatients);
                    }
                    catch (Exception ex)
                    {
                        _loggerService.LogError(ex, "FindYoungestPatient");
                        Console.WriteLine($"Error finding youngest patient: {ex.Message}");
                    }
                    break;
                }
                case "26":
                {
                    try
                    {
                        _linqService.FindOldestPatient(_listPatients);
                    }
                    catch (Exception ex)
                    {
                        _loggerService.LogError(ex, "FindOldestPatient");
                        Console.WriteLine($"Error finding oldest patient: {ex.Message}");
                    }
                    break;
                }
                case "27":
                {
                    try
                    {
                        _linqService.CountPetsByEachType(_listPets);
                    }
                    catch (Exception ex)
                    {
                        _loggerService.LogError(ex, "CountPetsByEachType");
                        Console.WriteLine($"Error counting pets by each type: {ex.Message}");
                    }
                    break;
                }
                case "28":
                {
                    try
                    {
                        _linqService.CheckPatientWithUndefinedPetType(_listPatients, _listPets);
                    }
                    catch (Exception ex)
                    {
                        _loggerService.LogError(ex, "CheckPatientWithUndefinedPetType");
                        Console.WriteLine($"Error checking patient pet type: {ex.Message}");
                    }
                    break;
                }
                case "29":
                {
                    try
                    {
                        _linqService.GetPatientNamesUppercaseOrdered(_listPatients);
                    }
                    catch (Exception ex)
                    {
                        _loggerService.LogError(ex, "GetPatientNamesUppercaseOrdered");
                        Console.WriteLine($"Error getting patient names uppercase: {ex.Message}");
                    }
                    break;
                }
                case "31":
                {
                    try
                    {
                        Console.WriteLine("=== TESTING MULTIPLE INTERFACES ===");
                        if (_listPatients.Count > 0)
                        {
                            var patient = _listPatients[0];
                            Console.WriteLine($"Patient {patient.Name} implements:");
                            Console.WriteLine($"- IRegistrable: {patient is IRegistrable}");
                            Console.WriteLine($"- INotificable: {patient is INotificable}");
                            
                            patient.Register();
                            patient.EnviarNotificacion();
                        }
                        else
                        {
                            Console.WriteLine("No patients registered. Register a patient first.");
                        }
                    }
                    catch (Exception ex)
                    {
                        _loggerService.LogError(ex, "TestMultipleInterfaces");
                        Console.WriteLine($"Error testing multiple interfaces: {ex.Message}");
                    }
                    break;
                }
                case "32":
                {
                    try
                    {
                        Console.WriteLine("=== DEBUGGING: DIVISION BY ZERO ===");
                        Console.WriteLine("This will cause an exception. Use debugger to inspect.");
                        _patientService.DebugDivisionByZero();
                    }
                    catch (DivideByZeroException ex)
                    {
                        _loggerService.LogError(ex, "DebugDivisionByZero");
                        Console.WriteLine($"Caught DivideByZeroException: {ex.Message}");
                        Console.WriteLine("This error was expected for debugging purposes.");
                    }
                    catch (Exception ex)
                    {
                        _loggerService.LogError(ex, "DebugDivisionByZero");
                        Console.WriteLine($"Unexpected error: {ex.Message}");
                    }
                    break;
                }
                case "33":
                {
                    try
                    {
                        Console.WriteLine("=== DEBUGGING: VARIABLE INSPECTION ===");
                        Console.WriteLine("Set breakpoints to inspect variables at runtime.");
                        _patientService.DebugVariableInspection(_listPatients);
                    }
                    catch (Exception ex)
                    {
                        _loggerService.LogError(ex, "DebugVariableInspection");
                        Console.WriteLine($"Error during variable inspection: {ex.Message}");
                    }
                    break;
                }
                case "34":
                    Console.WriteLine("Exiting... Goodbye!");
                    mainMenu = false;
                    break;

                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;

            }
            if (mainMenu)
            {
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }

        }
    }
}


