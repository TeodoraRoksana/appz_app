namespace MedApp.Domain.DTO
{
    public class AnalysisShortDataDTO
    {
        public int AnalysisId { get; set; } = 0;

        public string AnalysisName { get; set; } = string.Empty;

        public string PatientName { get; set; } = string.Empty;

        public string PatientSurname { get; set; } = string.Empty;

        public string? Date { get; set; }
    }
}
