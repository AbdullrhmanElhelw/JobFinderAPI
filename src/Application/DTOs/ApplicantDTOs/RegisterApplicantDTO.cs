namespace Application.DTOs.ApplicantDTOs;

public record RegisterApplicantDTO
   (string FirstName, string LastName, string Email, string Password, string ConfirmPassword);