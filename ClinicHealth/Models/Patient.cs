namespace ClinicHealth.Models;

public class Patient
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public byte Age { get; set; }
    
    private string Address { get; set; }
    public string Phone { get; set; }

    public Patient(string name, byte age, string address,string phone = "")
    {
        Id = Guid.NewGuid();
        Name = name?.Trim().ToLower() ?? "";
        Address = address?.Trim() ?? "";
        Age = age;
        Phone = phone?.Trim() ?? "";
    }

    public void ShowInformation()
    {
        Console.WriteLine($"--- Information The Patient (Owner) ---");
        Console.WriteLine($"Name : {Name}");
        Console.WriteLine($"Age : {Age} Years");
        Console.WriteLine($"Address : {Address}");
        Console.WriteLine($"Phone : {Phone}");
    }
}