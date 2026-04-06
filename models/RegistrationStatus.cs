using System;
using System.Collections.Generic;

namespace volonteer_center.models;

public partial class RegistrationStatus
{
    public int Id { get; set; }

    public string StatusName { get; set; } = null!;

    public virtual ICollection<RegistrationOfVolunteer> RegistrationOfVolunteers { get; set; } = new List<RegistrationOfVolunteer>();
}
