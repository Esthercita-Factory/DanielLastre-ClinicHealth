using ClinicHealth.Models;
using ClinicHealth.Services;

namespace ClinicHealth.UI;

public class ManagerClinic
{
    public ManagerClinic()
    {

    }

    private PatientService _patientService;
    private PetService _petService;
    private LinqService _linqService;
    private List<Patient> _listPatients;
    private List<Pet> _listPets;
    private Dictionary<Guid, Patient> _patientDictionary;

    public ManagerClinic(PatientService patientService, PetService petService, LinqService linqService, List<Patient> listPatients, List<Pet> listPets, Dictionary<Guid, Patient> patientDictionary)
    {
        _patientService = patientService;
        _petService = petService;
        _linqService = linqService;
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
            Console.WriteLine("=== EXIT ===");
            Console.WriteLine("30. Exit");
            Console.Write("Choose an option: ");

            string? option = Console.ReadLine();

            switch (option)
            {
                case "1":
                {
                    _patientService.RegisterPatient(_listPatients);
                    break;
                }
                case "2":
                {
                    _patientService.ListPatient(_listPatients);

                    break;
                }
                case "3":
                {
                    Console.Write("Enter patient name to search: ");
                    string? name = Console.ReadLine();
                    _patientService.SearchPatientByName(_listPatients, name);
                    break;
                }
                case "4":
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
                    break;
                }
                case "5":
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
                    break;
                }
                case "6":
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
                    break;
                }
                case "7":
                {
                    Console.WriteLine("=== PETS LIST ===");
                    foreach (var pet in _listPets)
                    {
                        Console.WriteLine($"Id: {pet.Id}, Name: {pet.Name}, Type: {pet.Species}, Symptom: {pet.Symptom}, PatientId: {pet.PatientId}");
                    }
                    break;
                }
                case "8":
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
                    break;
                }
                case "9":
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
                    break;
                }
                case "10":
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
                    break;
                }
                case "11":
                {
                    _petService.TestPolymorphism(_listPets);
                    break;
                }
                case "12":
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
                    break;
                }
                case "13":
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
                    break;
                }
                case "14":
                {
                    _linqService.GetPatientNames(_listPatients);
                    break;
                }
                case "15":
                {
                    _linqService.OrderPatientsByName(_listPatients);
                    break;
                }
                case "16":
                {
                    _linqService.OrderPatientsByAgeDescending(_listPatients);
                    break;
                }
                case "17":
                {
                    _linqService.GroupPatientsByPetType(_listPatients, _listPets);
                    break;
                }
                case "18":
                {
                    _linqService.GetFirstPatient(_listPatients);
                    break;
                }
                case "19":
                {
                    _linqService.GetFirstPatientOrDefault(_listPatients);
                    break;
                }
                case "20":
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
                    break;
                }
                case "21":
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
                    break;
                }
                case "22":
                {
                    _linqService.CountPatients(_listPatients);
                    break;
                }
                case "23":
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
                    break;
                }
                case "24":
                {
                    _linqService.GetDogOwnersOrderedByAge(_listPatients, _listPets);
                    break;
                }
                case "25":
                {
                    _linqService.FindYoungestPatient(_listPatients);
                    break;
                }
                case "26":
                {
                    _linqService.FindOldestPatient(_listPatients);
                    break;
                }
                case "27":
                {
                    _linqService.CountPetsByEachType(_listPets);
                    break;
                }
                case "28":
                {
                    _linqService.CheckPatientWithUndefinedPetType(_listPatients, _listPets);
                    break;
                }
                case "29":
                {
                    _linqService.GetPatientNamesUppercaseOrdered(_listPatients);
                    break;
                }
                case "30":
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


