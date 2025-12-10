using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Goal
{
    public int GoalId { get; set; }

    public int? UserId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public DateOnly? TargetDate { get; set; }

    public int? Priority { get; set; }

    public string? Status { get; set; }

    public int? Progress { get; set; }

    public DateTime? CreatedDate { get; set; }

    public virtual User? User { get; set; }
}
