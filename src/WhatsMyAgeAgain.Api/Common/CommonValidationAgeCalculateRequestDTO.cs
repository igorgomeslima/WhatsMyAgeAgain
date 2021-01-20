using System;
using WhatsMyAgeAgain.Api.DTO;
using WhatsMyAgeAgain.Api.Utils;

namespace WhatsMyAgeAgain.Api.Common
{
    public class CommonValidationAgeCalculateRequestDTO
    {
        public (bool IsValid, string Message) Validate(AgeCalculateRequestDTO ageCalculateRequestDTO)
        {
            if (ageCalculateRequestDTO is null)
                return (false, AgeValidationErrorMessagesConsts.NULL_REFERENCE);

            var isAnValidDateTime = DateTime.TryParse(ageCalculateRequestDTO.BirthDate, out var convertedBirthDate);

            if (isAnValidDateTime == false)
                return (false, AgeValidationErrorMessagesConsts.INVALID_DATE);

            return (true, string.Empty);
        }
    }
}
