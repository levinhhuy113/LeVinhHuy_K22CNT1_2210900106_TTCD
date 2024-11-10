using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LEVINHHUY_K22CNT1_2210900106_PROJECT2.ModelView
{
    public class CartItem
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public string Image { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public float Total { get; set; }

    }
}