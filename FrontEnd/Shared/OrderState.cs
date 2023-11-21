﻿using FrontEnd.Pages;
using FrontEnd.Pages.Dto;

namespace FrontEnd.Shared
{
    public class OrderState
    {
        public List<OrderingItemDto> ItemsInOrder { get; set; } = new List<OrderingItemDto>();
        public Data.Restaurant? Restaurant { get; set; } = null;

        // public bool HasBeenOrdered { get; set; } = false;
        // public bool HasBeenPaidFor { get; set; } = false;
    }
}
