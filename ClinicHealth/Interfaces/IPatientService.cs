using ClinicHealth.Models;

namespace ClinicHealth.Interfaces;

public interface IPatientService
{
    void RegisterPatient(List<Patient> listPatients);
    void ListPatient(List<Patient> listPatients);
    void SearchPatientByName(List<Patient> listPatients, string name);
    void DeletePatient(List<Patient> listPatients, Dictionary<Guid, Patient> patientDictionary, Guid patientId);
    
    void UpdatePatient(List<Patient> listPatients, Dictionary<Guid, Patient> patientDictionary, Guid patientId);
    
}