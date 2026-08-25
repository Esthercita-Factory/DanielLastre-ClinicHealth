using ClinicHealth.Interfaces;
using ClinicHealth.Models;

namespace ClinicHealth.Services;

public class PetService : IPetService
{
    public void RegisterPet(List<Pet> listPets, Dictionary<Guid, Patient> patientDictionary, Guid patientId)
    {
        try
        {
            if (!patientDictionary.ContainsKey(patientId))
            {
                Console.WriteLine("Patient not found. Cannot register pet.");
                return;
            }

            Console.Write("Enter pet name: ");
            string? name = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Name cannot be empty.");
                Console.Write("Enter pet name: ");
                name = Console.ReadLine();
            }

            Console.WriteLine("Available pet types:");
            Console.WriteLine("0 - Dog");
            Console.WriteLine("1 - Cat");
            Console.WriteLine("2 - Bird");
            Console.WriteLine("3 - Hamster");
            Console.WriteLine("4 - Rabbit");
            Console.WriteLine("5 - Other");
            Console.Write("Enter pet type number: ");
            string? typeInput = Console.ReadLine();

            PetType type;
            while (!int.TryParse(typeInput, out int typeNumber) || typeNumber < 0 || typeNumber > 5)
            {
                Console.WriteLine("Invalid type number. Enter a number between 0 and 5.");
                Console.Write("Enter pet type number: ");
                typeInput = Console.ReadLine();
            }
            type = (PetType)int.Parse(typeInput!);

            Console.Write("Enter pet symptom: ");
            string? symptom = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(symptom))
            {
                Console.WriteLine("Symptom cannot be empty.");
                Console.Write("Enter pet symptom: ");
                symptom = Console.ReadLine();
            }

            Console.Write("Enter pet age: ");
            string? ageInput = Console.ReadLine();
            byte age;
            while (!byte.TryParse(ageInput, out age) || age == 0)
            {
                Console.WriteLine("Invalid age. Enter a valid number greater than 0.");
                Console.Write("Enter pet age: ");
                ageInput = Console.ReadLine();
            }

            Console.WriteLine("Available races:");
            Console.WriteLine("0 - LabradorRetriever");
            Console.WriteLine("1 - GermanShepherd");
            Console.WriteLine("2 - GoldenRetriever");
            Console.WriteLine("3 - FrenchBulldog");
            Console.WriteLine("4 - Chihuahua");
            Console.WriteLine("5 - DomesticShortHair");
            Console.WriteLine("6 - Persian");
            Console.WriteLine("7 - RussianBlue");
            Console.WriteLine("8 - Siamese");
            Console.WriteLine("9 - MaineCoon");
            Console.WriteLine("10 - Budgerigar");
            Console.WriteLine("11 - Canary");
            Console.WriteLine("12 - Cockatiel");
            Console.WriteLine("13 - Lovebird");
            Console.WriteLine("14 - Cockatoo");
            Console.WriteLine("15 - Syrian");
            Console.WriteLine("16 - RussianDwarf");
            Console.WriteLine("17 - Roborovski");
            Console.WriteLine("18 - CampbellsDwarf");
            Console.WriteLine("19 - Lionhead");
            Console.WriteLine("20 - BelierLop");
            Console.WriteLine("21 - NetherlandDwarf");
            Console.WriteLine("22 - FlemishGiant");
            Console.WriteLine("23 - Other");
            Console.Write("Enter race number: ");
            string? raceInput = Console.ReadLine();
            Race race;
            while (!int.TryParse(raceInput, out int raceNumber) || raceNumber < 0 || raceNumber > 23)
            {
                Console.WriteLine("Invalid race number. Enter a number between 0 and 23.");
                Console.Write("Enter race number: ");
                raceInput = Console.ReadLine();
            }
            race = (Race)int.Parse(raceInput!);

