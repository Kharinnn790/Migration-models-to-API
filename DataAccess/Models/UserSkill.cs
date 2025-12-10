using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class UserSkill
{
    public int UserSkillId { get; set; }

    public int? UserId { get; set; }

    public int? SkillId { get; set; }

    public int? ProficiencyLevel { get; set; }

    public int? YearsOfExperience { get; set; }

    public DateTime? CreatedDate { get; set; }

    public virtual Skill? Skill { get; set; }

    public virtual User? User { get; set; }
}
