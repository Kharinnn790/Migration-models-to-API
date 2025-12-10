using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Project
{
    public int ProjectId { get; set; }

    public string ProjectName { get; set; } = null!;

    public string? Description { get; set; }

    public int? DepartmentId { get; set; }

    public int? ProjectManagerId { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public decimal? Budget { get; set; }

    public string? Status { get; set; }

    public int? Priority { get; set; }

    public DateTime? CreatedDate { get; set; }

    public virtual Department? Department { get; set; }

    public virtual ICollection<Meeting> Meetings { get; set; } = new List<Meeting>();

    public virtual User? ProjectManager { get; set; }

    public virtual ICollection<ResourceAssignment> ResourceAssignments { get; set; } = new List<ResourceAssignment>();

    public virtual ICollection<UserTask> UserTasks { get; set; } = new List<UserTask>();
}
