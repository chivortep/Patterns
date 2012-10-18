using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace SessionReg
{
    public static class DAO
    {
        public static void SaveStudent(Customer customer)
        {
            String xmlFile = System.Configuration.ConfigurationManager.AppSettings["xmlFile"];
            string path = HttpContext.Current.Server.MapPath(xmlFile);

            XmlDocument doc = new XmlDocument();
            XmlTextReader reader = new XmlTextReader(path);
            doc.Load(reader);
            XmlNode root = doc.DocumentElement;

            XmlNode newNode = doc.CreateNode(XmlNodeType.Element, "customer", null);
            XmlElement elem = doc.CreateElement("name");
            elem.InnerText = customer.Name;
            XmlElement elem2 = doc.CreateElement("surname");
            elem2.InnerText = customer.Surname.ToString();
            XmlElement elem3 = doc.CreateElement("age");
            elem3.InnerText = customer.Age.ToString();

            newNode.AppendChild(elem);
            newNode.AppendChild(elem2);
            newNode.AppendChild(elem3);
            root.AppendChild(newNode);

            reader.Close();
            doc.Save(path);
        }

        public static List<object> GetCustomersList()
        {
            List<object> _customers = new List<object>();

            String xmlFile = System.Configuration.ConfigurationManager.AppSettings["xmlFile"];
            string path = HttpContext.Current.Server.MapPath(xmlFile);
            XmlDocument doc = new XmlDocument();
            XmlTextReader reader = new XmlTextReader(path);
            doc.Load(reader);

            XmlNode root = doc.DocumentElement;
            XmlNodeList customersNodes = root.ChildNodes;

            foreach (XmlNode curNode in customersNodes)
            {
                Customer cst = new Customer();
                cst.Name = curNode.ChildNodes[0].InnerText;
                cst.Surname = curNode.ChildNodes[1].InnerText;
                cst.Age = int.Parse(curNode.ChildNodes[2].InnerText);
                _customers.Add(cst);
            }

            return _customers;
        }
    }
}