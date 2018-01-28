using SMS.Entities;
using SMS.Entities.DataInterface;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Winclient.Models
{
    public class WebApiClient : IDataStore
    {
        string baseAddress;
        const string GetCustomerAll = @"\api\Customers";
        

        public WebApiClient(string baseUrl)
        {
            this.baseAddress = string.IsNullOrWhiteSpace(baseUrl) ? throw new ArgumentException(nameof(baseUrl)) : baseUrl.Trim();
            this.DBType = DBType.Online;
        }

        public DBType DBType { get; set; }

        public Customer CreateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public async Task<List<T>> FindAllCustomers<T>() where T:Customer
        {
            var client = this.GetClient();
            var responseMessage = await client.GetAsync(this.baseAddress + WebApiClient.GetCustomerAll);
            responseMessage.EnsureSuccessStatusCode();
            var result =await responseMessage.Content.ReadAsStringAsync();
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<T>>(result); ;
            
        }

        public HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(this.baseAddress);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }

        public List<Customer> FindAllCustomers(string alias)
        {
            throw new NotImplementedException();
        }

        public Customer FindCustomer(long customerId)
        {
            throw new NotImplementedException();
        }

        List<Customer> IDataStore.FindAllCustomers()
        {
            throw new NotImplementedException();
        }
    }
}
