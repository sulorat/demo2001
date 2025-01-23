using System;
using System.Collections.Generic;

namespace demo2001.Models;

public partial class Country
{
    public int Code { get; set; }

    public string NameRu { get; set; } = null!;

    public string NameEng { get; set; } = null!;

    public virtual ICollection<Judge> Judges { get; set; } = new List<Judge>();

    public virtual ICollection<Moderator> Moderators { get; set; } = new List<Moderator>();

    public virtual ICollection<Organizer> Organizers { get; set; } = new List<Organizer>();

    public virtual ICollection<Participant> Participants { get; set; } = new List<Participant>();
}
