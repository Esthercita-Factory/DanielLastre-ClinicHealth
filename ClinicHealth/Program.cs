using ClinicHealth.Data;
using ClinicHealth.Repositories;
using ClinicHealth.Services;
using ClinicHealth.UI;

// Composition Root
var almacen = new AlmacenEnMemoria();
DatosDeEjemplo.CargarDatosEjemplo(almacen);

var patientRepository = new PatientRepository(almacen);
var petRepository = new PetRepository(almacen);
var loggerService = new LoggerService();
var patientService = new PatientService(patientRepository, petRepository, loggerService);
var petService = new PetService(petRepository, patientRepository, loggerService);
var linqService = new LinqService();

var managerUser = new ManagerUser(patientService, petService, patientRepository, petRepository, loggerService);
var manager = new ManagerClinic(patientService, petService, linqService, loggerService, patientRepository, petRepository, managerUser);
manager.ShowMainMenu();