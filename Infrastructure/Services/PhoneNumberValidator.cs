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
            var number = util.Parse(phoneNumber, null);
            var isNumber = util.GetNumberType(number);
            if (isNumber==PhoneNumberType.MOBILE || isNumber == PhoneNumberType.FIXED_LINE_OR_MOBILE)
            {
                return util.IsValidNumber(number);
            }
            return false;
        }
        catch (NumberParseException)
        {
            return false;
        }
    }
}
