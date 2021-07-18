using july_2021.API;
using NUnit.Framework;
using RestSharp;

namespace july_2021
{
    public class Tests
    {
        
        

        [Test]
        public void TC_Getorder()
        {
            BillingOrderAPI Billingorder = new BillingOrderAPI();
            IRestResponse response = Billingorder.GetOrderById("10");
            TestContext.WriteLine(response.Content);

        }
        [Test]
        public void TC_Deleteorder()
        {
            BillingOrderAPI Billingorder = new BillingOrderAPI();
            IRestResponse response = Billingorder.DeleteOrderById("2");
            TestContext.WriteLine(response.Content);

        }



        [Test]
        public void TC_Postorder()
        {
            for (int i = 1; i <= 100; i++)
            {
                string body = $"{{\"firstName\":\"Csharp{i}\",\"itemNumber\":{i},\"addressLine1\":\"test\",\"addressLine2\": \"ddd\",\"city\": \"CA\",\"comment\": \"testing\",\"email\": \"aa@aa.com\", \"lastName\": \"dddd\",\"phone\": \"1111111111\", \"state\": \"AK\",\"zipCode\": \"222222\"}}";
                BillingOrderAPI Billingorder = new BillingOrderAPI();
                IRestResponse response = Billingorder.PostOrder(body);
                TestContext.WriteLine(response.Content);
            }
        }

        [Test]
        public void TC_Getallorder()
        {
            BillingOrderAPI Billingorder = new BillingOrderAPI();
            IRestResponse response = Billingorder.Getallorders();
            TestContext.WriteLine(response.Content);

        }
        [Test]
        public void TC_PutOrder()
        
            {
                string body =$"{{\"firstName\":\"Csharp\",\"itemNumber\":\"i\",\"addressLine1\":\"test\",\"addressLine2\": \"ddd\",\"city\": \"CA\",\"comment\": \"testing\",\"email\": \"aa@aa.com\", \"lastName\": \"dddd\",\"phone\": \"1111111111\", \"state\": \"AK\",\"zipCode\":\"222222\"}}";
                BillingOrderAPI Billingorder = new BillingOrderAPI();
                IRestResponse response = Billingorder.PutOrder("100",body);
                TestContext.WriteLine(response.Content);
            }
        }

    }
