using ClinicHealth.Models;

namespace ClinicHealth.Repositories;

public class ClinicRepository
{
    public List<Patient> Patients { get; set; }
    public List<Pet> Pets { get; set; }
    public Dictionary<Guid, Patient> PatientDictionary { get; set; }
    

    public ClinicRepository()
    {
        Patients =
        [
            new Patient("jair", 19),
            new Patient("jairo", 25)
            
        ];
        Pets = new List<Pet>();
        
        PatientDictionary = new Dictionary<Guid, Patient>();
        foreach (var patient in Patients)
        {
            PatientDictionary.Add(patient.Id, patient);
        }
        
    }


}


    

    