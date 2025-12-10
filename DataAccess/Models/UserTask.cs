using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class UserTask
{
    public int TaskId { get; set; }

    public string TaskName { get; set; } = null!;

    public string? Description { get; set; }

    public int? ProjectId { get; set; }

    public int? AssignedTo { get; set; }

    public decimal? EstimatedHours { get; set; }

    public decimal? ActualHours { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? DueDate { get; set; }

    public string? Status { get; set; }

    public int? Priority { get; set; }

    public DateTime? CreatedDate { get; set; }

    public virtual User? AssignedToNavigation { get; set; }

    public virtual Project? Project { get; set; }

    public virtual ICollection<ResourceAssignment> ResourceAssignments { get; set; } = new List<ResourceAssignment>();

    public virtual ICollection<TimeEntry> TimeEntries { get; set; } = new List<TimeEntry>();
}
