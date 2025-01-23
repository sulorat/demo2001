using System;
using System.Collections.Generic;

namespace demo2001.Models;

public partial class Activity
{
    public int Id { get; set; }

    public int? EventId { get; set; }

    public string Title { get; set; } = null!;

    public int? Day { get; set; }

    public TimeOnly? StartTime { get; set; }

    public virtual Event? Event { get; set; }

    public virtual ICollection<JudgeActivity> JudgeActivities { get; set; } = new List<JudgeActivity>();
}
