namespace ClinicHealth.Models;

public  class Patient
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public byte Age { get; set; }

    public Patient( string name, byte age )
    {
        Id = Guid.NewGuid();
        Name = name?.Trim().ToLower() ?? "";
        Age = age;
    }
    
    
    
}