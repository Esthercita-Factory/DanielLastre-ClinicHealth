using ClinicHealth.Models;
using ClinicHealth.Services;

namespace ClinicHealth.UI;

public class ManagerClinic
{
    public ManagerClinic()
    {
        
    }
    
    private PatientService _patientService;
    private List<Patient> _listPatients;
    public ManagerClinic(PatientService patientService , List<Patient> listPatients)  
    {
        _patientService = patientService; 
        _listPatients = listPatients;
    }



    public void ShowMainMenu()
    {
        bool mainMenu = true;

        while (mainMenu)
        {
            
            Console.WriteLine("=== HEALTH MAIN MENU ===");
            Console.WriteLine("1. Register Patient");
            Console.WriteLine("2. List Patien");
            Console.WriteLine("3. Search Patien");
            Console.WriteLine("4. Exit");
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


