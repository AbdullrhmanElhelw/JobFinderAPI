namespace Application.DTOs.EmailDTOs;

public record ResetPasswordDTO
  (string Email, string OldPassword, string Password, string ConfirmPassword, string Token);