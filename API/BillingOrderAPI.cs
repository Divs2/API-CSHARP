using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace july_2021.API
{
    class BillingOrderAPI
    {
        private readonly string baseUrl = "http://localhost:8080";
        public IRestResponse GetOrderById(string id)
        {
            var client = new RestClient($"{baseUrl}/BillingOrder/{id}");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            return response;
        }
        public IRestResponse Getallorders()
        {
            var client = new RestClient($"{baseUrl}/BillingOrder");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            return response;
        }
        public IRestResponse DeleteOrderById(string id)
        {
            var client = new RestClient($"{baseUrl}/BillingOrder/{id}");
            var request = new RestRequest(Method.DELETE);
            IRestResponse response = client.Execute(request);
            return response;
        }
        public IRestResponse PostOrder(string body)
        {
            var client = new RestClient($"{baseUrl}/BillingOrder");
            var request = new RestRequest(Method.POST );
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            return response;
        }
        public IRestResponse PutOrder(string id, string body)
        {
            var client = new RestClient($"{baseUrl}/BillingOrder");
            var request = new RestRequest(Method.PUT);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            return response;
        }
    }
}
