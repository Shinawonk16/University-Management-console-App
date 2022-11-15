using System;
using System.IO;
using System.Collections.Generic;
using Admission_portal.Interfaces;
using Admission_portal.Model;
namespace Admission_portal.Implementation
{
    public class DirectorManager : IDirector
    {
        public static List<Director> listOfDirector = new List<Director>();

        public string FilePath = "C:\\Users\\Toshiba\\Desktop\\Admission portal\\File\\lecturer.txt";


        public void CreateDirector(string firstName, string lastName, string email, string phoneNumber, string passWord, string dateOfBirth)
        {
            Random random = new Random();
            string directorId = "DI/" + lastName + random.Next(600, 1000).ToString() + "/UNIWAR";
            Director director = new Director(firstName, lastName, email, phoneNumber, passWord, dateOfBirth, directorId);
            listOfDirector.Add(director);
            using (StreamWriter writer = new StreamWriter(FilePath, append: true))
            {
                writer.WriteLine(director.ConvertToFileFormat());
            }
            Console.WriteLine($"thank you mr {director.FirstName}, your  identity number is {director.DirectorId}");

        }

        public void DeleteDirector()
        {
            System.Console.WriteLine("enter directorId you want to delete");
            string directorId = Console.ReadLine().Trim();
            foreach (var item in listOfDirector)
            {
                if (item.DirectorId == directorId)
                {
                    listOfDirector.Remove(item);
                    RewriteFile();
                    Console.WriteLine($" Successfully deleted. ");
                    break;

                }
                else
                {
                    Console.WriteLine("Director not found.");
                }
            }

        }

        public void GetAllDirector()
        {
            foreach (var item in listOfDirector)
            {
                System.Console.WriteLine($"{item.FirstName}\t{item.LastName}\t{item.PassWord}\t{item.PhoneNumber}");
            }
        }

        public Director GetDirector(string directorId)
        {
            foreach (var item in listOfDirector)
            {
                if (item.DirectorId == directorId)
                {
                    return item;
                }
            }
            return null;

        }

        public Director Login(string email, string passWord)
        {
            foreach (var item in listOfDirector)
            {
                if (item.Email == email && item.PassWord == passWord)
                {
                    return item;
                }
            }
            return null;
        }

        public void ReadFromFile()
        {
            Console.WriteLine("Reading");
            using (StreamReader reader = new StreamReader(FilePath))
            {
                while (reader.Peek() > -1)
                {
                    string directorInfo = reader.ReadLine();
                    listOfDirector.Add(Director.ConvertToDirector(directorInfo));
                }
            }
        }

        public void RewriteFile()
        {
            File.WriteAllText(FilePath, string.Empty);
            using (StreamWriter writer = new StreamWriter(FilePath, append:true))
            {
                foreach (var item in listOfDirector)
                {
                    writer.WriteLine(item.ConvertToFileFormat());
                }
            }
        }

        public void UpdateDirector()
        {
            System.Console.WriteLine("enter the directrid of admins you want to update");
            string directorId = Console.ReadLine().Trim(); 
            Director direct = GetDirector(directorId);
            if (direct != null)
            {
                System.Console.WriteLine("enter your firstname");
                string firstName = Console.ReadLine();
                direct.FirstName = firstName;
                System.Console.WriteLine("enter your lastname");
                string lastName = Console.ReadLine();
                direct.LastName = lastName;
                System.Console.WriteLine("enter your email");
                string emaili = Console.ReadLine();
                direct.Email = emaili;
                System.Console.WriteLine("enter your password");
                string passWord = Console.ReadLine();
                direct.PassWord = passWord;
                RewriteFile();
                // directorManager.UpdateDirector(firstName, lastName, email, passWord);
                System.Console.WriteLine("Lecturer updated successfully");




            }
            else
            {
                Console.WriteLine("Diector not found");
                foreach (var item in listOfDirector)
                {
                    Console.WriteLine(item.DirectorId);
                }
            }

        }
    }


}

