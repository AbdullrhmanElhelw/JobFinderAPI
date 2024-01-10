// Ignore Spelling: admin Admins
using Application.DTOs.AdminDTOs;
using Application.Features.Commands.AdminCommands.AdminLogout;
using Application.Features.Commands.AdminCommands.ApplicantLogin;
using Application.Features.Commands.AdminCommands.CreateAdmin;
using Application.Features.Commands.AdminCommands.DeleteAdmin;
using Application.Features.Commands.AdminCommands.PartialUpdate;
using Application.Features.Commands.AdminCommands.UpdateAdmin;
using Application.Features.Queries.AdminQueries.GetAdmin;
using Application.Features.Queries.AdminQueries.GetAllAdmins;
using Application.Features.Queries.AdminQueries.GetAllAdminsWithPaging;
using Domain.Enums.ApplicationRoles;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = nameof(RolesEnum.Admin))]
public class AdminController(ISender sender)
    : ApiController(sender)
{
    private readonly ISender _sender = sender;

    [HttpPost("CreateAdmin")]
    public async Task<IActionResult> CreateAdmin([FromBody] CreateAdminDTO admin)
    {
        var result = await _sender.Send(new CreateAdminCommand(admin.Email, admin.Password, admin.ConfirmPassword, admin.FirstName, admin.LastName));
        return result.IsSuccess ? Ok(result) : HandleFailure(result);
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] LoginAdminDTO admin)
    {
        var result = await _sender.Send(new AdminLoginCommand(admin.Email, admin.Password));
        return result.IsSuccess ? Ok(result) : HandleFailure(result);
    }

    [HttpPost("Logout")]
    public async Task<IActionResult> Logout([FromBody] AdminLogoutDTO admin)
    {
        var result = await _sender.Send(new AdminLogoutCommand(admin.Id, admin.Token));
        return result.IsSuccess ? Ok(result) : HandleFailure(result);
    }

    [HttpGet("GetAdmin")]
    public async Task<IActionResult> GetAdmin([FromQuery] int id)
    {
        var result = await _sender.Send(new GetAdminQuery(id));
        return result.IsSuccess ? Ok(result) : HandleFailure(result);
    }

    [HttpGet("GetAllAdmins")]
    public async Task<IActionResult> GetAllAdmins()
    {
        var result = await _sender.Send(new GetAllAdminsQuery());
        return result.IsSuccess ? Ok(result) : HandleFailure(result);
    }

    [HttpGet("GetAllAdminsWithPaging")]
    public async Task<IActionResult> GetAllAdminsWithPaging([FromQuery] int pageSize, [FromQuery] int pageNumber)
    {
        var result = await _sender.Send(new GetAllAdminsWithPagingQuery(pageSize, pageNumber));
        return result.IsSuccess ? Ok(result) : HandleFailure(result);
    }

    [HttpDelete("DeleteAdmin")]
    public async Task<IActionResult> DeleteAdmin([FromQuery] int id)
    {
        var result = await _sender.Send(new DeleteAdminCommand(id));
        return result.IsSuccess ? Ok(result) : HandleFailure(result);
    }

    [HttpPut("UpdateAdmin")]
    public async Task<IActionResult> UpdateAdmin([FromBody] UpdateAdminDTO admin)
    {
        var result = await _sender.Send(new UpdateAdminCommand(admin.Id, admin.FirstName, admin.LastName));
        return result.IsSuccess ? Ok(result) : HandleFailure(result);
    }

    [HttpPatch("PartialUpdateAdmin")]
    public async Task<IActionResult> PartialUpdateAdmin([FromQuery] string email, JsonPatchDocument adminPD, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(new AdminPartialUpdateCommand(email, adminPD));
        return result.IsSuccess ? Ok(result) : HandleFailure(result);
    }
}