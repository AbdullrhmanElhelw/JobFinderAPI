namespace Application.DTOs.EmailDTOs;

public record ConfirmUpdateEmailDTO
    (string OldEmail, string Email, string Token);