using july_2021.Util;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace july_2021.Model
{
   public  class BillingOrder
    {
         
        public string addressLine1 { get; set; }
        public string addressLine2 { get; set; }
        public string city { get; set; }
        public string comment { get; set; }
        public string email { get; set; }
        public string firstName { get; set; }
        public int id { get; set; }
        public int itemNumber { get; set; }
        public string lastName { get; set; }
        public string phone { get; set; }
        public string state { get; set; }
        public string zipCode { get; set; }

        public BillingOrder(string addressLine1=null, string addressLine2 = null, string city = null, string comment = null, string email = null, string firstName = null, int itemNumber=0, string lastName = null, string phone = null, string state = null, string zipCode = null)
        {
            this.addressLine1 = addressLine1 ?? DataGenerator.Randomstring(10);
            this.addressLine2 = addressLine2 ?? TestContext.CurrentContext.Random.GetString(20);
            this.city = city ?? DataGenerator.Randomstring(10);
            this.comment = comment ?? DataGenerator.Randomstring(10);
            this.email = email ?? TestContext.CurrentContext.Random.GetString() + "gmail.com";
            this.firstName = firstName ?? DataGenerator.FullName;
            this.itemNumber = itemNumber==0 ? 1: itemNumber;
            this.lastName = lastName ?? "patel";
            this.phone = phone ?? "1231123123";
            this.state = state ?? "AK";
            this.zipCode = zipCode ?? "666666";
        }
    }

}

