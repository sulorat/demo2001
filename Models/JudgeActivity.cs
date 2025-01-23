using System;
using System.Collections.Generic;

namespace demo2001.Models;

public partial class JudgeActivity
{
    public int JudgeId { get; set; }

    public int ActivityId { get; set; }

    public int ParticipantId { get; set; }

    public virtual Activity Activity { get; set; } = null!;

    public virtual Judge Judge { get; set; } = null!;

    public virtual Participant Participant { get; set; } = null!;
}
