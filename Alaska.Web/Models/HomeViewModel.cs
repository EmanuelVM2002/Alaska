﻿namespace Alaska.Web.Models
{
    public class HomeViewModel
    {
        public ICollection<ProductsHomeViewModel> Products { get; set; }
        public float Quantity { get; set; }
    }

}
