namespace Application.DTOs.CompanyDTOs;

public class ReadJobOfCompanyDTO
{
    public int JobId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string JobDescription { get; set; } = string.Empty;
    public string EmployerName { get; set; } = string.Empty;
}