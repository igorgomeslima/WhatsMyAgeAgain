namespace WhatsMyAgeAgain.Api.DTO
{
    public class AgeCalculateResponseDTO
    {
        public double AgeInDays { get; set; }
        public double AgeInMonths { get; set; }
        public double AgeInYears { get; set; }
    }

    public class AgeCalculateRequestDTO
    {
        public string BirthDate { get; set; }
    }
}
