using System;
using System.Collections.Generic;

namespace Mis.Services.Customer.Api.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string ContactPersonEmail { get; set; } = null!;

    public string ContactPersonName { get; set; } = null!;

    public string Mobile { get; set; } = null!;

    public string Name { get; set; } = null!;

    public virtual ICollection<Project> Projects { get; } = new List<Project>();
}
