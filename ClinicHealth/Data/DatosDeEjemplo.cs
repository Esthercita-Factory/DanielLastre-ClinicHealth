using ClinicHealth.Models;

namespace ClinicHealth.Data;

public static class DatosDeEjemplo
{
    public static void CargarDatosEjemplo(AlmacenEnMemoria almacen)
    {
        var patient1 = new Patient("jair", 19, "cr 123", "555-1234");
        var patient2 = new Patient("jairo", 30, "cr 456", "555-4567");

        almacen.Patients.Add(patient1);
        almacen.Patients.Add(patient2);

        foreach (var patient in almacen.Patients)
        {
            almacen.PatientDictionary.Add(patient.Id, patient);
        }
    }
}
