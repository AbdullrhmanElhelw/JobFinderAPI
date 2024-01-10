using Application.DTOs.CompanyDTOs;
using Application.Features.Commands.CompanyCommands.CompanyLogin;
using Application.Features.Commands.CompanyCommands.CompanyRegistration;
using Application.Features.Commands.CompanyCommands.DeleteCompany;
using Application.Features.Commands.CompanyCommands.PartialUpdate;
using Application.Features.Commands.CompanyCommands.UpdateCompany;
using Application.Features.Queries.CompanyQueries.FindCompany;
using Application.Features.Queries.CompanyQueries.GetAllCompanies;
using Application.Features.Queries.CompanyQueries.GetAllCompaniesWithJobs;
using Application.Features.Queries.CompanyQueries.GetJobApplicants;
using Domain.Enums.ApplicationRoles;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(nameof(RolesEnum.Company))]
    [Authorize(nameof(RolesEnum.Admin))]
    public class CompanyController(ISender sender)
        : ApiController(sender)
    {
        private readonly ISender _sender = sender;

        [HttpPost("register")]
        public async Task<IActionResult> CompanyRegister([FromBody] RegisterCompanyDTO registerCompanyDTO, CancellationToken cancellationToken)
        {
            var result = await _sender.Send(new CompanyRegistrationCommand
                (registerCompanyDTO.Name, registerCompanyDTO.Email, registerCompanyDTO.Password, registerCompanyDTO.ConfirmPassword,
                    registerCompanyDTO.Address, registerCompanyDTO.City, registerCompanyDTO.Country), cancellationToken);

            return result.IsSuccess ? Ok(result) : HandleFailure(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> CompanyLogin([FromBody] LoginCompanyDTO loginCompanyDTO, CancellationToken cancellationToken)
        {
            var result = await _sender.Send(new CompanyLoginCommand(loginCompanyDTO.Email, loginCompanyDTO.Password), cancellationToken);

            return result.IsSuccess ? Ok(result) : HandleFailure(result);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await _sender.Send(new GetAllCompaniesQuery(), cancellationToken);

            return result.IsSuccess ? Ok(result) : HandleFailure(result);
        }

        [HttpGet("GetAll/{filter}")]
        public async Task<IActionResult> GetAll(string filter, CancellationToken cancellationToken)
        {
            var result = await _sender.Send(new FindCompanyQuery(filter), cancellationToken);

            return result.IsSuccess ? Ok(result) : HandleFailure(result);
        }

        [HttpGet("GetAllWithJobs")]
        public async Task<IActionResult> GetAllWithJobs(CancellationToken cancellationToken)
        {
            var result = await _sender.Send(new GetAllCompaniesWithJobsQuery(), cancellationToken);

            return result.IsSuccess ? Ok(result) : HandleFailure(result);
        }

        [HttpGet("GetJobApplicants/{companyId:int}/{jobId:int}")]
        public async Task<IActionResult> GetJobApplicants(int companyId, int jobId, CancellationToken cancellationToken)
        {
            var result = await _sender.Send(new GetJobApplicantsQuery(companyId, jobId), cancellationToken);

            return result.IsSuccess ? Ok(result) : HandleFailure(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var result = await _sender.Send(new DeleteCompanyCommand(id), cancellationToken);

            return result.IsSuccess ? Ok(result) : HandleFailure(result);
        }

        [HttpPut("Update/{Id:int}")]
        public async Task<IActionResult> Update(int Id, [FromBody] UpdateCompanyDTO updateCompanyDTO, CancellationToken cancellationToken)
        {
            var result = await _sender.Send(
                new UpdateCompanyCommand
                    (Id, updateCompanyDTO.Name, updateCompanyDTO.Address, updateCompanyDTO.City, updateCompanyDTO.Country), cancellationToken);

            return result.IsSuccess ? Ok(result) : HandleFailure(result);
        }

        [HttpPatch("PartialUpdate/{Email}")]
        public async Task<IActionResult> PartialUpdate(string Email, [FromBody] JsonPatchDocument companyPatch, CancellationToken cancellationToken)
        {
            var result = await _sender.Send(new CompanyPartialUpdateCommand(Email, companyPatch), cancellationToken);

            return result.IsSuccess ? Ok(result) : HandleFailure(result);
        }
    }
}