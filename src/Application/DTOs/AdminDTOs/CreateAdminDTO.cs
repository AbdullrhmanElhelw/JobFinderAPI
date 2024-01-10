namespace Application.DTOs.AdminDTOs;

public record CreateAdminDTO
    (string Email, string Password, string ConfirmPassword, string FirstName, string LastName);