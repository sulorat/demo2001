using System;
using System.Collections.Generic;

namespace demo2001.Models;

public partial class Participant
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Patronymic { get; set; } = null!;

    public string Pasword { get; set; } = null!;

    public char Gender { get; set; }

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateOnly Birthday { get; set; }

    public int? Country { get; set; }

    public string Photo { get; set; } = null!;

    public virtual Country? CountryNavigation { get; set; }

    public virtual Gender GenderNavigation { get; set; } = null!;

    public virtual ICollection<JudgeActivity> JudgeActivities { get; set; } = new List<JudgeActivity>();

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}
