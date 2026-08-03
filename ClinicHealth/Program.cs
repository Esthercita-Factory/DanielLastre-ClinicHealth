using ClinicHealth.Models;

Console.WriteLine("Hello, Health Clinic+");

var patient1 = new Patient("jose" , 22 , "nada");



bool mainmenu = true;

while (mainmenu)
{
    Console.WriteLine("1. Register patient");
    Console.WriteLine("2. List patients");
    Console.WriteLine("3. Find a patient");
    Console.WriteLine("4. Exit");
    Console.Write(" Choose an option :");

    string? option  = Console.ReadLine();

    switch (option)
    {
        case "1":
            Console.WriteLine("1. Register patient");
            break;
        case "2":
            Console.WriteLine("2. List patients");
            break;
        case "3":
            Console.WriteLine("3. Find a patient");
            break;
        case "4":
            mainmenu = false;
            break;
        default:
            Console.WriteLine("Invalid option");
            break;
            
    }
    
    



}