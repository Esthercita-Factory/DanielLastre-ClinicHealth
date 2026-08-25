namespace ClinicHealth.Models;

public class Animal
{
    private Guid _id;
    private string _name;
    private byte _age;
    private PetType _species;

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

    public PetType Species
    {
        get { return _species; }
        set { _species = value; }
    }

    public Animal(string name, byte age, PetType type)
    {
        _id = Guid.NewGuid();
        _name = name?.Trim().ToLower() ?? "";
        _age = age;
        _species = type;
    }

    public virtual void ShowInformation()
    {
        Console.WriteLine($"--- Information The Animal ---");
        Console.WriteLine($"Id : {Id}");
        Console.WriteLine($"Name : {Name}");
        Console.WriteLine($"Age : {Age} Years");
        Console.WriteLine($"Species : {Species}");
    }

    public virtual void MakeSound()
    {
        Console.WriteLine("The animal makes a generic sound.");
    }
}