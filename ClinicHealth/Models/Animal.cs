namespace ClinicHealth.Models;

public class Animal
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public byte Age { get; set; }
    public PetType Species { get; set; }
    
    public Animal(string name,byte age, PetType type)
    {
        Id = Guid.NewGuid();
        Name = name?.Trim().ToLower() ?? "";
        Age = age;
        Species = type;
        
    }
    public virtual void ShowInformation()
    {
        Console.WriteLine($"--- Information The Animal ---");
        Console.WriteLine($"Id : {Id}");
        Console.WriteLine($"Name : {Name}");
        Console.WriteLine($"Age : {Age} Years");
        Console.WriteLine($"Species : {Species}");
        
    }
}