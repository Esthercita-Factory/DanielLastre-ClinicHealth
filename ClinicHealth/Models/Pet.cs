namespace ClinicHealth.Models;

public class Pet : Animal
{
    public Guid PatientId { get; set; }
    public Race Race { get; set; }
    public string Symptom { get; set; }

   
    public Pet(string name, byte age, PetType species, string symptom, Guid patientId, Race race) 
        : base(name, age, species)
    {
        Symptom = symptom?.Trim().ToLower() ?? "";
        PatientId = patientId;
        Race = race;
    }
    
    
    public override void ShowInformation()
    {
        base.ShowInformation();

        
        Console.WriteLine($"Symptom : {Symptom}");
        Console.WriteLine($"Patient ID : {PatientId}");
        Console.WriteLine($"Race : {Race}");
    }
}

