using System;
using System.Collections.Generic;

namespace CheckoutKata
{
    public class Checkout
    {
        private PricingRules priceRules;
        private int runningTotal = 0;
        private IDictionary<string, int> itemsInTransaction = new Dictionary<string, int>();
        
        public Checkout(PricingRules pricingRules)
        {
            priceRules = pricingRules;
        }

        public void Scan(string item)
        {
            AddItemToTransaction(item);
            UpdateTransactionTotal(item);
        }

        private void UpdateTransactionTotal(string item)
        {
            runningTotal += priceRules.Price(item);
            runningTotal += priceRules.MultibuyDiscount(item, itemsInTransaction[item]);
        }

        public int TotalPrice()
        {
            return runningTotal;
        }
        
        private void AddItemToTransaction(string item)
        {
            if (!itemsInTransaction.ContainsKey(item))
            {
                itemsInTransaction[item] = 1;
            }
            else
            {
                itemsInTransaction[item]++;
            }
        }
    }
}
