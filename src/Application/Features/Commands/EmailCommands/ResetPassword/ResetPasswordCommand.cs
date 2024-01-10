using Application.Abstractions;

namespace Application.Features.Commands.EmailCommands.ResetPassword;

public sealed record ResetPasswordCommand
    (string Email, string OldPassword, string Password, string ConfirmPassword, string Token) : ICommand;