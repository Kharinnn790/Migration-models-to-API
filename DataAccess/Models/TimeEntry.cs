using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class TimeEntry
{
    public int TimeEntryId { get; set; }

    public int? UserId { get; set; }

    public int? TaskId { get; set; }

    public DateOnly EntryDate { get; set; }

    public decimal HoursWorked { get; set; }

    public string? Description { get; set; }

    public bool? Billable { get; set; }

    public bool? Approved { get; set; }

    public DateTime? CreatedDate { get; set; }

    public virtual UserTask? Task { get; set; }

    public virtual User? User { get; set; }
}
