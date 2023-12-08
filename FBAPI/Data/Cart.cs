﻿using System;
using System.Collections.Generic;

namespace FBAPI.Data;

public partial class Cart
{
    public int Id { get; set; }

    public int? CustomerId { get; set; }

    public int? RestaurantId { get; set; }

    public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

    public virtual Customer? Customer { get; set; }

    public virtual Restaurant? Restaurant { get; set; }
}
