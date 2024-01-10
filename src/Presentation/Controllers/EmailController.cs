using Application.DTOs.ApplicantDTOs;
using Application.DTOs.EmailDTOs;
using Application.Features.Commands.EmailCommands.ComfirmEmail;
using Application.Features.Commands.EmailCommands.ConfirmUpdatedEmail;
using Application.Features.Commands.EmailCommands.ResetPassword;
using Application.Features.Commands.EmailCommands.SendResetPasswordEmail;
using Application.Features.Commands.EmailCommands.UpdateEmail;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmailController(ISender sender)
        : ApiController(sender)
    {
        private readonly ISender _sender = sender;

        [HttpPost("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail([FromBody] ConfirmEmailDTO confirmEmailDTO, CancellationToken cancellationToken)
        {
            var result = await _sender.Send(new ConfirmEmailCommand(confirmEmailDTO.Email, confirmEmailDTO.Token), cancellationToken);
            return Ok(result);
        }

        [HttpPost("SendResetPasswordEmail")]
        public async Task<IActionResult> SendResetEmail(
            [FromBody] SendResetPasswordEmailDTO sendResetEmailDTO,
            CancellationToken cancellationToken)
        {
            var result = await _sender.Send(
                new SendResetPasswordCommand(sendResetEmailDTO.Email),
                cancellationToken);
            return result.IsSuccess ? Ok(result) : HandleFailure(result);
        }

        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword(
            [FromBody] ResetPasswordDTO resetPasswordDTO,
            CancellationToken cancellationToken)
        {
            var result
                = await _sender.Send(new ResetPasswordCommand(resetPasswordDTO.Email,
                    resetPasswordDTO.OldPassword, resetPasswordDTO.Password,
                    resetPasswordDTO.ConfirmPassword, resetPasswordDTO.Token), cancellationToken);
            return result.IsSuccess ? Ok(result) : HandleFailure(result);
        }

        [HttpPut("UpdateEmail")]
        public async Task<IActionResult> UpdateEmail([FromBody] UpdateEmailDTO emailDTO)
        {
            var result = await _sender.Send(new UpdateEmailCommand(emailDTO.Email, emailDTO.NewEmail, emailDTO.ConfirmNewEmail, emailDTO.Password));

            return result.IsSuccess ?
                Ok(result) :
                HandleFailure(result);
        }

        [HttpPost("ConfirmUpdateEmail")]
        public async Task<IActionResult> ConfirmUpdateEmail([FromBody] ConfirmUpdateEmailDTO confirmUpdateEmailDTO)
        {
            var result = await _sender.Send(new ConfirmUpdatedEmailCommand(confirmUpdateEmailDTO.OldEmail, confirmUpdateEmailDTO.Email, confirmUpdateEmailDTO.Token));

            return result.IsSuccess ?
                Ok(result) :
                HandleFailure(result);
        }
    }
}