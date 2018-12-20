﻿using HotelManager.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace HotelManager.Helper
{
    public static class XmlHelper
    {
        public static string OPath = System.AppDomain.CurrentDomain.BaseDirectory;
        public static string PersonXmlPath = OPath + "person.xml";

        public static void WriteNowPerson(Person person)
        {
            
            XmlSerializer serializer = new XmlSerializer(person.GetType());
            TextWriter writer = new StreamWriter("person.xml");
            serializer.Serialize(writer, person);
            writer.Close();
        }

        public static Person SelectNowPerson()
        {
            Person p = new Person();
            XmlSerializer serializer = new XmlSerializer(p.GetType());
            FileStream stream = new FileStream(PersonXmlPath, FileMode.Open);
            Person person = (Person)serializer.Deserialize(stream);
            stream.Close();
			return person;
        }

        public static void CreatXmlTree(string xmlPath)
        {
            XElement xElement = new XElement(
                new XElement("Colors",
                    new XElement("color1",
                        new XElement("ColorName", "默认(灰色)", new XAttribute("Name", "")),
                        new XElement("Author", "Martin", new XAttribute("Name", "Martin")),
                        new XElement("Adress", "上海"),
                        new XElement("Date", DateTime.Now.ToString("yyyy-MM-dd"))
                        ),
                    new XElement("Book2",
                        new XElement("Name", "WCF入门", new XAttribute("BookName", "WCF")),
                        new XElement("Author", "Mary", new XAttribute("Name", "Mary")),
                        new XElement("Adress", "北京"),
                        new XElement("Date", DateTime.Now.ToString("yyyy-MM-dd"))
                        )
                        )
                );

            //需要指定编码格式，否则在读取时会抛：根级别上的数据无效。 第 1 行 位置 1异常
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Encoding = new UTF8Encoding(false);
            settings.Indent = true;
            XmlWriter xw = XmlWriter.Create(xmlPath, settings);
            xElement.Save(xw);
            //写入文件
            xw.Flush();
            xw.Close();
        }
        public static void SelectAttribute(string xmlPath)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlPath);
            XmlElement element = (XmlElement)xmlDoc.SelectSingleNode("BookStore/NewBook");
            string name = element.GetAttribute("Name");
            MessageBox.Show(name);
        }

    }
}
