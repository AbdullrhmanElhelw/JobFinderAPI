namespace Application.Features.Queries.ApplicantQueries.GetApplicantSkills;

public sealed record GetApplicantSkillResponse
 (int Id, string Name, string Description, int Level);