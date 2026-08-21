using ClinicHealth.Models;
using ClinicHealth.Repositories;
using ClinicHealth.Services;
using ClinicHealth.UI;




var repository = new ClinicRepository();
var service = new PatientService();

var manager = new ManagerClinic(service, repository.Patients);
manager.ShowMainMenu();