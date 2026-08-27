using ClinicHealth.Interfaces;
using ClinicHealth.Models;
using ClinicHealth.Repositories;
using ClinicHealth.Services;

namespace ClinicHealth.UI;

public class ManagerUser
{
    private readonly PatientService _patientService;
    private readonly PetService _petService;
    private readonly IPatientRepository _patientRepository;
    private readonly IPetRepository _petRepository;
    private readonly LoggerService _loggerService;

    public ManagerUser(PatientService patientService, PetService petService, IPatientRepository patientRepository, IPetRepository petRepository, LoggerService loggerService)
    {
        _patientService = patientService;
        _petService = petService;
        _patientRepository = patientRepository;
        _petRepository = petRepository;
        _loggerService = loggerService;
    }

    public void ShowUserMenu()
    {
        Console.WriteLine("╔════════════════════════════════════════════════╗");
        Console.WriteLine("║         CLINIC HEALTH MANAGEMENT SYSTEM          ║");
        Console.WriteLine("║              Pet Management System                ║");
        Console.WriteLine("╠════════════════════════════════════════════════╣");
        Console.WriteLine("║                                                ║");
        Console.WriteLine("║  [1]  Register a new pet                        ║");
        Console.WriteLine("║  [2]  List registered pets                      ║");
        Console.WriteLine("║  [3]  Register a new patient                    ║");
        Console.WriteLine("║  [4]  List registered patients                  ║");
        Console.WriteLine("║                                                ║");
        Console.WriteLine("║  --------------------------------------------  ║");
        Console.WriteLine("║                                                ║");
        Console.WriteLine("║  [0]  Back to main menu                         ║");
        Console.WriteLine("║                                                ║");
        Console.WriteLine("╚════════════════════════════════════════════════╝");
        Console.WriteLine();
        Console.Write("  >> Select an option: ");

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
                RegisterPatient();
                break;
            case "4":
                ListPatients();
                break;
            case "0":
                break;
            default:
                Console.WriteLine("\n  Invalid option. Try again.");
                Console.WriteLine("\n  Press any key to continue...");
                Console.ReadKey();
                break;
        }
    }

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

    private void PressToContinue()
    {
        Console.WriteLine("\n  Press any key to continue...");
        Console.ReadKey();
    }
}