using Application.Services;
using PhoneNumbers;

namespace Infrastructure.Services;

public class PhoneNumberValidator : IPhoneNumberValidator
{
    public async Task<bool> CheckPhoneNumber(string phoneNumber)
    {
        if (string.IsNullOrEmpty(phoneNumber))
        {
            return false;
        }

        var util = PhoneNumberUtil.GetInstance();
        try
        {
            var number = util.Parse(phoneNumber, "US");
            return util.IsValidNumber(number);
        }
        catch (NumberParseException)
        {
            return false;
        }
    }
}
