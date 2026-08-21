namespace ClinicHealth.Models;

public class Pet
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public PetType Type { get; set; }
    public string Symptom { get; set; }
    public Guid PatientId { get; set; }

    public Pet(string name, PetType type, string symptom, Guid patientId)
    {
        Id = Guid.NewGuid();
        Name = name?.Trim().ToLower() ?? "";
        Type = type;
        Symptom = symptom?.Trim().ToLower() ?? "";
        PatientId = patientId;
    }
}
