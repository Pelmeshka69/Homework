using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_2
{
    internal class Program
    {
        static List<User> users = new List<User>();
        static List<User> admins = new List<User>();

        class User
        {
            public string Email { get; }
            public string Password { get; }
            public string FullName { get; }
            public string DateOfBirth { get; }
            public string PhoneNumber { get; }

            public User(string email, string password, string fullName, string dateOfBirth, string phoneNumber)
            {
                Email = email;
                Password = password;
                FullName = fullName;
                DateOfBirth = dateOfBirth;
                PhoneNumber = phoneNumber;
            }
        }
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1. Register as User");
                Console.WriteLine("2. Login as Administrator");
                Console.WriteLine("3. Exit");
                Console.Write("Choose an option: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        RegisterUser();
                        break;
                    case "2":
                        LoginAsAdmin();
                        break;
                    case "3":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void RegisterUser()
        {
            Console.Write("Enter your email: ");
            string email = Console.ReadLine();

            Console.Write("Enter your password: ");
            string password = Console.ReadLine();

            Console.Write("Enter your full name: ");
            string fullName = Console.ReadLine();

            Console.Write("Enter your date of birth (YYYY-MM-DD): ");
            string dateOfBirth = Console.ReadLine();

            Console.Write("Enter your phone number: ");
            string phoneNumber = Console.ReadLine();

            if (UserExists(email))
            {
                Console.WriteLine("User with this email already exists.");
                return;
            }

            User user = new User(email, password, fullName, dateOfBirth, phoneNumber);
            users.Add(user);
            Console.WriteLine("User registered successfully.");
        }

        static void LoginAsAdmin()
        {
            Console.Write("Enter your email: ");
            string email = Console.ReadLine();

            Console.Write("Enter your password: ");
            string password = Console.ReadLine();

            if (email == "admin@example.com" && password == "admin123")
            {
                Console.WriteLine("Logged in as Administrator.");
                Console.WriteLine("List of all users:");
                foreach (User user in users)
                {
                    Console.WriteLine("Email: " + user.Email + ", Full Name: " + user.FullName + ", Date of Birth: " + user.DateOfBirth + ", Phone Number: " + user.PhoneNumber);
                }
            }
            else
            {
                Console.WriteLine("Invalid email or password for Administrator.");
            }
        }

        static bool UserExists(string email)
        {
            foreach (User user in users)
            {
                if (user.Email == email)
                {
                    return true;
                }
            }
            return false;
        }
    }

}