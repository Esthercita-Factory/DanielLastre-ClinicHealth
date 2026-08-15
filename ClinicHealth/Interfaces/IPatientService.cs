using ClinicHealth.Models;

namespace ClinicHealth.Interfaces;

public interface IPatientService
{
    void RegisterPatient(List<Patient> List);
    void ListPatient(List<Patient> List);
    void SearchPatientByName(List<Patient> List , string Name);
}