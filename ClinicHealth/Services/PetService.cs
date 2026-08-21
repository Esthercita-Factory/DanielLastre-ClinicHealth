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

            var pet = new Pet(name!, type, symptom!, patientId);
            listPets.Add(pet);
            Console.WriteLine("Pet registered successfully.");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error registering pet: {e.Message}");
        }
    }

    public void DeletePet(List<Pet> listPets, Guid petId)
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

    public void UpdatePet(List<Pet> listPets, Guid petId)
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

                petToUpdate.Name = name!.Trim().ToLower();
                petToUpdate.Type = type;
                petToUpdate.Symptom = symptom!.Trim().ToLower();

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
}
