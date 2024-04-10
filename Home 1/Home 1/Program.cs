using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace Home_1
{
    internal class Program
    {
        static string filePath = "users.xml";

        static void Main(string[] args)
        {
            CreateXmlFileIfNotExists();

            while (true)
            {
                Console.WriteLine("1. Додати нового користувача");
                Console.WriteLine("2. Редагувати існуючого користувача");
                Console.WriteLine("3. Вивести інформацію про всіх користувачів");
                Console.WriteLine("4. Видалити користувача");
                Console.WriteLine("5. Вийти з програми");

                Console.Write("Оберіть опцію: ");
                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            AddUser();
                            break;
                        case 2:
                            EditUser();
                            break;
                        case 3:
                            DisplayAllUsers();
                            break;
                        case 4:
                            DeleteUser();
                            break;
                        case 5:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                }

                Console.WriteLine();
            }
        }

        static void CreateXmlFileIfNotExists()
        {
            if (!File.Exists(filePath))
            {
                using (XmlWriter writer = XmlWriter.Create(filePath))
                {
                    writer.WriteStartElement("Users");
                    writer.WriteEndElement();
                    writer.Flush();
                }
            }
        }

        static void AddUser()
        {
            XElement user = new XElement("User");

            Console.Write("Ім'я: ");
            string name = Console.ReadLine();
            user.Add(new XElement("Name", name));

            Console.Write("Пароль: ");
            string password = Console.ReadLine();
            user.Add(new XElement("Password", password));

            Console.Write("Пошта: ");
            string email = Console.ReadLine();
            user.Add(new XElement("Email", email));

            Console.Write("Вік: ");
            int age;
            if (int.TryParse(Console.ReadLine(), out age))
            {
                user.Add(new XElement("Age", age));
            }
            else
            {
                Console.WriteLine("Невірний формат віку. Користувач не доданий.");
                return;
            }

            Console.Write("Баланс: ");
            double balance;
            if (double.TryParse(Console.ReadLine(), out balance))
            {
                user.Add(new XElement("Balance", balance));
            }
            else
            {
                Console.WriteLine("Невірний формат балансу. Користувач не доданий.");
                return;
            }

            Console.Write("Статус: ");
            string status = Console.ReadLine();
            user.Add(new XElement("Status", status));

            Console.Write("Дата народження (yyyy-MM-dd): ");
            DateTime birthDate;
            if (DateTime.TryParse(Console.ReadLine(), out birthDate))
            {
                user.Add(new XElement("BirthDate", birthDate.ToString("yyyy-MM-dd")));
            }
            else
            {
                Console.WriteLine("Невірний формат дати. Користувач не доданий.");
                return;
            }

            Console.Write("Країна: ");
            string country = Console.ReadLine();
            user.Add(new XElement("Country", country));

            XDocument doc = XDocument.Load(filePath);
            doc.Element("Users").Add(user);
            doc.Save(filePath);

            Console.WriteLine("Користувач успішно доданий.");
        }

        static void EditUser()
        {
            Console.Write("Введіть ім'я користувача, якого бажаєте редагувати: ");
            string name = Console.ReadLine();

            XDocument doc = XDocument.Load(filePath);
            XElement user = doc.Descendants("User")
                               .FirstOrDefault(u => u.Element("Name").Value.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (user != null)
            {
                Console.Write("Вік: ");
                int age;
                if (int.TryParse(Console.ReadLine(), out age))
                {
                    user.Element("Age").Value = age.ToString();
                }
                else
                {
                    Console.WriteLine("Невірний формат віку. Зміни не збережені.");
                }

                Console.Write("Баланс: ");
                double balance;
                if (double.TryParse(Console.ReadLine(), out balance))
                {
                    user.Element("Balance").Value = balance.ToString();
                }
                else
                {
                    Console.WriteLine("Невірний формат балансу. Зміни не збережені.");
                }

                Console.WriteLine("Інформація про користувача оновлена.");
                doc.Save(filePath);
            }
            else
            {
                Console.WriteLine("Користувача з таким ім'ям не знайдено.");
            }
        }

        static void DisplayAllUsers()
        {
            XDocument doc = XDocument.Load(filePath);
            IEnumerable<XElement> users = doc.Descendants("User");

            foreach (var user in users)
            {
                Console.WriteLine("Ім'я: " + user.Element("Name").Value);
                Console.WriteLine("Пароль: " + user.Element("Password").Value);
                Console.WriteLine("Пошта: " + user.Element("Email").Value);
                Console.WriteLine("Вік: " + user.Element("Age").Value);
                Console.WriteLine("Баланс: " + user.Element("Balance").Value);
                Console.WriteLine("Статус: " + user.Element("Status").Value);
                Console.WriteLine("Дата народження: " + user.Element("BirthDate").Value);
                Console.WriteLine("Країна: " + user.Element("Country").Value);
                Console.WriteLine();
            }
        }

        static void DeleteUser()
        {
            Console.Write("Введіть ім'я користувача, якого бажаєте видалити: ");
            string name = Console.ReadLine();

            XDocument doc = XDocument.Load(filePath);
            XElement user = doc.Descendants("User")
                               .FirstOrDefault(u => u.Element("Name").Value.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (user != null)
            {
                user.Remove();
                doc.Save(filePath);
                Console.WriteLine("Користувач видалений.");
            }
            else
            {
                Console.WriteLine("Користувача з таким ім'ям не знайдено.");
            }
        }
    }
}
