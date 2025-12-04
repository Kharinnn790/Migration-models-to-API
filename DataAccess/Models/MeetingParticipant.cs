using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class MeetingParticipant
{
    public int ParticipantId { get; set; }

    public int? MeetingId { get; set; }

    public int? UserId { get; set; }

    public string? ResponseStatus { get; set; }

    public bool? Attendance { get; set; }

    public DateTime? CreatedDate { get; set; }

    public virtual Meeting? Meeting { get; set; }

    public virtual User? User { get; set; }
}
