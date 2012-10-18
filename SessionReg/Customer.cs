using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SessionReg
{
    public class Customer
    {
        private string name;
        private string surname;
        private int age;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public Customer() { }
        public Customer(string name, string surname, int age)
        {
            this.name = name;
            this.surname = surname;
            this.age = age;
        }
    }
}