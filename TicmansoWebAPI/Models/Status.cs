﻿using System;
using System.Collections.Generic;

namespace TicmansoWebAPI.Models;

public partial class Status
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}