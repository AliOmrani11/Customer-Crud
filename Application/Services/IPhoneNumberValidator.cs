namespace Application.Services;

public interface IPhoneNumberValidator
{
    Task<bool> CheckPhoneNumber(string phoneNumber);
}
