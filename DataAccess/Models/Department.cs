using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Department
{
    public int DepartmentId { get; set; }

    public string DepartmentName { get; set; } = null!;

    public int? ManagerId { get; set; }

    public decimal? Budget { get; set; }

    public DateTime? CreatedDate { get; set; }

    public virtual User? Manager { get; set; }

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();

    public virtual ICollection<Resource> Resources { get; set; } = new List<Resource>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
