using ClinicHealth.Models;

namespace ClinicHealth.Repositories;

public class ClinicRepository
{
    public List<Patient> Patients { get; set; }

    public ClinicRepository()
    {
        Patients =
        [
            new Patient("jair", 
                19, 
                "asymptomatic"),
            new Patient("jairo",
                25, 
                "asymptomatic")

        ];
    }


}


    

    