using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SessionReg
{
    public sealed class Customer : IEquatable<Customer>
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
                MarkDirty(newValue);
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
                MarkDirty(newValue);
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
                MarkDirty(newValue);
                age = value;
            }
        }

        public Customer()
        {
            this.name = "";
            this.surname = "";
            this.age = 0;
            MarkNew();
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
                MarkNew();
        }

        private Customer(Customer example)
        {
            // не помечается новым, т.к. используется только внутри класса для создания клона
            this.name = example.Name;
            this.surname = example.Surname;
            this.age = example.Age;
        }

        public void MarkNew()
        {
            UnitOfWork.GetCurrent().RegisterNew(this);
        }

        public void MarkDirty(Customer newValue)
        {
            UnitOfWork.GetCurrent().RegisterDirty(this, newValue);
        }
        public void MarkRemoved()
        {
            UnitOfWork.GetCurrent().RegisterDeleted(this);
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