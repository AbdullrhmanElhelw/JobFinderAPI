using Domain.Enums.SkillLevels;

namespace Domain.Models;

public class Skill
{
    #region properties
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Level Level { get; set; }
    #endregion

    #region relationships
    public ICollection<ApplicantSkill> Applicants { get; set; } = [];
    public ICollection<JobSkill> JobSkills { get; set; } = [];
    #endregion
}
