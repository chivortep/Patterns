using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SessionReg
{
    public sealed class CustomerValueListHandler: ValueListHandler
    {
        private readonly List<Customer> _customers;

        public CustomerValueListHandler()
        {
            base.SetList(DAO.GetCustomersList());
            _customers = this.GetAllCustomers(base.GetList());
        }

        private List<Customer> GetAllCustomers(List<object> custObjects)
        {
            List<Customer> customers = new List<Customer>();
            if (custObjects != null)
            {
                foreach (object custObj in custObjects)
                {
                    Customer cust = (Customer)custObj;
                    if (cust != null)
                    {
                        customers.Add(cust);
                    }
                }
            }
            return customers;
        }
    }
}