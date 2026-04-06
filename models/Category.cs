using System;
using System.Collections.Generic;

namespace volonteer_center.models;

public partial class Category
{
    public int Id { get; set; }

    public string CategoryName { get; set; } = null!;

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}
