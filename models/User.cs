using System;
using System.Collections.Generic;

namespace volonteer_center.models;

public partial class User
{
    public int Id { get; set; }

    public string LastName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string MiddleName { get; set; } = null!;

    public int RoleId { get; set; }

    public string Email { get; set; } = null!;

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();

    public virtual ICollection<RegistrationOfVolunteer> RegistrationOfVolunteers { get; set; } = new List<RegistrationOfVolunteer>();

    public virtual Role Role { get; set; } = null!;
}
