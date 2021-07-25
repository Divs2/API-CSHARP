using FluentAssertions;
using july_2021.API;
using july_2021.Model;
using LumenWorks.Framework.IO.Csv;
using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using RestSharp;
using System;
using System.Collections;
using System.IO;
using System.Net;

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

        [TestCaseSource(nameof(BillingOrderTestCaseData))]
        public void TC_Postorder(BillingOrder Expectedorder, string status)
        {
            
            
            string jsonbody = JsonConvert.SerializeObject(Expectedorder);
            BillingOrderAPI Billingorderapi = new BillingOrderAPI();
            IRestResponse response = Billingorderapi.PostOrder(jsonbody);
            TestContext.WriteLine(response.Content);
            BillingOrder actualOrder = JsonConvert.DeserializeObject<BillingOrder>(response.Content);
            id = actualOrder.id + "";
            Expectedorder.Should().BeEquivalentTo(actualOrder, options => options.Excluding(o => o.id));
            
        }
        [TestCaseSource(nameof(BillingOrderCsvData))]
        public void TC_Postorder(BillingOrder Expectedorder)
        {


            string jsonbody = JsonConvert.SerializeObject(Expectedorder);
            BillingOrderAPI Billingorderapi = new BillingOrderAPI();
            IRestResponse response = Billingorderapi.PostOrder(jsonbody);
            TestContext.WriteLine(response.Content);
            BillingOrder actualOrder = JsonConvert.DeserializeObject<BillingOrder>(response.Content);
            id = actualOrder.id + "";
            Expectedorder.Should().BeEquivalentTo(actualOrder, options => options.Excluding(o => o.id));

        }

        public static IEnumerable BillingOrderTestCaseData
            {
            get
            {
                yield return new TestCaseData(new BillingOrder()
                {
                    addressLine1 = "Test",
                    addressLine2 = "Test1",
                    city = "Wellignton",
                    comment = "hi",
                    email = "divs25@gmail.com",
                    firstName = "Divya",
                    lastName = "Patel",
                    phone = "1231231231",
                    zipCode = "222222",
                    itemNumber = 9,
                    state = "AL"
                }, "valid").SetName("create billing order test case");
                yield return new TestCaseData(new BillingOrder(),"valid").SetName("default test data");
               // yield return new TestCaseData(new BillingOrder(email:"333"),"invalid").SetName("email validation data");


            }
            }


        



        string id = null;
        [TearDown]

        public void CleanUp()
        {
            if (string.IsNullOrEmpty(id))
            {
                BillingOrderAPI Billingorderapi = new BillingOrderAPI();
                Billingorderapi.DeleteOrderById(id);
                id = null;
            }
        }

        ChromeDriver driver = new ChromeDriver();
        BillingOrder Expectedorder = new BillingOrder()
        {
            addressLine1 = "Test",
            addressLine2 = "Test1",
            city = "Wellignton",
            comment = "hi",
            email = "divs25@gmail.com",
            firstName = "Divya",
            lastName = "Patel",
            phone = "1231231231",
            zipCode = "222222",
            itemNumber = 9,
            state = "AL"
        };

    [Test]
        public void TC_UI_Test()
        {

            BillingorderTest orderpage = new BillingorderTest(driver);
            orderpage.SubmitBillingOrder(Expectedorder);

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
            string body = $"{{\"firstName\":\"Csharp\",\"itemNumber\":\"i\",\"addressLine1\":\"test\",\"addressLine2\": \"ddd\",\"city\": \"CA\",\"comment\": \"testing\",\"email\": \"aa@aa.com\", \"lastName\": \"dddd\",\"phone\": \"1111111111\", \"state\": \"AK\",\"zipCode\":\"222222\"}}";
            BillingOrderAPI Billingorder = new BillingOrderAPI();
            IRestResponse response = Billingorder.PutOrder("100", body);
            TestContext.WriteLine(response.Content);
        }
        public static IEnumerable BillingOrderCsvData()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"\sTestData\data.csv";
            using (var csv = new CsvReader(new StreamReader(Path.Combine( $"{path}")),true))
            
            while (csv.ReadNextRecord())
            {
                    string description = csv["description"];
                BillingOrder order = new BillingOrder(
                    addressLine1: csv["addressline1"],
                    email: csv["email"],
                    firstName: csv["firstname"]
                    );
                yield return new TestCaseData(order).SetName(description);

            }


        }
        }


    }


    
