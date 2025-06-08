using System;
using System.Collections.Generic;

namespace Historical__Facts_3.Models;

public partial class Person
{
    public int PersonId { get; set; }

    public string? Name { get; set; }

    public string? Descr { get; set; }

    public int? BirthYear { get; set; }

    public byte? BirthMonth { get; set; }

    public byte? BirthDay { get; set; }

    public int? DeathYear { get; set; }

    public byte? DeathMonth { get; set; }

    public byte? DeathDay { get; set; }
}
