using System;
using System.Collections.Generic;

namespace volonteer_center.models;

public partial class Event
{
    public int Id { get; set; }

    public string EventName { get; set; } = null!;

    public int CategoryId { get; set; }

    public DateOnly Date { get; set; }

    public string Place { get; set; } = null!;

    public int NeedVolonters { get; set; }

    public int CoordinatorId { get; set; }

    public int EventStatusId { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual User Coordinator { get; set; } = null!;

    public virtual EventStatus EventStatus { get; set; } = null!;

    public virtual ICollection<RegistrationOfVolunteer> RegistrationOfVolunteers { get; set; } = new List<RegistrationOfVolunteer>();
}
