using LEVINHHUY_K22CNT1_2210900106_PROJECT2.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LEVINHHUY_K22CNT1_2210900106_PROJECT2.Bussiness
{
    public class ShoppingCart
    {
        public List<CartItem> Items { get; set; }
        public ShoppingCart ()
        {
            Items = new List<CartItem>();
        }
    public void AddToCart(CartItem item)
    {
        var existingItem = Items.FirstOrDefault(c => c.Id == item.Id);
        if (existingItem != null)
        {
            existingItem.Quantity += item.Quantity;
        }
        else
        {
            Items.Add(item);
        }
    }
        public void UpdateToCart(int id, int quantity)
        {
            var existingItem = Items.FirstOrDefault(c => c.Id == id);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
        }

        public void RemoveFromCart(int id)
    {
        
        var itemToRemove = Items.FirstOrDefault(c => c.Id == id);
        if (itemToRemove != null)
        {
            Items.Remove(itemToRemove);
        }   
    }

    public float GetTotal()
    {
            return Items.Sum(c => c.Price * c.Quantity);
    }
    
     // Cập nhật giỏ hàng
     public void UpdateFromCart(int id, int quantity)
        {
            var existingItem = Items.FirstOrDefault(c => c.Id == id);
            if(existingItem !=null)
            {
                existingItem.Quantity = quantity;
            }    
        }

    }
}