using System;
using System.Collections.Generic;

namespace volonteer_center.models;

public partial class RegistrationOfVolunteer
{
    public int Id { get; set; }

    public int EventId { get; set; }

    public int VolonteerId { get; set; }

    public DateOnly RegistrationDate { get; set; }

    public int RedistrationStatusId { get; set; }

    public virtual Event Event { get; set; } = null!;

    public virtual RegistrationStatus RedistrationStatus { get; set; } = null!;

    public virtual User Volonteer { get; set; } = null!;
}
