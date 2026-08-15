namespace ClinicHealth.UI;

public class ManagerClinic
{
    public void ShowMainMenu()
    {
        bool mainMenu = true;

        while (mainMenu)
        {
            
            Console.WriteLine("=== HEALTH MAIN MENU ===");
            Console.WriteLine("1. Register Patien");
            Console.WriteLine("2. List Patien");
            Console.WriteLine("3. Search Patien");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");
            
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                {
                    Console.WriteLine("Register Patien");
                    break;
                }
                case "2":
                {
                    Console.WriteLine("List Patien");
                    break;
                }
                case "3":
                {
                    Console.WriteLine("Search Patien");
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


