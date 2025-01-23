using System;
using System.Collections.Generic;

namespace demo2001.Models;

public partial class Competition
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<Judge> Judges { get; set; } = new List<Judge>();

    public virtual ICollection<Moderator> Moderators { get; set; } = new List<Moderator>();
}
