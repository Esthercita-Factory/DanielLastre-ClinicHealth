using ClinicHealth.Models;
using ClinicHealth.Repositories;
using ClinicHealth.Services;
using ClinicHealth.UI;




var repository = new ClinicRepository();
var patientService = new PatientService();
var petService = new PetService();
var linqService = new LinqService();

var manager = new ManagerClinic(patientService, petService, linqService, repository.Patients, repository.Pets, repository.PatientDictionary);
manager.ShowMainMenu();