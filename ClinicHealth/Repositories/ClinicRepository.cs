using ClinicHealth.Models;

namespace ClinicHealth.Repositories;

public  class ClinicRepository
{
    public List<Patient> Patients { get; set; }

    public ClinicRepository()
    {
        Patients =
        [
            new Patient("jair", 19, "asymptomatic"),
            new Patient("jairo", 25, "asymptomatic")

        ];
    }


    
    

    public void RegisterPatient(Patient patient)
    {
        Patients.Add(patient);
    }
    
    public void ListPatient(Patient patient)
    {
        Patients.Add(patient);
    }
    public void SearchPatientByName(Patient patient)
    {
        Patients.Add(patient);
    }

}