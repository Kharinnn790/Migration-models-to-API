using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class ResourceAssignment
{
    public int AssignmentId { get; set; }

    public int? ResourceId { get; set; }

    public int? TaskId { get; set; }

    public int? ProjectId { get; set; }

    public DateOnly AssignedDate { get; set; }

    public DateOnly? ReturnDate { get; set; }

    public int? Quantity { get; set; }

    public decimal? HoursUsed { get; set; }

    public decimal? Cost { get; set; }

    public string? Status { get; set; }

    public DateTime? CreatedDate { get; set; }

    public virtual Project? Project { get; set; }

    public virtual Resource? Resource { get; set; }

    public virtual UserTask? Task { get; set; }
}
