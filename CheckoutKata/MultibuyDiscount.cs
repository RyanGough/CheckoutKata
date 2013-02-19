using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckoutKata
{
    public class MultibuyDiscount
    {
        public MultibuyDiscount(int quantity, int discountPrice)
        {
            Quantity = quantity;
            DiscountPrice = discountPrice;            
        }
        public int DiscountPrice { get; private set; }
        public int Quantity { get; private set; }
    }
}
