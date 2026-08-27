namespace ClinicHealth.UI;

public static class EntradaDeConsola
{
    public static string LeerTextoObligatorio(string mensaje)
    {
        while (true)
        {
            Console.Write(mensaje);
            string? input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                return input.Trim();
            }
            Console.WriteLine("Este campo es obligatorio. Por favor, ingrese un valor.");
        }
    }

    public static string LeerTextoOpcional(string mensaje)
    {
        Console.Write(mensaje);
        string? input = Console.ReadLine();
        return input?.Trim() ?? "";
    }

    public static byte LeerByte(string mensaje, byte min = 0, byte max = 255)
    {
        while (true)
        {
            Console.Write(mensaje);
            string? input = Console.ReadLine();
            if (byte.TryParse(input, out byte result) && result >= min && result <= max)
            {
                return result;
            }
            Console.WriteLine($"Valor inválido. Ingrese un número entre {min} y {max}.");
        }
    }

    public static int LeerEntero(string mensaje, int min, int max)
    {
        while (true)
        {
            Console.Write(mensaje);
            string? input = Console.ReadLine();
            if (int.TryParse(input, out int result) && result >= min && result <= max)
            {
                return result;
            }
            Console.WriteLine($"Valor inválido. Ingrese un número entre {min} y {max}.");
        }
    }

    public static Guid LeerGuid(string mensaje)
    {
        while (true)
        {
            Console.Write(mensaje);
            string? input = Console.ReadLine();
            if (Guid.TryParse(input, out Guid result))
            {
                return result;
            }
            Console.WriteLine("ID inválido. Ingrese un GUID válido.");
        }
    }

    public static T LeerEnum<T>(string mensaje) where T : struct, Enum
    {
        var valores = Enum.GetValues<T>();
        while (true)
        {
            for (int i = 0; i < valores.Length; i++)
            {
                Console.WriteLine($"{i} - {valores[i]}");
            }
            Console.Write(mensaje);
            string? input = Console.ReadLine();
            if (int.TryParse(input, out int seleccion) && seleccion >= 0 && seleccion < valores.Length)
            {
                return valores[seleccion];
            }
            Console.WriteLine($"Selección inválida. Ingrese un número entre 0 y {valores.Length - 1}.");
        }
    }
}
