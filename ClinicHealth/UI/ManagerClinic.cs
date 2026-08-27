using ClinicHealth.Interfaces;
using ClinicHealth.Models;
using ClinicHealth.Repositories;
using ClinicHealth.Services;

namespace ClinicHealth.UI;

public class ManagerClinic
{
    private readonly PatientService _patientService;
    private readonly PetService _petService;
    private readonly LinqService _linqService;
    private readonly LoggerService _loggerService;
    private readonly IPatientRepository _patientRepository;
    private readonly IPetRepository _petRepository;
    private readonly ManagerUser _managerUser;

    public ManagerClinic(PatientService patientService, PetService petService, LinqService linqService, LoggerService loggerService, IPatientRepository patientRepository, IPetRepository petRepository, ManagerUser managerUser)
    {
        _patientService = patientService;
        _petService = petService;
        _linqService = linqService;
        _loggerService = loggerService;
        _patientRepository = patientRepository;
        _petRepository = petRepository;
        _managerUser = managerUser;
    }



    public void ShowMainMenu()
    {
        bool mainMenu = true;

        while (mainMenu)
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                    CLINIC HEALTH SYSTEM                      ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════╝");
            Console.WriteLine();
            Console.WriteLine("  1. User Management");
            Console.WriteLine("  2. Patient Management");
            Console.WriteLine("  3. Pet Management");
            Console.WriteLine("  4. LINQ Queries");
            Console.WriteLine("  5. Practical Problems");
            Console.WriteLine("  6. Debugging Tools");
            Console.WriteLine("  7. Exit");
            Console.WriteLine();
            Console.Write("  Select an option: ");

            string? option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    _managerUser.ShowUserMenu();
                    break;
                case "2":
                    ShowPatientMenu();
                    break;
                case "3":
                    ShowPetMenu();
                    break;
                case "4":
                    ShowLinqMenu();
                    break;
                case "5":
                    ShowPracticalProblemsMenu();
                    break;
                case "6":
                    ShowDebuggingMenu();
                    break;
                case "7":
                    Console.WriteLine("\n  Exiting... Goodbye!");
                    mainMenu = false;
                    break;
                default:
                    Console.WriteLine("\n  Invalid option. Try again.");
                    Console.WriteLine("\n  Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
        }
    }

    private void ShowPatientMenu()
    {
        bool patientMenu = true;
        while (patientMenu)
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                    PATIENT MANAGEMENT                         ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════╝");
            Console.WriteLine();
            Console.WriteLine("  1. Register Patient");
            Console.WriteLine("  2. List Patients");
            Console.WriteLine("  3. Search Patient by Name");
            Console.WriteLine("  4. Delete Patient");
            Console.WriteLine("  5. Update Patient");
            Console.WriteLine("  0. Back to Main Menu");
            Console.WriteLine();
            Console.Write("  Select an option: ");

            string? option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    RegisterPatient();
                    break;
                case "2":
                    ListPatients();
                    break;
                case "3":
                    SearchPatient();
                    break;
                case "4":
                    DeletePatient();
                    break;
                case "5":
                    UpdatePatient();
                    break;
                case "0":
                    patientMenu = false;
                    break;
                default:
                    Console.WriteLine("\n  Invalid option. Try again.");
                    Console.WriteLine("\n  Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
        }
    }

    private void ShowPetMenu()
    {
        bool petMenu = true;
        while (petMenu)
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                       PET MANAGEMENT                        ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════╝");
            Console.WriteLine();
            Console.WriteLine("  1. Register Pet");
            Console.WriteLine("  2. List Pets");
            Console.WriteLine("  3. Delete Pet");
            Console.WriteLine("  4. Update Pet");
            Console.WriteLine("  5. Show Patient's Pets");
            Console.WriteLine("  6. Test Polymorphism (Animal Sounds)");
            Console.WriteLine("  0. Back to Main Menu");
            Console.WriteLine();
            Console.Write("  Select an option: ");

            string? option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    RegisterPet();
                    break;
                case "2":
                    ListPets();
                    break;
                case "3":
                    DeletePet();
                    break;
                case "4":
                    UpdatePet();
                    break;
                case "5":
                    ShowPatientPets();
                    break;
                case "6":
                    TestPolymorphism();
                    break;
                case "0":
                    petMenu = false;
                    break;
                default:
                    Console.WriteLine("\n  Invalid option. Try again.");
                    Console.WriteLine("\n  Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
        }
    }

