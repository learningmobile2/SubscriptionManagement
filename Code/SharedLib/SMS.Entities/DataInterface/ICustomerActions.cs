using System;
using System.Collections.Generic;
using System.Text;

namespace SMS.Entities.DataInterface
{
    public interface IDataStore
    {
        DBType DBType { get; }
        #region Customer Actions
        Customer CreateCustomer(Customer customer);       
        Customer FindCustomer(long customerId);
        List<Customer> FindAllCustomers();
        List<Customer> FindAllCustomers(string alias);
        #endregion

    }
}
