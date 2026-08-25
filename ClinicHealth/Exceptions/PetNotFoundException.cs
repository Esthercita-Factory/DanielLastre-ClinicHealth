namespace ClinicHealth.Exceptions;

public class PetNotFoundException : Exception
{
    public Guid PetId { get; }

    public PetNotFoundException(Guid petId)
        : base($"Pet with ID {petId} was not found.")
    {
        PetId = petId;
    }

    public PetNotFoundException(Guid petId, string message)
        : base(message)
    {
        PetId = petId;
    }

    public PetNotFoundException(Guid petId, string message, Exception innerException)
        : base(message, innerException)
    {
        PetId = petId;
    }
}