    private void ShowLinqMenu()
    {
        bool linqMenu = true;
        while (linqMenu)
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                       LINQ QUERIES                           ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════╝");
            Console.WriteLine();
            Console.WriteLine("  1. Filter Patients by Age (Where)");
            Console.WriteLine("  2. Filter Pets by Type (Where)");
            Console.WriteLine("  3. Get Patient Names (Select)");
            Console.WriteLine("  4. Order Patients by Name (OrderBy)");
            Console.WriteLine("  5. Order Patients by Age Descending (OrderByDescending)");
            Console.WriteLine("  6. Group Patients by Pet Type (GroupBy)");
            Console.WriteLine("  7. Get First Patient (First)");
            Console.WriteLine("  8. Get First Patient or Default (FirstOrDefault)");
            Console.WriteLine("  9. Check Any Patient with Age (Any)");
            Console.WriteLine(" 10. Check All Patients with Age (All)");
            Console.WriteLine(" 11. Count Patients (Count)");
            Console.WriteLine(" 12. Count Pets by Type (Count)");
            Console.WriteLine(" 13. Dog Owners Ordered by Age (Combined Query)");
            Console.WriteLine("  0. Back to Main Menu");
            Console.WriteLine();
            Console.Write("  Select an option: ");

            string? option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    FilterPatientsByAge();
                    break;
                case "2":
                    FilterPetsByType();
                    break;
                case "3":
                    GetPatientNames();
                    break;
                case "4":
                    OrderPatientsByName();
                    break;
                case "5":
                    OrderPatientsByAgeDescending();
                    break;
                case "6":
                    GroupPatientsByPetType();
                    break;
                case "7":
                    GetFirstPatient();
                    break;
                case "8":
                    GetFirstPatientOrDefault();
                    break;
                case "9":
                    CheckAnyPatientWithAge();
                    break;
                case "10":
                    CheckAllPatientsWithAge();
                    break;
                case "11":
                    CountPatients();
                    break;
                case "12":
                    CountPetsByType();
                    break;
                case "13":
                    GetDogOwnersOrderedByAge();
                    break;
                case "0":
                    linqMenu = false;
                    break;
                default:
                    Console.WriteLine("\n  Invalid option. Try again.");
                    Console.WriteLine("\n  Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
        }
    }

    private void ShowPracticalProblemsMenu()
    {
        bool practicalMenu = true;
        while (practicalMenu)
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                    PRACTICAL PROBLEMS                         ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════╝");
            Console.WriteLine();
            Console.WriteLine("  1. Find Youngest Patient");
            Console.WriteLine("  2. Find Oldest Patient");
            Console.WriteLine("  3. Count Pets by Each Type");
            Console.WriteLine("  4. Check Patient with Undefined Pet Type");
            Console.WriteLine("  5. Patient Names in Uppercase Ordered");
            Console.WriteLine("  0. Back to Main Menu");
            Console.WriteLine();
            Console.Write("  Select an option: ");

            string? option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    FindYoungestPatient();
                    break;
                case "2":
                    FindOldestPatient();
                    break;
                case "3":
                    CountPetsByEachType();
                    break;
                case "4":
                    CheckPatientWithUndefinedPetType();
                    break;
                case "5":
                    GetPatientNamesUppercaseOrdered();
                    break;
                case "0":
                    practicalMenu = false;
                    break;
                default:
                    Console.WriteLine("\n  Invalid option. Try again.");
                    Console.WriteLine("\n  Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
        }
    }

