using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CheckoutKata;
using System.Collections.Generic;

namespace CheckoutKata_Test
{
    [TestClass]
    public class SimpleCheckoutTests
    {
        PricingRules pricingRules;
        Checkout checkout;

        [TestInitialize]
        public void SimpleCheckoutTests_Setup()
        {
            pricingRules = new PricingRules();
            pricingRules.Price("A", 10);
            pricingRules.Price("B", 20);
            pricingRules.MultibuyDiscount("A", 2, 15);
            checkout = new Checkout(pricingRules);
        }

        private void ScanItems(Checkout checkout, string items)
        {
            List<string> itemList = new List<string>(items.Split(','));
            itemList.ForEach(item => checkout.Scan(item));
        }

        [TestMethod]
        public void GetPriceWhenNoItemsScannedReturnsZero()
        {     
            Assert.AreEqual(0, checkout.TotalPrice());
        }

        [TestMethod]
        public void GetPriceWhenSingleItemScannedReturnsPrice()
        {     
            checkout.Scan("A");
            Assert.AreEqual(10, checkout.TotalPrice());
        }

        [TestMethod]
        public void GetPriceWhenScannedTwoItemsReturnsPrice()
        {
            ScanItems(checkout, "A,B");
            Assert.AreEqual(30, checkout.TotalPrice());            
        }

        [TestMethod]
        public void GetPriceWhenMultibuyDiscountAppliedItemsReturnsPrice()
        {
            ScanItems(checkout, "A,A,A");
            Assert.AreEqual(25, checkout.TotalPrice());
        }

        [TestMethod]
        public void GetPriceWhenMultibuyDiscountAppliedTwiceItemsReturnsPrice()
        {
            ScanItems(checkout, "A,A,A,A");
            Assert.AreEqual(30, checkout.TotalPrice());
        }
    }
}
