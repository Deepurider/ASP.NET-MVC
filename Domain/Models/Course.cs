﻿using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Course
{
    public int CourseId { get; set; }

    public string? Name { get; set; }

    public int? Duration { get; set; }

    public string? Fee { get; set; }

    public virtual ICollection<Student> Student { get; set; } = new List<Student>();
}
