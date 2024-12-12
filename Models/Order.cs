using System;
using System.Collections.Generic;

namespace demoDataFirst.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int? UserId { get; set; }

    public decimal TotalAmount { get; set; }

    public string PaymentMethod { get; set; } = null!;

    public DateTime? OrderDate { get; set; }

    public string? Status { get; set; }
}
