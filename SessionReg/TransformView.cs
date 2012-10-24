using System;
using System.IO;
using System.Web;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace SessionReg
{
    public static class TransformView
    {
        
        // Формирует html таблицу из xml+xslt
        public static string GenerateView()
        {
            String html = "";

            String xmlFilePath = HttpContext.Current.Server.MapPath(System.Configuration.ConfigurationSettings.AppSettings["xmlFile"]);
            String xsltFilePath = HttpContext.Current.Server.MapPath(System.Configuration.ConfigurationSettings.AppSettings["xsltFile"]);
            String htmlFilePath = HttpContext.Current.Server.MapPath("tmp.html");

            var stream = File.Create(htmlFilePath); // временный файл для html
            stream.Close();

            XPathDocument xPathDocument = new XPathDocument(xmlFilePath);
            XslCompiledTransform myXslTransform = new XslCompiledTransform();
            XmlTextWriter writer = new XmlTextWriter(htmlFilePath, null);
            myXslTransform.Load(xsltFilePath);
            myXslTransform.Transform(xPathDocument, null, writer);
            writer.Close();
            using (StreamReader reader = new StreamReader(File.Open(htmlFilePath, FileMode.Open)))
            {
                html = reader.ReadToEnd();
                reader.Close();
            }

            File.Delete(htmlFilePath);

            return html;
        }      
    }
}