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
            new Patient("jair", 19, "cr 123" ,"555-1234"),
            new Patient("jairo", 30 ,"cr 456" ,"555-4567" )

        ];
        Pets = new List<Pet>();

        PatientDictionary = new Dictionary<Guid, Patient>();
        foreach (var patient in Patients)
        {
            PatientDictionary.Add(patient.Id, patient);
        }

    }


}

    

    