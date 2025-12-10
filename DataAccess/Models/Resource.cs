using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Resource
{
    public int ResourceId { get; set; }

    public string ResourceName { get; set; } = null!;

    public string ResourceType { get; set; } = null!;

    public string? Description { get; set; }

    public decimal? CostPerHour { get; set; }

    public decimal? CostPerUnit { get; set; }

    public int? Availability { get; set; }

    public int? DepartmentId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public virtual Department? Department { get; set; }

    public virtual ICollection<ResourceAssignment> ResourceAssignments { get; set; } = new List<ResourceAssignment>();
}
