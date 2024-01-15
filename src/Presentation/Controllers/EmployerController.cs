using Application.DTOs.EmployerDTOs;
using Application.Features.Commands.EmployerCommands.DeleteEmployer;
using Application.Features.Commands.EmployerCommands.EmployerLogin;
using Application.Features.Commands.EmployerCommands.EmployerRegister;
using Application.Features.Queries.EmployerQueries.GetEmployerById;
using Domain.Enums.ApplicationRoles;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = nameof(RolesEnum.Employer))]
    [Authorize(Roles = nameof(RolesEnum.Admin))]
    public class EmployerController(ISender sender)
        : ApiController(sender)
    {
        private readonly ISender _sender = sender;

        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> EmployerRegister([FromBody] RegisterEmployerDTO registerEmployerDTO, CancellationToken cancellationToken)
        {
            var result = await _sender.Send
                (new EmployerRegisterCommand
                                   (registerEmployerDTO.Email, registerEmployerDTO.Password, registerEmployerDTO.ConfirmPassword, registerEmployerDTO.FirstName, registerEmployerDTO.LastName, registerEmployerDTO.CompanyId), cancellationToken);

            return result.IsSuccess
                ? Ok(result)
                : HandleFailure(result);
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> EmployerLogin([FromBody] LoginEmployerDTO loginEmployerDTO, CancellationToken cancellationToken)
        {
            var result = await _sender.Send
                (new EmployerLoginCommand(loginEmployerDTO.Email, loginEmployerDTO.Password), cancellationToken);
            return result.IsSuccess
                ? Ok(result)
                : HandleFailure(result);
        }

        [HttpGet("Get/{id:int}")]
        public async Task<IActionResult> GetEmployerById(int id, CancellationToken cancellationToken)
        {
            var result = await _sender.Send(new GetEmployerByIdQuery(id), cancellationToken);
            return result.IsSuccess
                ? Ok(result)
                : HandleFailure(result);
        }

        [HttpDelete("Delete/{id:int}")]
        public async Task<IActionResult> DeleteEmployer(int id, CancellationToken cancellationToken)
        {
            var result = await _sender.Send(new DeleteEmployerCommand(id), cancellationToken);
            return result.IsSuccess
                ? Ok(result)
                : HandleFailure(result);
        }
    }
}