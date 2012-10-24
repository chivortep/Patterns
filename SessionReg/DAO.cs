using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace SessionReg
{
    public static class DAO
    {
        /// <summary>
        /// Сохранение клиента в XML
        /// </summary>
        /// <param name="customer"></param>
        public static void SaveCustomer(Customer customer)
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

        /// <summary>
        /// Получение списка клиентов из XML
        /// </summary>
        /// <returns></returns>
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
                Customer cst = new Customer(curNode.ChildNodes[0].InnerText,
                                            curNode.ChildNodes[1].InnerText, 
                                            int.Parse(curNode.ChildNodes[2].InnerText));
                _customers.Add(cst);
            }

            reader.Close();
            //doc.Save(path);

            return _customers;
        }


        public static void UpdateCustomer(Customer customer, string newName, string newSurname, int newAge)
        {
            String xmlFile = System.Configuration.ConfigurationManager.AppSettings["xmlFile"];
            string path = HttpContext.Current.Server.MapPath(xmlFile);

            XmlDocument doc = new XmlDocument();
            XmlTextReader reader = new XmlTextReader(path);
            doc.Load(reader);
            XmlNode root = doc.DocumentElement;

            // ищем узел текущего клиента в дереве
            if (root != null && root.HasChildNodes)
            {
                XmlNode nodeToUpdate = root.ChildNodes.Cast<XmlNode>().Where(
                    curNode => curNode != null && curNode["name"] != null && curNode["surname"] != null && curNode["age"] != null).FirstOrDefault(
                        curNode => curNode.ChildNodes[0].InnerText == customer.Name &&
                                    curNode.ChildNodes[1].InnerText == customer.Surname &&
                                    curNode.ChildNodes[2].InnerText == customer.Age.ToString());

                if (nodeToUpdate != null)
                {
                    nodeToUpdate.ChildNodes[0].InnerText = newName;
                    nodeToUpdate.ChildNodes[1].InnerText = newSurname;
                    nodeToUpdate.ChildNodes[2].InnerText = newAge.ToString();
                }
            }
            reader.Close();
            doc.Save(path);
        }

        public static void DeleteCustomer(Customer customer)
        {
            String xmlFile = System.Configuration.ConfigurationManager.AppSettings["xmlFile"];
            string path = HttpContext.Current.Server.MapPath(xmlFile);

            XmlDocument doc = new XmlDocument();
            XmlTextReader reader = new XmlTextReader(path);
            doc.Load(reader);
            XmlNode root = doc.DocumentElement;

            // ищем узел текущего клиента в дереве
            if (root != null && root.HasChildNodes)
            {
                XmlNode nodeToDelete = root.ChildNodes.Cast<XmlNode>().Where(
                    curNode => curNode != null && curNode["name"] != null && curNode["surname"] != null && curNode["age"] != null).FirstOrDefault(
                        curNode => curNode.ChildNodes[0].InnerText == customer.Name &&
                                    curNode.ChildNodes[1].InnerText == customer.Surname &&
                                    curNode.ChildNodes[2].InnerText == customer.Age.ToString());

                if (nodeToDelete !=null)
                {
                    root.RemoveChild(nodeToDelete);
                }
            }
            reader.Close();
            doc.Save(path);
        }
    }
}