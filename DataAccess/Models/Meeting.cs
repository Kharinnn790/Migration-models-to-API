using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Meeting
{
    public int MeetingId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public int? OrganizerId { get; set; }

    public int? ProjectId { get; set; }

    public DateTime StartDateTime { get; set; }

    public DateTime EndDateTime { get; set; }

    public string? Location { get; set; }

    public string? MeetingType { get; set; }

    public DateTime? CreatedDate { get; set; }

    public virtual ICollection<MeetingParticipant> MeetingParticipants { get; set; } = new List<MeetingParticipant>();

    public virtual User? Organizer { get; set; }

    public virtual Project? Project { get; set; }
}
