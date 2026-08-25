using ClinicHealth.Interfaces;

namespace ClinicHealth.Models;

public class Pet : Animal, IRegistrable
{
    private Guid _patientId;
    private Race _race;
    private string _symptom;
    private Patient _owner;

    public Guid PatientId
    {
        get { return _patientId; }
        set { _patientId = value; }
    }

    public Race Race
    {
        get { return _race; }
        set { _race = value; }
    }

    public string Symptom
    {
        get { return _symptom; }
        set { _symptom = value?.Trim().ToLower() ?? ""; }
    }

    public Patient Owner
    {
        get { return _owner; }
        set { _owner = value; }
    }

    public Pet(string name, byte age, PetType species, string symptom, Guid patientId, Race race)
        : base(name, age, species)
    {
        _symptom = symptom?.Trim().ToLower() ?? "";
        _patientId = patientId;
        _race = race;
        _owner = null;
    }

    public override void ShowInformation()
    {
        base.ShowInformation();

        Console.WriteLine($"Symptom : {Symptom}");
        Console.WriteLine($"Patient ID : {PatientId}");
        Console.WriteLine($"Race : {Race}");
    }

    public override void MakeSound()
    {
        switch (Species)
        {
            case PetType.Dog:
                Console.WriteLine("Woof woof!");
                break;
            case PetType.Cat:
                Console.WriteLine("Meow meow!");
                break;
            case PetType.Bird:
                Console.WriteLine("Tweet tweet!");
                break;
            case PetType.Hamster:
                Console.WriteLine("Squeak squeak!");
                break;
            case PetType.Rabbit:
                Console.WriteLine("Sniff sniff!");
                break;
            case PetType.Other:
                Console.WriteLine("Unknown sound!");
                break;
            default:
                base.MakeSound();
                break;
        }
    }

    public void Register()
    {
        Console.WriteLine($"=== REGISTERING PET ===");
        Console.WriteLine($"Pet registered successfully:");
        Console.WriteLine($"ID: {Id}");
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Age: {Age}");
        Console.WriteLine($"Species: {Species}");
        Console.WriteLine($"Race: {Race}");
        Console.WriteLine($"Symptom: {Symptom}");
        Console.WriteLine($"Owner ID: {PatientId}");
    }
}

