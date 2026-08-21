namespace ClinicHealth.Models;

public class Pet
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public string Symptom { get; set; }
    public Guid PatientId { get; set; }

    public Pet(string name, string type, string symptom, Guid patientId)
    {
        Id = Guid.NewGuid();
        Name = name?.Trim().ToLower() ?? "";
        Type = type?.Trim().ToLower() ?? "";
        Symptom = symptom?.Trim().ToLower() ?? "";
        PatientId = patientId;
    }
}
