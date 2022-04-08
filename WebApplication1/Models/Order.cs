﻿using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public int OrderId { get; set; }
        public DateTime? Date { get; set; }
        public double? Total { get; set; }
        public string? Status { get; set; }
        public int CustomerId { get; set; }
        public int SalesPersonId { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual SalesPerson SalesPerson { get; set; } = null!;
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