    private void ShowDebuggingMenu()
    {
        bool debugMenu = true;
        while (debugMenu)
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                      DEBUGGING TOOLS                          ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════╝");
            Console.WriteLine();
            Console.WriteLine("  1. Test Multiple Interfaces");
            Console.WriteLine("  2. Debug: Division by Zero Error");
            Console.WriteLine("  3. Debug: Variable Inspection");
            Console.WriteLine("  0. Back to Main Menu");
            Console.WriteLine();
            Console.Write("  Select an option: ");

            string? option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    TestMultipleInterfaces();
                    break;
                case "2":
                    DebugDivisionByZero();
                    break;
                case "3":
                    DebugVariableInspection();
                    break;
                case "0":
                    debugMenu = false;
                    break;
                default:
                    Console.WriteLine("\n  Invalid option. Try again.");
                    Console.WriteLine("\n  Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
        }
    }

    private void PressToContinue()
    {
        Console.WriteLine("\n  Press any key to continue...");
        Console.ReadKey();
    }

    // Patient Operations
    private void RegisterPatient()
    {
        try
        {
            Console.WriteLine("\n  Register New Patient");
            Console.WriteLine("  " + new string('─', 40));
            var name = EntradaDeConsola.LeerTextoObligatorio("  Enter patient name: ");
            var age = EntradaDeConsola.LeerByte("  Enter patient age: ");
            var address = EntradaDeConsola.LeerTextoObligatorio("  Enter patient address: ");
            var phone = EntradaDeConsola.LeerTextoOpcional("  Enter patient phone: ");
            _patientService.Register(name, age, address, phone);
        }
        catch (Exception ex)
        {
            _loggerService.LogError(ex, "Registrar");
            Console.WriteLine($"  Error registering patient: {ex.Message}");
        }
        PressToContinue();
    }

    private void ListPatients()
    {
        try
        {
            Console.WriteLine("\n  Patient List");
            Console.WriteLine("  " + new string('─', 40));
            _patientService.List();
        }
        catch (Exception ex)
        {
            _loggerService.LogError(ex, "Listar");
            Console.WriteLine($"  Error listing patients: {ex.Message}");
        }
        PressToContinue();
    }

    private void SearchPatient()
    {
        try
        {
            Console.WriteLine("\n  Search Patient");
            Console.WriteLine("  " + new string('─', 40));
            var name = EntradaDeConsola.LeerTextoObligatorio("  Enter patient name to search: ");
            _patientService.SearchByName(name);
        }
        catch (Exception ex)
        {
            _loggerService.LogError(ex, "BuscarPorNombre");
            Console.WriteLine($"  Error searching patient: {ex.Message}");
        }
        PressToContinue();
    }

    private void DeletePatient()
    {
        try
        {
            Console.WriteLine("\n  Delete Patient");
            Console.WriteLine("  " + new string('─', 40));
            var patientId = EntradaDeConsola.LeerGuid("  Enter patient ID to delete: ");
            _patientService.Delete(patientId);
        }
        catch (Exception ex)
        {
            _loggerService.LogError(ex, "Eliminar");
            Console.WriteLine($"  Error deleting patient: {ex.Message}");
        }
        PressToContinue();
    }

    private void UpdatePatient()
    {
        try
        {
            Console.WriteLine("\n  Update Patient");
            Console.WriteLine("  " + new string('─', 40));
            var patientId = EntradaDeConsola.LeerGuid("  Enter patient ID to update: ");
            var name = EntradaDeConsola.LeerTextoObligatorio("  Enter new patient name: ");
            var age = EntradaDeConsola.LeerByte("  Enter new patient age: ");
            var address = EntradaDeConsola.LeerTextoObligatorio("  Enter new patient address: ");
            var phone = EntradaDeConsola.LeerTextoOpcional("  Enter new patient phone: ");
            _patientService.Update(patientId, name, age, address, phone);
        }
        catch (Exception ex)
        {
            _loggerService.LogError(ex, "Actualizar");
            Console.WriteLine($"  Error updating patient: {ex.Message}");
        }
        PressToContinue();
    }

