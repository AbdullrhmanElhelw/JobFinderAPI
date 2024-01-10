using Application.DapperQueries.QueryBase;
using Application.DTOs.SkillDTOs;
using Domain.Models;

namespace Application.DapperQueries.SKillQueries;

public interface ISkillQuery : IQueryBase<Skill>
{
    Task<IQueryable<ReadSkillDTO>> GetApplicantSkill(int applicantId);

    Task<IQueryable<Skill>> FindSkill(string filter);

    Task<IQueryable<Skill>> GetAllWithPaging(int pageSize, int pageNumber, string Filter = "", string SortOrder = "");
}