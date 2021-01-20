using System;
using WhatsMyAgeAgain.Api.DTO;
using Microsoft.AspNetCore.Mvc;
using WhatsMyAgeAgain.Api.Utils;
using WhatsMyAgeAgain.Api.Common;

namespace WhatsMyAgeAgain.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgeController : BaseController
    {
        public AgeController()
        {
            _commonValidationAgeCalculateRequestDTO = new CommonValidationAgeCalculateRequestDTO();
        }

        readonly CommonValidationAgeCalculateRequestDTO _commonValidationAgeCalculateRequestDTO;

        [HttpPost]
        [Route(nameof(AgeController.CalculateWithNumericResponse))]
        public IActionResult CalculateWithNumericResponse(AgeCalculateRequestDTO ageCalculateRequestDTO)
        {
            var validationResult = _commonValidationAgeCalculateRequestDTO.Validate(ageCalculateRequestDTO);

            if (validationResult.IsValid == false)
                return Error(validationResult.Message);

            DateTime.TryParse(ageCalculateRequestDTO.BirthDate, out var convertedBirthDate);

            var ageCalculateResponseDTO = new AgeCalculateResponseDTO
            {
                AgeInDays = DateTimeUtils.GetTotalCompletedDaysSinceBirthdate(convertedBirthDate),
                AgeInMonths = DateTimeUtils.GetTotalCompletedMonthsSinceBirthdate(convertedBirthDate),
                AgeInYears = DateTimeUtils.GetTotalCompletedYearsSinceBirthdate(convertedBirthDate)
            };

            return Ok(ageCalculateResponseDTO);
        }

        [HttpPost]
        [Route(nameof(AgeController.CalculateWithPlainTextResponse))]
        public IActionResult CalculateWithPlainTextResponse(AgeCalculateRequestDTO ageCalculateRequestDTO)
        {
            var validationResult = _commonValidationAgeCalculateRequestDTO.Validate(ageCalculateRequestDTO);

            if (validationResult.IsValid == false)
                return Error(validationResult.Message);

            DateTime.TryParse(ageCalculateRequestDTO.BirthDate, out var convertedBirthDate);

            var plainTextResponse = $"Uma pessoa que nasceu em '{convertedBirthDate.ToShortDateString()}' hoje tem {DateTimeUtils.GetTotalCompletedYearsSinceBirthdate(convertedBirthDate)} anos, {DateTimeUtils.GetTotalCompletedMonthsSinceLastBirthday(convertedBirthDate)} meses e {DateTimeUtils.GetTotalCompletedDaysSinceLastBirthday(convertedBirthDate)} dias.";

            return Ok(plainTextResponse);
        }
    }
}