    // Pet Operations
    private void RegisterPet()
    {
        try
        {
            Console.WriteLine("\n  Register New Pet");
            Console.WriteLine("  " + new string('─', 40));
            var patientId = EntradaDeConsola.LeerGuid("  Enter patient ID to register pet: ");
            var name = EntradaDeConsola.LeerTextoObligatorio("  Enter pet name: ");
            var age = EntradaDeConsola.LeerByte("  Enter pet age: ", 1, 255);
            var type = EntradaDeConsola.LeerEnum<PetType>("  Enter pet type number: ");
            var symptom = EntradaDeConsola.LeerTextoObligatorio("  Enter pet symptom: ");
            var race = EntradaDeConsola.LeerEnum<Race>("  Enter race number: ");
            _petService.Register(patientId, name, age, type, symptom, race);
        }
        catch (Exception ex)
        {
            _loggerService.LogError(ex, "Registrar");
            Console.WriteLine($"  Error registering pet: {ex.Message}");
        }
        PressToContinue();
    }

    private void ListPets()
    {
        try
        {
            Console.WriteLine("\n  Pet List");
            Console.WriteLine("  " + new string('─', 40));
            _petService.List();
        }
        catch (Exception ex)
        {
            _loggerService.LogError(ex, "Listar");
            Console.WriteLine($"  Error listing pets: {ex.Message}");
        }
        PressToContinue();
    }

    private void DeletePet()
    {
        try
        {
            Console.WriteLine("\n  Delete Pet");
            Console.WriteLine("  " + new string('─', 40));
            var petId = EntradaDeConsola.LeerGuid("  Enter pet ID to delete: ");
            _petService.Delete(petId);
        }
        catch (Exception ex)
        {
            _loggerService.LogError(ex, "Eliminar");
            Console.WriteLine($"  Error deleting pet: {ex.Message}");
        }
        PressToContinue();
    }

    private void UpdatePet()
    {
        try
        {
            Console.WriteLine("\n  Update Pet");
            Console.WriteLine("  " + new string('─', 40));
            var petId = EntradaDeConsola.LeerGuid("  Enter pet ID to update: ");
            var name = EntradaDeConsola.LeerTextoObligatorio("  Enter new pet name: ");
            var age = EntradaDeConsola.LeerByte("  Enter new pet age: ", 1, 255);
            var type = EntradaDeConsola.LeerEnum<PetType>("  Enter new pet type number: ");
            var symptom = EntradaDeConsola.LeerTextoObligatorio("  Enter new pet symptom: ");
            var race = EntradaDeConsola.LeerEnum<Race>("  Enter race number: ");
            _petService.Update(petId, name, age, type, symptom, race);
        }
        catch (Exception ex)
        {
            _loggerService.LogError(ex, "Actualizar");
            Console.WriteLine($"  Error updating pet: {ex.Message}");
        }
        PressToContinue();
    }

    private void ShowPatientPets()
    {
        try
        {
            Console.WriteLine("\n  Show Patient's Pets");
            Console.WriteLine("  " + new string('─', 40));
            var patientId = EntradaDeConsola.LeerGuid("  Enter patient ID to show pets: ");
            _petService.ListByOwner(patientId);
        }
        catch (Exception ex)
        {
            _loggerService.LogError(ex, "ListarPorDueno");
            Console.WriteLine($"  Error showing patient pets: {ex.Message}");
        }
        PressToContinue();
    }

    private void TestPolymorphism()
    {
        try
        {
            Console.WriteLine("\n  Testing Polymorphism - Animal Sounds");
            Console.WriteLine("  " + new string('─', 40));
            _petService.TestPolymorphism();
        }
        catch (Exception ex)
        {
            _loggerService.LogError(ex, "TestPolimorfismo");
            Console.WriteLine($"  Error testing polymorphism: {ex.Message}");
        }
        PressToContinue();
    }

