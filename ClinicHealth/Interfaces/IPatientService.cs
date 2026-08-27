using ClinicHealth.Models;

namespace ClinicHealth.Interfaces;

public interface IPatientService
{
    void Register(string name, byte age, string address, string phone);
    void List();
    void SearchByName(string name);
    void Update(Guid id, string name, byte age, string address, string phone);
    void Delete(Guid id);
    void DebugDivisionByZero();
    void DebugVariableInspection();
}