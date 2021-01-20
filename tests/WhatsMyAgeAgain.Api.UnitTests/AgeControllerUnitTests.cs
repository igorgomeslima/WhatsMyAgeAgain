using Moq;
using Xunit;
using System;
using WhatsMyAgeAgain.Api.DTO;
using Microsoft.AspNetCore.Mvc;
using WhatsMyAgeAgain.Api.Utils;
using WhatsMyAgeAgain.Api.Common;
using WhatsMyAgeAgain.Api.Controllers;

namespace WhatsMyAgeAgain.Api.UnitTests
{
    public class AgeControllerUnitTests
    {
        public AgeControllerUnitTests()
        {
            _ageController = new AgeController();
        }

        readonly AgeController _ageController;

        #region CalculateWithNumericResponse

        [Fact]
        public void Calculate_With_Numeric_Response_Passing_An_Valid_Date()
        {
            var ageCalculatedRequestDTO = new AgeCalculateRequestDTO
            {
                BirthDate = DateTime.Now.AddYears(-1).ToShortDateString()
            };

            var objectResult =
                (ObjectResult)_ageController.CalculateWithNumericResponse(ageCalculatedRequestDTO);
            var envelopeResponse = (Envelope<AgeCalculateResponseDTO>)objectResult.Value;

            Assert.Null(envelopeResponse.ErrorMessage);
            Assert.Equal(366, envelopeResponse.Result.AgeInDays);
            Assert.Equal(12, envelopeResponse.Result.AgeInMonths);
            Assert.Equal(1, envelopeResponse.Result.AgeInYears);
        }

        [Fact]
        public void Calculate_With_Numeric_Response_Passing_An_Invalid_Date()
        {
            var ageCalculatedRequestDTO = new AgeCalculateRequestDTO
            {
                BirthDate = "30*/12*/1992"
            };

            var objectResult =
                (ObjectResult)_ageController.CalculateWithNumericResponse(ageCalculatedRequestDTO);
            var envelopeResponse = (Envelope<string>)objectResult.Value;

            Assert.NotNull(envelopeResponse.ErrorMessage);
            Assert.Equal(AgeValidationErrorMessagesConsts.INVALID_DATE, envelopeResponse.ErrorMessage);
        }

        [Fact]
        public void Calculate_With_Numeric_Response_Passing_An_Null_Reference_Of_AgeCalculateRequestDTO()
        {
            var objectResult = (ObjectResult)_ageController.CalculateWithNumericResponse(null);
            var envelopeResponse = (Envelope<string>)objectResult.Value;

            Assert.NotNull(envelopeResponse.ErrorMessage);
            Assert.Equal(AgeValidationErrorMessagesConsts.NULL_REFERENCE, envelopeResponse.ErrorMessage);
        }

        #endregion CalculateWithNumericResponse

        #region CalculateWithPlainTextResponse

        [Fact]
        public void Calculate_With_PlainText_Response_Passing_An_Valid_Date()
        {
            var ageCalculatedRequestDTO = new AgeCalculateRequestDTO
            {
                BirthDate = DateTime.Now.AddYears(-1).ToShortDateString()
            };

            var objectResult = (ObjectResult)_ageController.CalculateWithPlainTextResponse(ageCalculatedRequestDTO);
            var envelopeResponse = (Envelope<string>)objectResult.Value;

            Assert.Null(envelopeResponse.ErrorMessage);
        }

        [Fact]
        public void Calculate_With_PlainText_Response_Passing_An_Invalid_Date()
        {
            var ageCalculatedRequestDTO = new AgeCalculateRequestDTO
            {
                BirthDate = "30*/12*/1992"
            };

            var objectResult = (ObjectResult)_ageController.CalculateWithPlainTextResponse(ageCalculatedRequestDTO);
            var envelopeResponse = (Envelope<string>)objectResult.Value;

            Assert.NotNull(envelopeResponse.ErrorMessage);
            Assert.Equal(AgeValidationErrorMessagesConsts.INVALID_DATE, envelopeResponse.ErrorMessage);
        }

        [Fact]
        public void Calculate_With_PlainText_Response_Passing_An_Null_Reference_Of_AgeCalculateRequestDTO()
        {
            var objectResult = (ObjectResult)_ageController.CalculateWithPlainTextResponse(null);
            var envelopeResponse = (Envelope<string>)objectResult.Value;

            Assert.NotNull(envelopeResponse.ErrorMessage);
            Assert.Equal(AgeValidationErrorMessagesConsts.NULL_REFERENCE, envelopeResponse.ErrorMessage);
        }

        #endregion CalculateWithPlainTextResponse
    }
}