    // LINQ Operations
    private void FilterPatientsByAge()
    {
        try
        {
            Console.WriteLine("\n  Filter Patients by Age");
            Console.WriteLine("  " + new string('─', 40));
            var minAge = EntradaDeConsola.LeerByte("  Enter minimum age: ");
            var maxAge = EntradaDeConsola.LeerByte("  Enter maximum age: ");
            var patients = _patientRepository.GetAll();
            _linqService.FilterPatientsByAge(patients, minAge, maxAge);
        }
        catch (Exception ex)
        {
            _loggerService.LogError(ex, "FilterPatientsByAge");
            Console.WriteLine($"  Error filtering patients by age: {ex.Message}");
        }
        PressToContinue();
    }

    private void FilterPetsByType()
    {
        try
        {
            Console.WriteLine("\n  Filter Pets by Type");
            Console.WriteLine("  " + new string('─', 40));
            var type = EntradaDeConsola.LeerEnum<PetType>("  Enter pet type number: ");
            var pets = _petRepository.GetAll();
            _linqService.FilterPetsByType(pets, type);
        }
        catch (Exception ex)
        {
            _loggerService.LogError(ex, "FilterPetsByType");
            Console.WriteLine($"  Error filtering pets by type: {ex.Message}");
        }
        PressToContinue();
    }

    private void GetPatientNames()
    {
        try
        {
            Console.WriteLine("\n  Get Patient Names");
            Console.WriteLine("  " + new string('─', 40));
            var patients = _patientRepository.GetAll();
            _linqService.GetPatientNames(patients);
        }
        catch (Exception ex)
        {
            _loggerService.LogError(ex, "GetPatientNames");
            Console.WriteLine($"  Error getting patient names: {ex.Message}");
        }
        PressToContinue();
    }

    private void OrderPatientsByName()
    {
        try
        {
            Console.WriteLine("\n  Order Patients by Name");
            Console.WriteLine("  " + new string('─', 40));
            var patients = _patientRepository.GetAll();
            _linqService.OrderPatientsByName(patients);
        }
        catch (Exception ex)
        {
            _loggerService.LogError(ex, "OrderPatientsByName");
            Console.WriteLine($"  Error ordering patients by name: {ex.Message}");
        }
        PressToContinue();
    }

    private void OrderPatientsByAgeDescending()
    {
        try
        {
            Console.WriteLine("\n  Order Patients by Age Descending");
            Console.WriteLine("  " + new string('─', 40));
            var patients = _patientRepository.GetAll();
            _linqService.OrderPatientsByAgeDescending(patients);
        }
        catch (Exception ex)
        {
            _loggerService.LogError(ex, "OrderPatientsByAgeDescending");
            Console.WriteLine($"  Error ordering patients by age: {ex.Message}");
        }
        PressToContinue();
    }

    private void GroupPatientsByPetType()
    {
        try
        {
            Console.WriteLine("\n  Group Patients by Pet Type");
            Console.WriteLine("  " + new string('─', 40));
            var patients = _patientRepository.GetAll();
            var pets = _petRepository.GetAll();
            _linqService.GroupPatientsByPetType(patients, pets);
        }
        catch (Exception ex)
        {
            _loggerService.LogError(ex, "GroupPatientsByPetType");
            Console.WriteLine($"  Error grouping patients by pet type: {ex.Message}");
        }
        PressToContinue();
    }

    private void GetFirstPatient()
    {
        try
        {
            Console.WriteLine("\n  Get First Patient");
            Console.WriteLine("  " + new string('─', 40));
            var patients = _patientRepository.GetAll();
            _linqService.GetFirstPatient(patients);
        }
        catch (Exception ex)
        {
            _loggerService.LogError(ex, "GetFirstPatient");
            Console.WriteLine($"  Error getting first patient: {ex.Message}");
        }
        PressToContinue();
    }

    private void GetFirstPatientOrDefault()
    {
        try
        {
            Console.WriteLine("\n  Get First Patient or Default");
            Console.WriteLine("  " + new string('─', 40));
            var patients = _patientRepository.GetAll();
            _linqService.GetFirstPatientOrDefault(patients);
        }
        catch (Exception ex)
        {
            _loggerService.LogError(ex, "GetFirstPatientOrDefault");
            Console.WriteLine($"  Error getting first patient or default: {ex.Message}");
        }
        PressToContinue();
    }

