namespace Application.DTOs.CompanyDTOs;

public class ReadCompanyWithJobDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Country { get; set; } = null!;
    public string City { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string Email { get; set; } = null!;
    public IEnumerable<ReadJobOfCompanyDTO> Jobs { get; set; } = [];
}


