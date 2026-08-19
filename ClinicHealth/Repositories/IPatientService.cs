using ClinicHealth.Models;

namespace ClinicHealth.Interfaces;

public interface IPatientService
{
    void RegisterPatient(List<Patient> listPatients);
    void ListPatient(List<Patient> listPatients);
    void SearchPatientByName(List<Patient> listPatients , string Name);
}