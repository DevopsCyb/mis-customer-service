using System;
using System.Collections.Generic;

namespace Mis.Services.Customer.Api.Models;

public partial class Project
{
    public int ProjectId { get; set; }

    public DateTime? ProjectStartDate { get; set; }

    public DateTime? ProjectEndDate { get; set; }

    public int? CustomerId { get; set; }

    public virtual Customer? Customer { get; set; }
}
