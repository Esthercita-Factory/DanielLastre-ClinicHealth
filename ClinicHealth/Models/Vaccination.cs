namespace ClinicHealth.Models;

public class Vaccination : VeterinaryService
{
    private string _vaccineType;
    private DateTime _applicationDate;
    private DateTime _nextDose;

    public string VaccineType
    {
        get { return _vaccineType; }
        set { _vaccineType = value; }
    }

    public DateTime ApplicationDate
    {
        get { return _applicationDate; }
        set { _applicationDate = value; }
    }

    public DateTime NextDose
    {
        get { return _nextDose; }
        set { _nextDose = value; }
    }

    public Vaccination(string name, decimal cost, string description, string vaccineType)
        : base(name, cost, description)
    {
        _vaccineType = vaccineType;
        _applicationDate = DateTime.Now;
        _nextDose = DateTime.Now.AddMonths(6);
    }

    public override void Attend()
    {
        Console.WriteLine($"=== ATTENDING VACCINATION ===");
        Console.WriteLine($"Service: {_name}");
        Console.WriteLine($"Vaccine type: {_vaccineType}");
        Console.WriteLine($"Checking vaccination history...");
        Console.WriteLine($"Preparing vaccine...");
        Console.WriteLine($"Administering vaccine to patient...");
        Console.WriteLine($"Recording application date: {_applicationDate:dd/MM/yyyy}");
        Console.WriteLine($"Next dose scheduled: {_nextDose:dd/MM/yyyy}");
        Console.WriteLine($"Vaccination completed successfully.");
    }

    public override void ShowInformation()
    {
        base.ShowInformation();
        Console.WriteLine($"Type: Vaccination");
        Console.WriteLine($"Vaccine type: {_vaccineType}");
        Console.WriteLine($"Application date: {_applicationDate:dd/MM/yyyy}");
        Console.WriteLine($"Next dose: {_nextDose:dd/MM/yyyy}");
    }
}
