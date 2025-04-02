using System;
using System.Collections.Generic;

namespace Remz_Health.Models;

public partial class Subscription
{
    public int Id { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public string? SubscriptionName { get; set; }

    public virtual ICollection<Hospital> Hospitals { get; set; } = new List<Hospital>();
}
