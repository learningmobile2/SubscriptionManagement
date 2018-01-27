using System;
using System.Collections.Generic;
using System.Text;
using SMS.Entities;
using SMS.Entities.DataInterface;


namespace SMS.Entities.BusinessLogic
{

    public class Customers
    {
        private IDataStore dataStore;
        public Customers(IDataStore dataStore)
        {
            this.dataStore = dataStore == null ? throw new ArgumentNullException(nameof(dataStore)) : dataStore;
        }

        public OperationResult<Customer> Create(Customer customer)
        {
            OperationResult<Customer> result = null;
            try
            {
                customer = this.dataStore.CreateCustomer(customer);
                result = new OperationResult<Customer>() { IsSuccess = true, Result = customer };
            }
            catch (Exception ex)
            {
                result = new OperationResult<Customer>() { IsSuccess = false, ErrorCode = OperationErrorCode.ConnectionFailure, Exception = ex };
            }

            return result;
        }

        public OperationResult<Customer> GetCustomer(int customerId)
        {
            OperationResult<Customer> result = null;
            try
            {
                var customer = this.dataStore.FindCustomer(customerId);
                if (customer == null)
                {
                    result = new OperationResult<Customer>() { IsSuccess = false, ErrorCode = OperationErrorCode.NoDataFound };
                }
                else
                {
                    result = new OperationResult<Customer>() { IsSuccess = true, Result = customer };
                }
            }
            catch (Exception ex)
            {
                result = new OperationResult<Customer>() { IsSuccess = false, ErrorCode = OperationErrorCode.ConnectionFailure, Exception = ex };
            }

            return result;
        }
    }
}
