namespace ClinicHealth.Exceptions;

public class PatientNotFoundException : Exception
{
    public Guid PatientId { get; }

    public PatientNotFoundException(Guid patientId)
        : base($"Patient with ID {patientId} was not found.")
    {
        PatientId = patientId;
    }

    public PatientNotFoundException(Guid patientId, string message)
        : base(message)
    {
        PatientId = patientId;
    }

    public PatientNotFoundException(Guid patientId, string message, Exception innerException)
        : base(message, innerException)
    {
        PatientId = patientId;
    }
}
