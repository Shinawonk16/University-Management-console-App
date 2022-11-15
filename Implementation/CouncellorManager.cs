using System;
using System.IO;
using System.Collections.Generic;
using Admission_portal.Interfaces;
using Admission_portal.Model;
namespace Admission_portal.Implementation
{
    public class CouncellorManager : ICouncellor
    {
        public static List<Councelor> listOfCouncelor = new List<Councelor>();

        public string FilePath = "C:\\Users\\Toshiba\\Desktop\\Admission portal\\File\\councelor.txt";



        public void CreateCouncellor(string firstName, string lastName, string email, string phoneNumber, string passWord, string dateOfBirth)
        {
            Random random = new Random();
            string councelorId = "CHAN/" + lastName + random.Next(0, 2).ToString() + "/UNIWAR";
            Councelor councelor = new Councelor(firstName, lastName, email, phoneNumber, passWord, dateOfBirth, councelorId);
            listOfCouncelor.Add(councelor);
            using (StreamWriter writer = new StreamWriter(FilePath, append: true))
            {
                writer.WriteLine(councelor.ConvertToFileFormat());
            }

            Console.WriteLine($"thank you mr {councelor.FirstName}, your  identity number is {councelor.CouncelorId}");

        }

        public void DeleteCouncellor()
        {
            System.Console.WriteLine("eenter the councelorId you  want delete");
            string councelorId = Console.ReadLine();
            // Councelor councelor = GetCouncelor( councelorId);
            foreach (var item in listOfCouncelor)
            {
                if (item.CouncelorId == councelorId)
                {
                    listOfCouncelor.Remove(item);
                    RewriteFile();
                    Console.WriteLine($" Successfully deleted. ");
                    break;
                }
                else
                {
                    Console.WriteLine("Councelor  not found.");
                }
            }

        }

        public Councelor GetCouncelor(string councelorId)
        {
            foreach (var item in listOfCouncelor)
            {
                if (item.CouncelorId == councelorId)
                {
                    return item;
                }
            }
            return null;
        }

        // public Councelor GetCouncelor()
        // {
        //     throw new NotImplementedException();
        // }

        public Councelor Login(string email, string passWord)
        {
            foreach (var item in listOfCouncelor)
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
                    string councelorInfo = reader.ReadLine();
                    listOfCouncelor.Add(Councelor.ConvertToCouncelor(councelorInfo));
                }
            }
        }

        public void RewriteFile()
        {
            File.WriteAllText(FilePath, string.Empty);
            using (StreamWriter writer = new StreamWriter(FilePath, append: true))
            {
                foreach (var item in listOfCouncelor)
                {
                    writer.WriteLine(item.ConvertToFileFormat());
                }
            }
        }

        public void UpdateCouncellor()
        {
            System.Console.WriteLine("enter the councllorId you want to delete");
            string councelorId = Console.ReadLine();
            Councelor councelor = GetCouncelor(councelorId);
            if (councelor != null)
            {
                System.Console.WriteLine("enter your firstname");
                string firstName = Console.ReadLine();
                councelor.FirstName = firstName;
                System.Console.WriteLine("enter your lastname");
                string lastName = Console.ReadLine();
                councelor.LastName = lastName;
                System.Console.WriteLine("enter your email");
                string emaili = Console.ReadLine();
                councelor.Email = emaili;
                System.Console.WriteLine("enter your password");
                string passWord = Console.ReadLine();
                councelor.PassWord = passWord;
                RewriteFile();
                // directorManager.UpdateDirector(firstName, lastName, email, passWord);
                System.Console.WriteLine("Lecturer updated successfully");

            }
            else
            {
                System.Console.WriteLine("councelor  not found");
            }
        }


    }
}