    private void CheckAnyPatientWithAge()
    {
        try
        {
            Console.WriteLine("\n  Check Any Patient with Age");
            Console.WriteLine("  " + new string('─', 40));
            var age = EntradaDeConsola.LeerByte("  Enter age to check: ");
            var patients = _patientRepository.GetAll();
            _linqService.CheckAnyPatientWithAge(patients, age);
        }
        catch (Exception ex)
        {
            _loggerService.LogError(ex, "CheckAnyPatientWithAge");
            Console.WriteLine($"  Error checking patient age: {ex.Message}");
        }
        PressToContinue();
    }

    private void CheckAllPatientsWithAge()
    {
        try
        {
            Console.WriteLine("\n  Check All Patients with Age");
            Console.WriteLine("  " + new string('─', 40));
            var maxAge = EntradaDeConsola.LeerByte("  Enter maximum age to check: ");
            var patients = _patientRepository.GetAll();
            _linqService.CheckAllPatientsWithAge(patients, maxAge);
        }
        catch (Exception ex)
        {
            _loggerService.LogError(ex, "CheckAllPatientsWithAge");
            Console.WriteLine($"  Error checking all patients age: {ex.Message}");
        }
        PressToContinue();
    }

    private void CountPatients()
    {
        try
        {
            Console.WriteLine("\n  Count Patients");
            Console.WriteLine("  " + new string('─', 40));
            _linqService.CountPatients(_patientRepository.GetAll());
        }
        catch (Exception ex)
        {
            _loggerService.LogError(ex, "CountPatients");
            Console.WriteLine($"  Error counting patients: {ex.Message}");
        }
        PressToContinue();
    }

    private void CountPetsByType()
    {
        try
        {
            Console.WriteLine("\n  Count Pets by Type");
            Console.WriteLine("  " + new string('─', 40));
            var type = EntradaDeConsola.LeerEnum<PetType>("  Enter pet type number: ");
            var pets = _petRepository.GetAll();
            _linqService.CountPetsByType(pets, type);
        }
        catch (Exception ex)
        {
            _loggerService.LogError(ex, "CountPetsByType");
            Console.WriteLine($"  Error counting pets by type: {ex.Message}");
        }
        PressToContinue();
    }

    private void GetDogOwnersOrderedByAge()
    {
        try
        {
            Console.WriteLine("\n  Dog Owners Ordered by Age");
            Console.WriteLine("  " + new string('─', 40));
            var patients = _patientRepository.GetAll();
            var pets = _petRepository.GetAll();
            _linqService.GetDogOwnersOrderedByAge(patients, pets);
        }
        catch (Exception ex)
        {
            _loggerService.LogError(ex, "GetDogOwnersOrderedByAge");
            Console.WriteLine($"  Error getting dog owners: {ex.Message}");
        }
        PressToContinue();
    }

    // Practical Problems
    private void FindYoungestPatient()
    {
        try
        {
            Console.WriteLine("\n  Find Youngest Patient");
            Console.WriteLine("  " + new string('─', 40));
            var patients = _patientRepository.GetAll();
            _linqService.FindYoungestPatient(patients);
        }
        catch (Exception ex)
        {
            _loggerService.LogError(ex, "FindYoungestPatient");
            Console.WriteLine($"  Error finding youngest patient: {ex.Message}");
        }
        PressToContinue();
    }

    private void FindOldestPatient()
    {
        try
        {
            Console.WriteLine("\n  Find Oldest Patient");
            Console.WriteLine("  " + new string('─', 40));
            var patients = _patientRepository.GetAll();
            _linqService.FindOldestPatient(patients);
        }
        catch (Exception ex)
        {
            _loggerService.LogError(ex, "FindOldestPatient");
            Console.WriteLine($"  Error finding oldest patient: {ex.Message}");
        }
        PressToContinue();
    }

