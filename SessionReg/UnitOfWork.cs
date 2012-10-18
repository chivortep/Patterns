using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SessionReg
{
    public class UnitOfWork
    {
        private List<Customer> _newCustomers;
        private List<Customer> _deletedCustomers;
        private Dictionary<Customer,Customer> _updatedCustomers;

        public UnitOfWork()
        {
            _newCustomers = new List<Customer>();
            _deletedCustomers = new List<Customer>();
            _updatedCustomers = new Dictionary<Customer, Customer>();
        }

        public void Commit()
        {
            List<object> existingCustomers = DAO.GetCustomersList();

            // сохраняем всех клиентов, которых ещё нету в базе
            foreach (Customer customer in _newCustomers)
            {
                if (!existingCustomers.Contains(customer))
                    DAO.SaveCustomer(customer);
            }

            // удаляем всех помеченных клиентов, которые ещё есть в базе
            foreach (Customer customer in _deletedCustomers)
            {
                if (existingCustomers.Contains(customer))
                    DAO.DeleteCustomer(customer);
            }

            // обновляем свойства для измененных клиентов, которые ещё есть в базе
            foreach (KeyValuePair<Customer, Customer> customerPair in _updatedCustomers)
            {
                if (existingCustomers.Contains(customerPair.Key))
                    DAO.UpdateCustomer(customerPair.Key, customerPair.Value.Name, customerPair.Value.Surname, customerPair.Value.Age);
            }

            // обнуляем исполненные списки
            _newCustomers = new List<Customer>();
            _deletedCustomers = new List<Customer>();
            _updatedCustomers = new Dictionary<Customer, Customer>();
        }

        public void Rollback()
        {
            // просто обнуляем все списки с неисполненными изменениями
            _newCustomers = new List<Customer>();
            _deletedCustomers = new List<Customer>();
            _updatedCustomers = new Dictionary<Customer, Customer>();
        }

        public void RegisterNew(Customer customer)
        {
            if (customer!=null && !(_newCustomers.Contains(customer)))
            {
                _newCustomers.Add(customer);
            }
        }

        public void RegisterDeleted(Customer customer)
        {
            if (customer!=null)
            {
                if (_newCustomers.Contains(customer))
                {
                    // если клиент был добавлен ранее в ходе транзакции - он просто не будет сохранен
                    _newCustomers.Remove(customer);
                }
                else if (_updatedCustomers.ContainsKey(customer))
                {
                    // если объект был уже обновлен - пропускаем его
                    // как вариант - может удалять его новую версию
                }
                else if (_updatedCustomers.ContainsValue(customer))
                {
                    // если объект в списке на обновление - удаляем его оттуда и переносим в список на удаление его старую версию
                    Customer foundKey = null;
                    for (int i=0; i<_updatedCustomers.Count; i++)
                    {
                        if (_updatedCustomers.ElementAt(i).Value == customer)
                        {
                            foundKey = _updatedCustomers.ElementAt(i).Key;
                            break;
                        }
                    }

                    if(foundKey!=null)
                    {
                        _updatedCustomers.Remove(foundKey);
                        _deletedCustomers.Add(foundKey);
                    }
                }
                else
                {
                    _deletedCustomers.Add(customer); // иначе - будет удален
                }
            }
        }


        public void RegisterDirty(Customer oldCustomer, Customer updatedCustomer) // Обновление
        {
            if (_newCustomers.Contains(oldCustomer))
            {
                // заменяем добавленного клиента на его же обновленную версию
                _newCustomers.Remove(oldCustomer);
                _newCustomers.Add(updatedCustomer);
            }
            else if (_deletedCustomers.Contains(oldCustomer))
            {
                // пропускаем запрос, т.к. клиент уже был помечен для удаления
                // ? - можно помещать его обновленную версию в список _newCustomers
                return;
            }
            else if (_updatedCustomers.ContainsValue(oldCustomer))
            {
                Customer foundKey = null;
                for (int i = 0; i < _updatedCustomers.Count; i++)
                {
                    if (_updatedCustomers.ElementAt(i).Value == oldCustomer)
                    {
                        foundKey = _updatedCustomers.ElementAt(i).Key;
                        break;
                    }
                }

                if (foundKey != null)
                {
                    _updatedCustomers[foundKey] = updatedCustomer;
                }
            }
            else
            {
                // добавляем в очередь на обновление
                _updatedCustomers.Add(oldCustomer, updatedCustomer);
            }
        }


        private static UnitOfWork Current;
        public static void newCurrent()
        {
            setCurrent(new UnitOfWork());
        }
        public static void setCurrent(UnitOfWork uow)
        {
            Current = uow;
        }
        public static UnitOfWork getCurrent()
        {
            return Current;
        }
    }
}