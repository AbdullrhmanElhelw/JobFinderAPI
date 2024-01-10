namespace Application.DTOs.EmailDTOs;

public record UpdateEmailDTO
    (string Email, string NewEmail, string ConfirmNewEmail, string Password);