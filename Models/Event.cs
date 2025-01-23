using System;
using System.Collections.Generic;

namespace demo2001.Models;

public partial class Event
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public DateOnly StartDate { get; set; }

    public int? DurationDays { get; set; }

    public virtual ICollection<Activity> Activities { get; set; } = new List<Activity>();

    public virtual ICollection<Participant> Participants { get; set; } = new List<Participant>();
}
