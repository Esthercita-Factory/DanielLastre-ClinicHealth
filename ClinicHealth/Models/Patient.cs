namespace ClinicHealth.Models;

public class Patient
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public byte Age { get; set; }
    public string Symptom { get; set; }

    public Patient( string name, byte age, string symptom )
    {
        Id = new Guid();
        Name = name.Trim().ToUpper();
        Age = age;
        Symptom = symptom.Trim().ToUpper();
    }
    
}