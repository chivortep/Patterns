using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SessionReg
{
    public class Customer : IEquatable<Customer>
    {
        private string name;
        private string surname;
        private int age;

        public string Name
        {
            get { return name; }
            set 
            { 
                Customer newValue = new Customer(this);
                newValue.name = value;
                markDirty(newValue);
                name = value;
            }
        }

        public string Surname
        {
            get { return surname; }
            set
            {
                Customer newValue = new Customer(this);
                newValue.surname = value;
                markDirty(newValue);
                surname = value;
            }
        }

        public int Age
        {
            get { return age; }
            set
            {
                Customer newValue = new Customer(this);
                newValue.age = value;
                markDirty(newValue);
                age = value;
            }
        }

        public Customer()
        {
            this.name = "";
            this.surname = "";
            this.age = 0;
            markNew();
        }

        public Customer(string name, string surname, int age)
        {
            this.name = name;
            this.surname = surname;
            this.age = age;
            //markNew(); // по умолчанию новый экземпляр НЕ регистрируется в UoW
        }

        public Customer(string name, string surname, int age, bool register)
        {
            this.name = name;
            this.surname = surname;
            this.age = age;
            if (register)
                markNew();
        }

        private Customer(Customer example)
        {
            // не помечается новым, т.к. используется только внутри класса для создания клона
            this.name = example.Name;
            this.surname = example.Surname;
            this.age = example.Age;
        }

        public void markNew()
        {
            UnitOfWork.getCurrent().RegisterNew(this);
        }

        public void markDirty(Customer newValue)
        {
            UnitOfWork.getCurrent().RegisterDirty(this, newValue);
        }
        public void markRemoved()
        {
            UnitOfWork.getCurrent().RegisterDeleted(this);
        }

        public bool Equals(Customer other)
        {
            return this.name == other.name &&
                   this.surname == other.surname &&
                   this.age == other.age;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Customer);
        }

        public override int GetHashCode()
        {
            return 1;
        }
    }
}