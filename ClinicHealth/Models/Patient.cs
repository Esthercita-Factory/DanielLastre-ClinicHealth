using ClinicHealth.Interfaces;

namespace ClinicHealth.Models;

public class Patient : IRegistrable, INotificable 
{
    private Guid _id;
    private string _name;
    private byte _age;
    private string _address;
    private string _phone;
    private List<Pet> _pets;

    public Guid Id
    {
        get { return _id; }
        set { _id = value; }
    }

    public string Name
    {
        get { return _name; }
        set { _name = value?.Trim().ToLower() ?? ""; }
    }

    public byte Age
    {
        get { return _age; }
        set { _age = value; }
    }

    public string Address
    {
        get { return _address; }
        set { _address = value?.Trim() ?? ""; }
    }

    public string Phone
    {
        get { return _phone; }
        set { _phone = value?.Trim() ?? ""; }
    }

    public List<Pet> Pets
    {
        get { return _pets; }
        set { _pets = value; }
    }

    public Patient(string name, byte age, string address, string phone = "")
    {
        _id = Guid.NewGuid();
        _name = name?.Trim().ToLower() ?? "";
        _address = address?.Trim() ?? "";
        _age = age;
        _phone = phone?.Trim() ?? "";
        _pets = new List<Pet>();
    }

    public void ShowInformation()
    {
        Console.WriteLine($"--- Information The Patient (Owner) ---");
        Console.WriteLine($"Name : {Name}");
        Console.WriteLine($"Age : {Age} Years");
        Console.WriteLine($"Address : {Address}");
        Console.WriteLine($"Phone : {Phone}");
    }

    public void ShowPets()
    {
        Console.WriteLine($"--- PETS OF {Name.ToUpper()} ---");
        if (Pets.Count == 0)
        {
            Console.WriteLine("No pets registered for this patient.");
        }
        else
        {
            foreach (var pet in Pets)
            {
                pet.ShowInformation();
                Console.WriteLine();
            }
            Console.WriteLine($"Total pets: {Pets.Count}");
        }
    }

    public void Register()
    {
        Console.WriteLine($"=== REGISTERING PATIENT ===");
        Console.WriteLine($"Patient registered successfully:");
        Console.WriteLine($"ID: {Id}");
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Age: {Age}");
        Console.WriteLine($"Address: {Address}");
        Console.WriteLine($"Phone: {Phone}");
    }

    public void EnviarNotificacion()
    {
        Console.WriteLine($"=== ENVIANDO NOTIFICACIÓN ===");
        Console.WriteLine($"Enviando recordatorio de cita al paciente: {Name}");
        Console.WriteLine($"Teléfono: {Phone}");
        Console.WriteLine($"Notificación enviada exitosamente.");
    }
}