    private void CountPetsByEachType()
    {
        try
        {
            Console.WriteLine("\n  Count Pets by Each Type");
            Console.WriteLine("  " + new string('─', 40));
            var pets = _petRepository.GetAll();
            _linqService.CountPetsByEachType(pets);
        }
        catch (Exception ex)
        {
            _loggerService.LogError(ex, "CountPetsByEachType");
            Console.WriteLine($"  Error counting pets by each type: {ex.Message}");
        }
        PressToContinue();
    }

    private void CheckPatientWithUndefinedPetType()
    {
        try
        {
            Console.WriteLine("\n  Check Patient with Undefined Pet Type");
            Console.WriteLine("  " + new string('─', 40));
            var patients = _patientRepository.GetAll();
            var pets = _petRepository.GetAll();
            _linqService.CheckPatientWithUndefinedPetType(patients, pets);
        }
        catch (Exception ex)
        {
            _loggerService.LogError(ex, "CheckPatientWithUndefinedPetType");
            Console.WriteLine($"  Error checking patient pet type: {ex.Message}");
        }
        PressToContinue();
    }

    private void GetPatientNamesUppercaseOrdered()
    {
        try
        {
            Console.WriteLine("\n  Patient Names in Uppercase Ordered");
            Console.WriteLine("  " + new string('─', 40));
            var patients = _patientRepository.GetAll();
            _linqService.GetPatientNamesUppercaseOrdered(patients);
        }
        catch (Exception ex)
        {
            _loggerService.LogError(ex, "GetPatientNamesUppercaseOrdered");
            Console.WriteLine($"  Error getting patient names uppercase: {ex.Message}");
        }
        PressToContinue();
    }

    // Debugging Operations
    private void TestMultipleInterfaces()
    {
        try
        {
            Console.WriteLine("\n  Testing Multiple Interfaces");
            Console.WriteLine("  " + new string('─', 40));
            var patients = _patientRepository.GetAll();
            if (patients.Count > 0)
            {
                var patient = patients[0];
                Console.WriteLine($"  Patient {patient.Name} implements:");
                Console.WriteLine($"  - IRegistrable: {patient is IRegistrable}");
                Console.WriteLine($"  - INotificable: {patient is INotificable}");
                
                patient.Register();
                patient.EnviarNotificacion();
            }
            else
            {
                Console.WriteLine("  No patients registered. Register a patient first.");
            }
        }
        catch (Exception ex)
        {
            _loggerService.LogError(ex, "TestMultipleInterfaces");
            Console.WriteLine($"  Error testing multiple interfaces: {ex.Message}");
        }
        PressToContinue();
    }

    private void DebugDivisionByZero()
    {
        try
        {
            Console.WriteLine("\n  Debug: Division by Zero");
            Console.WriteLine("  " + new string('─', 40));
            Console.WriteLine("  This will cause an exception. Use debugger to inspect.");
            _patientService.DebugDivisionByZero();
        }
        catch (DivideByZeroException ex)
        {
            _loggerService.LogError(ex, "DebugDivisionByZero");
            Console.WriteLine($"  Caught DivideByZeroException: {ex.Message}");
            Console.WriteLine("  This error was expected for debugging purposes.");
        }
        catch (Exception ex)
        {
            _loggerService.LogError(ex, "DebugDivisionByZero");
            Console.WriteLine($"  Unexpected error: {ex.Message}");
        }
        PressToContinue();
    }

    private void DebugVariableInspection()
    {
        try
        {
            Console.WriteLine("\n  Debug: Variable Inspection");
            Console.WriteLine("  " + new string('─', 40));
            Console.WriteLine("  Set breakpoints to inspect variables at runtime.");
            _patientService.DebugVariableInspection();
        }
        catch (Exception ex)
        {
            _loggerService.LogError(ex, "DebugVariableInspection");
            Console.WriteLine($"  Error during variable inspection: {ex.Message}");
        }
        PressToContinue();
    }
}


