namespace ClinicHealth.Models;

public abstract class VeterinaryService
{
    protected string _name;
    protected decimal _cost;
    protected string _description;

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public decimal Cost
    {
        get { return _cost; }
        set { _cost = value; }
    }

    public string Description
    {
        get { return _description; }
        set { _description = value; }
    }

    public VeterinaryService(string name, decimal cost, string description)
    {
        _name = name;
        _cost = cost;
        _description = description;
    }

    public abstract void Attend();

    public virtual void ShowInformation()
    {
        Console.WriteLine($"=== VETERINARY SERVICE ===");
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine($"Cost: ${_cost}");
        Console.WriteLine($"Description: {_description}");
    }
}
