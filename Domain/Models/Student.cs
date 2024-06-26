﻿using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public int? PersonId { get; set; }

    public string? ClassName { get; set; }

    public bool? Deleted { get; set; }

    public DateTime? Created { get; set; }

    public DateTime? Updated { get; set; }

    public int? CourseId { get; set; }

    public virtual Course? Course { get; set; }

    public virtual Person? Person { get; set; }
}