            var pet = new Pet(name, age, type, symptom, patientId, race);
            listPets.Add(pet);
            patientDictionary[patientId].Pets.Add(pet);
            Console.WriteLine("Pet registered successfully.");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error registering pet: {e.Message}");
        }
    }

    public void DeletePet(List<Pet> listPets, Dictionary<Guid, Patient> patientDictionary, Guid petId)
    {
        try
        {
            Pet? petToDelete = null;

            foreach (var pet in listPets)
            {
                if (pet.Id == petId)
                {
                    petToDelete = pet;
                    break;
                }
            }

            if (petToDelete != null)
            {
                listPets.Remove(petToDelete);
                patientDictionary[petToDelete.PatientId].Pets.Remove(petToDelete);
                Console.WriteLine("Pet deleted successfully.");
            }
            else
            {
                Console.WriteLine("Pet not found.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error deleting pet: {e.Message}");
        }
    }

    public void UpdatePet(List<Pet> listPets, Dictionary<Guid, Patient> patientDictionary, Guid petId)
    {
        try
        {
            Pet? petToUpdate = null;

            foreach (var pet in listPets)
            {
                if (pet.Id == petId)
                {
                    petToUpdate = pet;
                    break;
                }
            }

            if (petToUpdate != null)
            {
                Console.Write("Enter new pet name: ");
                string? name = Console.ReadLine();

                while (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Name cannot be empty.");
                    Console.Write("Enter new pet name: ");
                    name = Console.ReadLine();
                }

                Console.WriteLine("Available pet types:");
                Console.WriteLine("0 - Dog");
                Console.WriteLine("1 - Cat");
                Console.WriteLine("2 - Bird");
                Console.WriteLine("3 - Hamster");
                Console.WriteLine("4 - Rabbit");
                Console.WriteLine("5 - Other");
                Console.Write("Enter new pet type number: ");
                string? typeInput = Console.ReadLine();

                PetType type;
                while (!int.TryParse(typeInput, out int typeNumber) || typeNumber < 0 || typeNumber > 5)
                {
                    Console.WriteLine("Invalid type number. Enter a number between 0 and 5.");
                    Console.Write("Enter new pet type number: ");
                    typeInput = Console.ReadLine();
                }
                type = (PetType)int.Parse(typeInput!);

                Console.Write("Enter new pet symptom: ");
                string? symptom = Console.ReadLine();

                while (string.IsNullOrWhiteSpace(symptom))
                {
                    Console.WriteLine("Symptom cannot be empty.");
                    Console.Write("Enter pet symptom: ");
                    symptom = Console.ReadLine();
                }

                Console.Write("Enter new pet age: ");
                string? ageInput = Console.ReadLine();
                byte age;
                while (!byte.TryParse(ageInput, out age) || age == 0)
                {
                    Console.WriteLine("Invalid age. Enter a valid number greater than 0.");
                    Console.Write("Enter new pet age: ");
                    ageInput = Console.ReadLine();
                }

                Console.WriteLine("Available races:");
                Console.WriteLine("0 - LabradorRetriever");
                Console.WriteLine("1 - GermanShepherd");
                Console.WriteLine("2 - GoldenRetriever");
                Console.WriteLine("3 - FrenchBulldog");
                Console.WriteLine("4 - Chihuahua");
                Console.WriteLine("5 - DomesticShortHair");
                Console.WriteLine("6 - Persian");
                Console.WriteLine("7 - RussianBlue");
                Console.WriteLine("8 - Siamese");
                Console.WriteLine("9 - MaineCoon");
                Console.WriteLine("10 - Budgerigar");
                Console.WriteLine("11 - Canary");
                Console.WriteLine("12 - Cockatiel");
                Console.WriteLine("13 - Lovebird");
                Console.WriteLine("14 - Cockatoo");
                Console.WriteLine("15 - Syrian");
                Console.WriteLine("16 - RussianDwarf");
                Console.WriteLine("17 - Roborovski");
                Console.WriteLine("18 - CampbellsDwarf");
                Console.WriteLine("19 - Lionhead");
                Console.WriteLine("20 - BelierLop");
                Console.WriteLine("21 - NetherlandDwarf");
                Console.WriteLine("22 - FlemishGiant");
                Console.WriteLine("23 - Other");
                Console.Write("Enter race number: ");
                string? raceInput = Console.ReadLine();
                Race race;
                while (!int.TryParse(raceInput, out int raceNumber) || raceNumber < 0 || raceNumber > 23)
                {
                    Console.WriteLine("Invalid race number. Enter a number between 0 and 23.");
                    Console.Write("Enter race number: ");
                    raceInput = Console.ReadLine();
                }
                race = (Race)int.Parse(raceInput!);

                petToUpdate.Name = name!.Trim().ToLower();
                petToUpdate.Species = type;
                petToUpdate.Symptom = symptom!.Trim().ToLower();
                petToUpdate.Age = age;
                petToUpdate.Race = race;

                Console.WriteLine("Pet updated successfully.");
            }
            else
            {
                Console.WriteLine("Pet not found.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error updating pet: {e.Message}");
        }
    }

    public void TestPolymorphism(List<Pet> listPets)
    {
        Console.WriteLine("=== TESTING POLYMORPHISM - ANIMAL SOUNDS ===");

        if (listPets.Count == 0)
        {
            Console.WriteLine("No pets registered to test polymorphism.");
            return;
        }

        foreach (var pet in listPets)
        {
            Console.Write($"{pet.Name} ({pet.Species}): ");
            pet.MakeSound();
        }
    }
}
