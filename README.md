# ClinicHealth

ClinicHealth is a console-based veterinary clinic management system developed
with C# and .NET 10. The project manages patients and their pets in memory
while demonstrating practical object-oriented programming, layered
architecture, interfaces, inheritance, abstraction, polymorphism, LINQ,
exception handling, debugging, and logging.

## Table of Contents

- [Project Goals](#project-goals)
- [Features](#features)
- [Technology Stack](#technology-stack)
- [Architecture](#architecture)
- [Project Structure](#project-structure)
- [Domain Model](#domain-model)
- [Interfaces and Abstraction](#interfaces-and-abstraction)
- [Application Flow](#application-flow)
- [Console Menu](#console-menu)
- [Data Storage](#data-storage)
- [Validation and Error Handling](#validation-and-error-handling)
- [Logging](#logging)
- [Getting Started](#getting-started)
- [Testing](#testing)
- [Current Scope and Limitations](#current-scope-and-limitations)

## Project Goals

The application was created as a learning project to apply the main concepts
of object-oriented programming in a realistic veterinary clinic scenario:

- Encapsulation through private fields, public properties, and validation.
- Inheritance through the `Animal` and `VeterinaryService` hierarchies.
- Polymorphism through virtual and overridden methods.
- Abstraction through abstract classes and interfaces.
- Separation of responsibilities between UI, services, repositories, and
  models.
- Practical use of generic collections and LINQ queries.
- Structured exception handling and diagnostic logging.

## Features

### Patient management

- Register patients.
- List all patients.
- Search patients by name.
- Update patient information.
- Delete patients.
- Store patient address, phone number, age, and associated pets.

### Pet management

- Register pets and assign them to an owner.
- List all pets.
- Update pet information.
- Delete pets.
- List the pets belonging to a specific patient.
- Store species, breed, age, symptoms, and owner information.

### LINQ demonstrations

The application includes examples of:

- `Where` for filtering patients and pets.
- `Select` for projecting patient names.
- `OrderBy` and `OrderByDescending` for sorting.
- `GroupBy` for grouping patients by pet type.
- `First` and `FirstOrDefault`.
- `Any` and `All`.
- `Count`.
- Combined queries such as finding dog owners ordered by age.
- Practical queries for youngest and oldest patients, pet counts by type,
  undefined pet types, and uppercase ordered names.

### Object-oriented programming demonstrations

- `Pet` inherits from `Animal`.
- `Pet.MakeSound()` overrides the base implementation according to the pet
  type.
- `VeterinaryService` is an abstract class shared by consultations and
  vaccinations.
- `Patient` and `Pet` implement `IRegistrable`.
- `Patient` implements both `IRegistrable` and `INotificable`.
- `GeneralConsultation` and `Vaccination` implement `IAtendible`.

## Technology Stack

- **Language:** C#
  - **Runtime and SDK:** .NET 10
- **Application type:** Console application
- **Storage:** In-memory collections
- **Testing:** .NET test project with xUnit
- **IDE support:** Compatible with JetBrains Rider and other .NET IDEs

No external database or third-party service is required to run the
application.

## Architecture

ClinicHealth follows a simple layered architecture:

```text
┌──────────────────────────────────────────┐
│                  UI Layer                │
│ ManagerClinic, ManagerUser, Console input│
└─────────────────────┬────────────────────┘
                      │
┌─────────────────────▼────────────────────┐
│              Service Layer               │
│ PatientService, PetService, LinqService  │
│ LoggerService                             │
└─────────────────────┬────────────────────┘
                      │
┌─────────────────────▼────────────────────┐
│            Repository Layer               │
│ PatientRepository, PetRepository         │
└─────────────────────┬────────────────────┘
                      │
┌─────────────────────▼────────────────────┐
│              Data Layer                  │
│ AlmacenEnMemoria and sample data         │
└──────────────────────────────────────────┘
```

### UI layer

The UI layer controls the interactive console experience:

- `ManagerClinic` displays the main menu and delegates operations.
- `ManagerUser` provides user-related workflows.
- `EntradaDeConsola` centralizes safe input parsing for text, numbers,
  `Guid` values, and enumerations.

The UI does not directly manipulate the underlying collections. It calls
services and displays their results and error messages.

### Service layer

The service layer contains application and business operations:

- `PatientService` manages patient operations and debugging examples.
- `PetService` manages pet operations and polymorphism demonstrations.
- `LinqService` contains reusable LINQ exercises and practical queries.
- `LoggerService` records errors, warnings, and informational messages.

Services receive their dependencies through constructors. This keeps the
classes testable and separates business logic from data access.

### Repository layer

Repositories isolate data access from the rest of the application:

- `PatientRepository` manages patients and the patient dictionary.
- `PetRepository` manages pets and supports filtering by owner and type.
- `IPatientRepository` and `IPetRepository` define repository contracts.

Repositories expose operations such as registration, lookup, update, delete,
existence checks, counting, and retrieval of all records.

### Data layer

`AlmacenEnMemoria` contains the collections used by the repositories. At
startup, `DatosDeEjemplo.CargarDatosEjemplo` inserts representative patients
and pets so the menus can be used immediately.

## Project Structure

```text
DanielLastre-ClinicHealth/
├── ClinicHealth.slnx
├── README.md
├── PROGRESO.md
├── ClinicHealth/
│   ├── ClinicHealth.csproj
│   ├── Program.cs
│   ├── Data/
│   │   ├── AlmacenEnMemoria.cs
│   │   └── DatosDeEjemplo.cs
│   ├── Exceptions/
│   │   ├── PatientNotFoundException.cs
│   │   └── PetNotFoundException.cs
│   ├── Interfaces/
│   │   ├── IAtendible.cs
│   │   ├── ILinqService.cs
│   │   ├── INotificable.cs
│   │   ├── IPatientService.cs
│   │   ├── IPetService.cs
│   │   └── IRegistrable.cs
│   ├── Models/
│   │   ├── Animal.cs
│   │   ├── GeneralConsultation.cs
│   │   ├── Patient.cs
│   │   ├── Pet.cs
│   │   ├── PetType.cs
│   │   ├── Race.cs
│   │   ├── Vaccination.cs
│   │   └── VeterinaryService.cs
│   ├── Repositories/
│   │   ├── ClinicRepository.cs
│   │   ├── IPatientRepository.cs
│   │   └── IPetRepository.cs
│   ├── Services/
│   │   ├── LinqService.cs
│   │   ├── LoggerService.cs
│   │   ├── PatientService.cs
│   │   └── PetService.cs
│   └── UI/
│       ├── EntradaDeConsola.cs
│       ├── ManagerClinic.cs
│       └── ManagerUser.cs
└── ClinicHealth.Tests/
    ├── ClinicHealth.Tests.csproj
    └── UnitTest1.cs
```

## Domain Model

### Patient

`Patient` represents a clinic client or pet owner. It contains an identifier,
name, age, address, phone number, and a list of associated pets. It
implements:

- `IRegistrable` to support registration behavior.
- `INotificable` to demonstrate notification behavior.

### Animal and Pet

`Animal` is the base class for animals and provides common properties such as
identifier, name, age, and type. It defines virtual methods for displaying
information and making a sound.

`Pet` inherits from `Animal` and adds:

- Owner/patient identifier.
- Breed (`Race`).
- Symptoms.
- Owner reference.

`Pet.MakeSound()` overrides the base method and selects a sound based on the
pet type, including dogs, cats, birds, hamsters, rabbits, and other animals.

### Veterinary services

`VeterinaryService` is an abstract class containing shared service data such
as name, cost, and description. It defines the abstract `Attend()` operation
and a virtual `ShowInformation()` method.

Concrete services include:

- `GeneralConsultation`, with diagnosis and treatment information.
- `Vaccination`, with vaccine type information.

Both classes implement `IAtendible` in addition to inheriting from
`VeterinaryService`.

### Enumerations

- `PetType` identifies the animal species.
- `Race` identifies the supported pet breeds.

## Interfaces and Abstraction

The project uses interfaces to define capabilities and contracts:

| Interface | Purpose | Implementations |
| --- | --- | --- |
| `IPatientService` | Patient service operations | `PatientService` |
| `IPetService` | Pet service operations | `PetService` |
| `ILinqService` | LINQ operation contract | `LinqService` |
| `IRegistrable` | Registration capability | `Patient`, `Pet` |
| `INotificable` | Notification capability | `Patient` |
| `IAtendible` | Veterinary attendance capability | `GeneralConsultation`, `Vaccination` |

Interfaces are used when unrelated classes need to share a capability, while
the `VeterinaryService` abstract class is used when related classes share
state and common behavior.

## Application Flow

The application starts in `Program.cs`:

1. Create the in-memory data store.
2. Load sample data.
3. Create patient and pet repositories.
4. Create the logger.
5. Inject repositories into the patient and pet services.
6. Create the LINQ service and menu managers.
7. Start `ManagerClinic.ShowMainMenu()`.

Typical operation flow:

```text
User input
    ↓
EntradaDeConsola validation
    ↓
ManagerClinic / ManagerUser
    ↓
PatientService or PetService
    ↓
Repository
    ↓
AlmacenEnMemoria
```

## Console Menu

The main menu provides:

1. User Management
2. Patient Management
3. Pet Management
4. LINQ Queries
5. Practical Problems
6. Debugging Tools
7. Exit

Patient management includes registration, listing, name search, deletion, and
updates.

Pet management includes registration, listing, deletion, updates, listing a
patient's pets, and testing animal sound polymorphism.

The debugging menu includes:

- Testing multiple interfaces.
- Triggering and handling a division-by-zero exception.
- Inspecting variables during a debugging session.

## Data Storage

The current implementation is intentionally database-free. Data is stored in
memory using collections owned by `AlmacenEnMemoria`, including:

- A patient collection.
- A pet collection.
- A `Dictionary<Guid, Patient>` for efficient patient lookup.

All data is lost when the process ends. Sample data is recreated each time
the application starts.

## Validation and Error Handling

`EntradaDeConsola` provides centralized validation for:

- Required and optional text.
- Byte values with minimum and maximum ranges.
- Integer values with ranges.
- Valid `Guid` values.
- Valid enum values.

The application uses specific domain exceptions:

- `PatientNotFoundException` when a requested patient does not exist.
- `PetNotFoundException` when a requested pet does not exist.

Operations use structured `try-catch` handling. Specific exceptions are
handled before general exceptions, and failures are both shown to the user
and logged with their operation context.

## Logging

`LoggerService` supports:

- `LogError` for exceptions and stack traces.
- `LogInfo` for successful or informational events.
- `LogWarning` for warning conditions.

Errors are written to the console and to `clinic_errors.log`. Entries include
the timestamp, operation context, message, exception type, inner exception
information when available, and stack trace.

The log file is generated in the application's working or output directory
when an error is recorded.

## Getting Started

### Prerequisites

- .NET 10 SDK
- Git, if cloning the repository

Verify the SDK installation:

```bash
dotnet --version
```

### Clone the repository

```bash
git clone https://github.com/Esthercita-Factory/DanielLastre-ClinicHealth.git
cd DanielLastre-ClinicHealth
```

### Restore and build

```bash
dotnet restore
dotnet build
```

### Run the application

```bash
dotnet run --project ClinicHealth/ClinicHealth.csproj
```

The application starts with sample data and opens the interactive clinic
menu.

## Testing

Run all tests from the repository root:

```bash
dotnet test
```

To run the test project directly:

```bash
dotnet test ClinicHealth.Tests/ClinicHealth.Tests.csproj
```

The test project is prepared for unit testing with xUnit. New tests can be
added to `ClinicHealth.Tests` as service and repository behavior is expanded.

## Current Scope and Limitations

- Data is stored only in memory.
- There is no authentication or role-based authorization.
- There is no persistent database.
- The application is designed for interactive console use rather than a web
  or desktop interface.
- The test suite is currently a foundation for adding more unit tests.

These limitations are intentional for the current educational scope and leave
clear paths for future extensions such as database persistence, a web API,
authentication, appointment scheduling, and expanded veterinary records.
