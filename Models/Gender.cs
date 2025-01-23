﻿using System;
using System.Collections.Generic;

namespace demo2001.Models;

public partial class Gender
{
    public char Code { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<Judge> Judges { get; set; } = new List<Judge>();

    public virtual ICollection<Moderator> Moderators { get; set; } = new List<Moderator>();

    public virtual ICollection<Organizer> Organizers { get; set; } = new List<Organizer>();

    public virtual ICollection<Participant> Participants { get; set; } = new List<Participant>();
}
