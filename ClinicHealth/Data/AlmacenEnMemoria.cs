using ClinicHealth.Models;

namespace ClinicHealth.Data;

public class AlmacenEnMemoria
{
    public List<Patient> Patients { get; set; }
    public List<Pet> Pets { get; set; }
    public Dictionary<Guid, Patient> PatientDictionary { get; set; }

    public AlmacenEnMemoria()
    {
        Patients = new List<Patient>();
        Pets = new List<Pet>();
        PatientDictionary = new Dictionary<Guid, Patient>();
    }
}
