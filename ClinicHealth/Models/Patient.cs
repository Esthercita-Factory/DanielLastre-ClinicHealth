namespace ClinicHealth.Models;

public class Patient
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public byte Age { get; set; }
    public string Phone { get; set; }

    public Patient(string name, byte age, string phone = "")
    {
        Id = Guid.NewGuid();
        Name = name?.Trim().ToLower() ?? "";
        Age = age;
        Phone = phone?.Trim() ?? "";
    }
}