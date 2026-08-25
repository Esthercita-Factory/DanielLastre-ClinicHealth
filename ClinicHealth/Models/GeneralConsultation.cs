using ClinicHealth.Interfaces;

namespace ClinicHealth.Models;

public class GeneralConsultation : VeterinaryService, IAtendible
{
    private string _diagnosis;
    private string _treatment;

    public string Diagnosis
    {
        get { return _diagnosis; }
        set { _diagnosis = value; }
    }

    public string Treatment
    {
        get { return _treatment; }
        set { _treatment = value; }
    }

    public GeneralConsultation(string name, decimal cost, string description, string diagnosis = "", string treatment = "")
        : base(name, cost, description)
    {
        _diagnosis = diagnosis;
        _treatment = treatment;
    }

    public override void Attend()
    {
        Console.WriteLine($"=== ATTENDING GENERAL CONSULTATION ===");
        Console.WriteLine($"Service: {_name}");
        Console.WriteLine($"Performing physical exam on patient...");
        Console.WriteLine($"Evaluating symptoms and behavior...");
        Console.WriteLine($"General consultation completed.");
    }

    public void Atender()
    {
        Attend();
    }

    public override void ShowInformation()
    {
        base.ShowInformation();
        Console.WriteLine($"Type: General Consultation");
        Console.WriteLine($"Diagnosis: {_diagnosis}");
        Console.WriteLine($"Treatment: {_treatment}");
    }
}
