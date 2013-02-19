using System;
using System.Collections.Generic;

namespace CheckoutKata
{
    public class PricingRules
    {
        private IDictionary<string, int> _PriceList = new Dictionary<string, int>();
        private IDictionary<string, MultibuyDiscount> _DiscountList = new Dictionary<string, MultibuyDiscount>();

        public void Price(string item, int price)
        {
            _PriceList.Add(item, price);
        }

        public int Price(string item)
        {
            return _PriceList[item];
        }
        
        public void MultibuyDiscount(string item, int quantity, int discountPrice)
        {
            _DiscountList.Add(item, new MultibuyDiscount(quantity, discountPrice));
        }

        public int MultibuyDiscount(string item, int quantityInTransaction)
        {
            return QualifiesForDiscount(item, quantityInTransaction) ? CalculateDiscountValue(item) : 0;
        }

        private bool QualifiesForDiscount(string item, int quantityInTransaction)
        {
            return _DiscountList.ContainsKey(item) && quantityInTransaction % _DiscountList[item].Quantity == 0;
        }

        private int CalculateDiscountValue(string item)
        {
            return Discount(item).DiscountPrice - Price(item) * Discount(item).Quantity;
        }

        private MultibuyDiscount Discount(string item)
        {
            return _DiscountList[item];
        }
    }
}
