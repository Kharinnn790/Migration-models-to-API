using Microsoft.EntityFrameworkCore;

namespace DataAccess.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext(){}

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Goal> Goals { get; set; }

    public virtual DbSet<Meeting> Meetings { get; set; }

    public virtual DbSet<MeetingParticipant> MeetingParticipants { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<Resource> Resources { get; set; }

    public virtual DbSet<ResourceAssignment> ResourceAssignments { get; set; }

    public virtual DbSet<Skill> Skills { get; set; }

    public virtual DbSet<TimeEntry> TimeEntries { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserSkill> UserSkills { get; set; }

    public virtual DbSet<UserTask> UserTasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK__Departme__B2079BCDA34A321C");

            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.Budget).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DepartmentName).HasMaxLength(100);
            entity.Property(e => e.ManagerId).HasColumnName("ManagerID");

            entity.HasOne(d => d.Manager).WithMany(p => p.Departments)
                .HasForeignKey(d => d.ManagerId)
                .HasConstraintName("FK_Departments_Manager");
        });

        modelBuilder.Entity<Goal>(entity =>
        {
            entity.HasKey(e => e.GoalId).HasName("PK__Goals__8A4FFF31510AB60C");

            entity.Property(e => e.GoalId).HasColumnName("GoalID");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Priority).HasDefaultValue(3);
            entity.Property(e => e.Progress).HasDefaultValue(0);
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("Active");
            entity.Property(e => e.Title).HasMaxLength(200);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Goals)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Goals_Users");
        });

        modelBuilder.Entity<Meeting>(entity =>
        {
            entity.HasKey(e => e.MeetingId).HasName("PK__Meetings__E9F9E9AC481FFB96");

            entity.HasIndex(e => new { e.StartDateTime, e.EndDateTime }, "IX_Meetings_DateTime");

            entity.Property(e => e.MeetingId).HasColumnName("MeetingID");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.EndDateTime).HasColumnType("datetime");
            entity.Property(e => e.Location).HasMaxLength(200);
            entity.Property(e => e.MeetingType).HasMaxLength(50);
            entity.Property(e => e.OrganizerId).HasColumnName("OrganizerID");
            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");
            entity.Property(e => e.StartDateTime).HasColumnType("datetime");
            entity.Property(e => e.Title).HasMaxLength(200);

            entity.HasOne(d => d.Organizer).WithMany(p => p.Meetings)
                .HasForeignKey(d => d.OrganizerId)
                .HasConstraintName("FK_Meetings_Users");

            entity.HasOne(d => d.Project).WithMany(p => p.Meetings)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("FK_Meetings_Projects");
        });

        modelBuilder.Entity<MeetingParticipant>(entity =>
        {
            entity.HasKey(e => e.ParticipantId).HasName("PK__MeetingP__7227997E40069F2B");

            entity.HasIndex(e => new { e.MeetingId, e.UserId }, "UC_MeetingParticipant").IsUnique();

            entity.Property(e => e.ParticipantId).HasColumnName("ParticipantID");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.MeetingId).HasColumnName("MeetingID");
            entity.Property(e => e.ResponseStatus)
                .HasMaxLength(20)
                .HasDefaultValue("Pending");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Meeting).WithMany(p => p.MeetingParticipants)
                .HasForeignKey(d => d.MeetingId)
                .HasConstraintName("FK_MeetingParticipants_Meetings");

            entity.HasOne(d => d.User).WithMany(p => p.MeetingParticipants)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_MeetingParticipants_Users");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.ProjectId).HasName("PK__Projects__761ABED0D20A58C2");

            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");
            entity.Property(e => e.Budget).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Priority).HasDefaultValue(3);
            entity.Property(e => e.ProjectManagerId).HasColumnName("ProjectManagerID");
            entity.Property(e => e.ProjectName).HasMaxLength(200);
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("Active");

            entity.HasOne(d => d.Department).WithMany(p => p.Projects)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK_Projects_Departments");

            entity.HasOne(d => d.ProjectManager).WithMany(p => p.Projects)
                .HasForeignKey(d => d.ProjectManagerId)
                .HasConstraintName("FK_Projects_Manager");
        });

        modelBuilder.Entity<Resource>(entity =>
        {
            entity.HasKey(e => e.ResourceId).HasName("PK__Resource__4ED1814F3DEA3B39");

            entity.Property(e => e.ResourceId).HasColumnName("ResourceID");
            entity.Property(e => e.Availability).HasDefaultValue(100);
            entity.Property(e => e.CostPerHour).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.CostPerUnit).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.Description).HasMaxLength(300);
            entity.Property(e => e.ResourceName).HasMaxLength(100);
            entity.Property(e => e.ResourceType).HasMaxLength(50);

            entity.HasOne(d => d.Department).WithMany(p => p.Resources)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK_Resources_Departments");
        });

        modelBuilder.Entity<ResourceAssignment>(entity =>
        {
            entity.HasKey(e => e.AssignmentId).HasName("PK__Resource__32499E5721E123D0");

            entity.HasIndex(e => e.ResourceId, "IX_ResourceAssignments_Resource");

            entity.HasIndex(e => e.TaskId, "IX_ResourceAssignments_Task");

            entity.Property(e => e.AssignmentId).HasColumnName("AssignmentID");
            entity.Property(e => e.Cost).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.HoursUsed).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");
            entity.Property(e => e.Quantity).HasDefaultValue(1);
            entity.Property(e => e.ResourceId).HasColumnName("ResourceID");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("Assigned");
            entity.Property(e => e.TaskId).HasColumnName("TaskID");

            entity.HasOne(d => d.Project).WithMany(p => p.ResourceAssignments)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("FK_ResourceAssignments_Projects");

            entity.HasOne(d => d.Resource).WithMany(p => p.ResourceAssignments)
                .HasForeignKey(d => d.ResourceId)
                .HasConstraintName("FK_ResourceAssignments_Resources");

            entity.HasOne(d => d.Task).WithMany(p => p.ResourceAssignments)
                .HasForeignKey(d => d.TaskId)
                .HasConstraintName("FK_ResourceAssignments_UserTasks");
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.HasKey(e => e.SkillId).HasName("PK__Skills__DFA091E7944D1A2F");

            entity.Property(e => e.SkillId).HasColumnName("SkillID");
            entity.Property(e => e.Category).HasMaxLength(50);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(300);
            entity.Property(e => e.SkillName).HasMaxLength(100);
        });

        modelBuilder.Entity<TimeEntry>(entity =>
        {
            entity.HasKey(e => e.TimeEntryId).HasName("PK__TimeEntr__36FCE7E951552FBD");

            entity.HasIndex(e => new { e.UserId, e.EntryDate }, "IX_TimeEntries_UserDate");

            entity.Property(e => e.TimeEntryId).HasColumnName("TimeEntryID");
            entity.Property(e => e.Approved).HasDefaultValue(false);
            entity.Property(e => e.Billable).HasDefaultValue(true);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(300);
            entity.Property(e => e.HoursWorked).HasColumnType("decimal(4, 2)");
            entity.Property(e => e.TaskId).HasColumnName("TaskID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Task).WithMany(p => p.TimeEntries)
                .HasForeignKey(d => d.TaskId)
                .HasConstraintName("FK_TimeEntries_UserTasks");

            entity.HasOne(d => d.User).WithMany(p => p.TimeEntries)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_TimeEntries_Users");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCAC28179AB0");

            entity.HasIndex(e => e.DepartmentId, "IX_Users_Department");

            entity.HasIndex(e => e.Email, "UQ__Users__A9D10534A262626A").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Position).HasMaxLength(100);

            entity.HasOne(d => d.Department).WithMany(p => p.Users)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK_Users_Departments");
        });

        modelBuilder.Entity<UserSkill>(entity =>
        {
            entity.HasKey(e => e.UserSkillId).HasName("PK__UserSkil__2F28BFB6FD29AA02");

            entity.HasIndex(e => e.UserId, "IX_UserSkills_User");

            entity.HasIndex(e => new { e.UserId, e.SkillId }, "UC_UserSkill").IsUnique();

            entity.Property(e => e.UserSkillId).HasColumnName("UserSkillID");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.SkillId).HasColumnName("SkillID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Skill).WithMany(p => p.UserSkills)
                .HasForeignKey(d => d.SkillId)
                .HasConstraintName("FK_UserSkills_Skills");

            entity.HasOne(d => d.User).WithMany(p => p.UserSkills)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_UserSkills_Users");
        });

        modelBuilder.Entity<UserTask>(entity =>
        {
            entity.HasKey(e => e.TaskId).HasName("PK__UserTask__7C6949D1EE7F8366");

            entity.HasIndex(e => e.AssignedTo, "IX_UserTasks_AssignedTo");

            entity.HasIndex(e => e.ProjectId, "IX_UserTasks_Project");

            entity.Property(e => e.TaskId).HasColumnName("TaskID");
            entity.Property(e => e.ActualHours).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.EstimatedHours).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.Priority).HasDefaultValue(3);
            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("New");
            entity.Property(e => e.TaskName).HasMaxLength(200);

            entity.HasOne(d => d.AssignedToNavigation).WithMany(p => p.UserTasks)
                .HasForeignKey(d => d.AssignedTo)
                .HasConstraintName("FK_UserTasks_Users");

            entity.HasOne(d => d.Project).WithMany(p => p.UserTasks)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("FK_UserTasks_Projects");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
