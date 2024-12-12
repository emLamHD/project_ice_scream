using System;
using System.Collections.Generic;

namespace demoDataFirst.Models;

public partial class Membership
{
    public int MembershipId { get; set; }

    public int? UserId { get; set; }

    public string Type { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public decimal Price { get; set; }
}
