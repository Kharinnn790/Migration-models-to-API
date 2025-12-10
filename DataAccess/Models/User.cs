using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class User
{
    public int UserId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Position { get; set; }

    public int? DepartmentId { get; set; }

    public DateOnly HireDate { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedDate { get; set; }

    public virtual Department? Department { get; set; }

    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();

    public virtual ICollection<Goal> Goals { get; set; } = new List<Goal>();

    public virtual ICollection<MeetingParticipant> MeetingParticipants { get; set; } = new List<MeetingParticipant>();

    public virtual ICollection<Meeting> Meetings { get; set; } = new List<Meeting>();

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();

    public virtual ICollection<TimeEntry> TimeEntries { get; set; } = new List<TimeEntry>();

    public virtual ICollection<UserSkill> UserSkills { get; set; } = new List<UserSkill>();

    public virtual ICollection<UserTask> UserTasks { get; set; } = new List<UserTask>();
}
