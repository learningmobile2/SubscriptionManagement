using DataOperations;
using SMS.Entities;
using SMS.Entities.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SMS.WebService.Controllers
{
    public class CustomersController : ApiController
    {
        private Customers customerModel = null;
        private Customers CustomerModel
        {
            get
            {
                if (customerModel == null)
                {
                    customerModel = new Customers(new DatabaseOperations(@"C:\RND\SubscriptionManagement\Code\Server\DataOperations\smsmain.sqllite3.db", Entities.DataInterface.DBType.Server));
                }

                return this.customerModel;
            }
        }
        // GET: api/Customer
        public IEnumerable<Customer> Get()
        {
            return this.CustomerModel.FindAllCustomers().Result;
        }

        // GET: api/Customer/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Customer
        public void Post([FromBody]Customer customer)
        {
            this.CustomerModel.Create(customer);
        }

        // PUT: api/Customer/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Customer/5
        public void Delete(int id)
        {
        }
    }
}
