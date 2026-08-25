using ClinicHealth.Models;
using ClinicHealth.Repositories;
using ClinicHealth.Services;
using ClinicHealth.UI;

var repository = new ClinicRepository();
var loggerService = new LoggerService();
var patientService = new PatientService(loggerService);
var petService = new PetService(loggerService);
var linqService = new LinqService();

var manager = new ManagerClinic(patientService, petService, linqService, loggerService, repository.Patients, repository.Pets, repository.PatientDictionary);
manager.ShowMainMenu();