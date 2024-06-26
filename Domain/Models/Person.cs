﻿using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Person
{
    public int PersonId { get; set; }

    public string? Name { get; set; }

    public string? PhoneNumber { get; set; }

    public string? City { get; set; }

    public bool? Deleted { get; set; }

    public DateTime? Created { get; set; }

    public DateTime? Updated { get; set; }

    public virtual ICollection<Student> Student { get; set; } = new List<Student>();
}
